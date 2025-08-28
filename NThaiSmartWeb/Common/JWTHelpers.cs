using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using JWT.Serializers;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSDX.Common.Security
{
    public static class JWTHelpers
    {
        private static string DefaultSecret = EntitiesHelpers.DatabaseContext.Variables.Where(_v => _v.Name == "SSO_Key_Ndpp").Select(_v => _v.Value).FirstOrDefault() ?? "DXC2dCyPZSNJgBuObt2eehcN1JeN0KBS";
        public static string GetDefaultSecret => DefaultSecret;
        private static bool? localTokenExpired;
        private static bool? localTokenInvalid;
        private static string Secret { get; set; }
        

        public static bool TokenExpired => localTokenExpired.GetValueOrDefault(false);
        public static bool TokenInvalid => localTokenInvalid.GetValueOrDefault(false);

        public static string Encode(JObject model, string _secret = null)
        {
            JwtBuilder oJWT = JwtBuilder.Create().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(_secret ?? Secret ?? DefaultSecret);
            oJWT.AddClaims(model.ToObject<Dictionary<string, object>>());
            return oJWT.Encode();
        }
         
    }
}
