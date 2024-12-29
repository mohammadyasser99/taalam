using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace E_Learning.BL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum UserRoleOptions
    {
        User,
        Admin
    }
}
