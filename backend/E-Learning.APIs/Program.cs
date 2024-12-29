using E_Learning.BL.ServicesExtention;
using E_Learning.DAL.Data.Context;
using E_Learning.DAL.ServicesExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_Learning.APIs.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using E_Learning.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.OAuth;
using QuestPDF.Infrastructure;



namespace E_Learning.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                //Authorization policy for authunticating all endpoints 
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //adding the mail service
            builder.Services.AddSwaggerGen();

            /*------------------------------------------------------------------------*/
            builder.Services.AddBLServices();
            builder.Services.AddDALServices(builder.Configuration);

         


            //CORS: localhost:4200, localhost:4100
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder
                    .WithOrigins("http://localhost:5062", "http://localhost:4200")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowCredentials();
                });
            });

            /*------------------------------------------------------------------------*/

            //identity
            builder.Services.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddDefaultTokenProviders()
                            .AddUserStore<UserStore<User, Role, AppDbContext, int>>()
                            .AddRoleStore<RoleStore<Role, AppDbContext, int>>();

            /* builder.Services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<AppDbContext>();*/

            //de 3ashan el forget password da msh me5aly ay 7ad y login ela law el confirmedemail =true
            //builder.Services.Configure<IdentityOptions>(
            //   opts => opts.SignIn.RequireConfirmedEmail = true
            //   );

            /*------------------------------------------------------------------------*/

            //this for refresh token (any generated token in database)
            builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(2));

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings.GetSection("Secret").Value);

            var googleClientId = builder.Configuration["googleOAuth:ClientId"];
            var googleClientSecret = builder.Configuration["googleOAuth:ClientSecret"];
            //this for using cookie authentication
            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Set cookie expiration time
                options.ExpireTimeSpan = TimeSpan.FromDays(7);


                options.Cookie.Name = "taalam";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Lax;// Ensure cookies are sent during redirects 

                // Configure other options as needed
            });
            /*------------------------------------------------------------------------*/

            /*------------------------------------------------------------------------*/
            // Combine JWT and Cookie Authentication
            builder.Services.AddAuthentication(options =>
            {
                // Default authentication scheme
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  ///bearer
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("jwt", options => //hna enta zawdt tareqa gededa l el authentication
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    ValidAudience = jwtSettings.GetSection("Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true
                };
            })
            .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            {
                options.ClientId = googleClientId;
                options.ClientSecret = googleClientSecret;
                options.SignInScheme = IdentityConstants.ExternalScheme;
                options.CallbackPath = new PathString("/external-login-callback");//call back 
                                                                                  //           options.CallbackPath = new PathString("/callback");//call back 
                options.Events = new OAuthEvents //de lma ta3mel login with google w law dost no f saf7et el login
                {
                    OnRemoteFailure = context =>
                    {
                        // Handle failure (e.g., redirect to an error page or return a friendly error)
                        context.Response.Redirect("/api/Account/login-failed");
                        context.HandleResponse(); // Mark the failure as handled
                        return Task.CompletedTask;
                    }
                };
            });
            //.AddFacebook(FacebookDefaults.AuthenticationScheme, options =>
            //{
            //    options.AppId = builder.Configuration["facebookOAuth:AppId"];
            //    options.AppSecret = builder.Configuration["facebookOAuth:AppSecret"];
            //    options.CallbackPath = new PathString("/external-login-callback"); // Adjust the path if necessary
            //});
            //this for adding cookie authorization  and jwt and google compination
            builder.Services.AddAuthorization(b =>
            {
                b.DefaultPolicy = new AuthorizationPolicyBuilder()
                //IdentityConstants.ApplicationScheme is the cookie authentication
                .RequireAuthenticatedUser().AddAuthenticationSchemes(IdentityConstants.ApplicationScheme, "jwt", GoogleDefaults.AuthenticationScheme).Build();
                //.RequireAuthenticatedUser().AddAuthenticationSchemes(IdentityConstants.ApplicationScheme, "jwt").Build();

            });


            var app = builder.Build();
            /*------------------------------------------------------------------------*/

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            // Serve static files
            app.UseStaticFiles();

            /* app.UseCors("MyPolicy");*/
            app.UseCors();

            QuestPDF.Settings.License = LicenseType.Enterprise;

            app.UseAuthentication(); // da be5aly el backend e2ra el cookies w el jwt token

            app.UseAuthorization(); 

            app.MapControllers();

            await app.RunAsync();
        }
    }
}