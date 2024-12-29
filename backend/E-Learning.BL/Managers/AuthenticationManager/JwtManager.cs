using E_Learning.BL.DTO.User;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Managers.AuthenticationManager
{
    public class JwtManager : IJwtManager
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public JwtManager(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;

        }
        public async Task<AuthenticationResponseDTO> createJwtToken(User user)
        {
            // Create a DateTime object representing the token expiration time
            DateTime expiration = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:ExpiryMinutes"]));

            // Get the user's roles from the UserManager
            var roles = await _userManager.GetRolesAsync(user);

            // Create a list of claims representing the user's information
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()), // User ID
        new Claim(JwtRegisteredClaimNames.Sub , user.FName ?? "Unknown"), // Use FName or default to "Unknown"
        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? "Unknown"), // Add the user's email as a claim
        new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()), // Token ID
    };

            // Add roles to claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Create the signing credentials using the secret key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the token
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            // Return the JWT token and other related info
            var response = new AuthenticationResponseDTO
            {
                Email = user.Email,
                FName = user.FName,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpirationDateTime = DateTime.Now.AddDays(7) // Example refresh token expiry
            };

            return response;
        }

        public ClaimsPrincipal GetClaimsPrinciplFromJwtToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),

                ValidateLifetime = false //should be false
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal principal = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        private string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }


}


