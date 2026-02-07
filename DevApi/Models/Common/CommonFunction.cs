using Dapper;
using System;
using System.Text;
using MyApp.Models.Common;
namespace MyApp.Models.Common
{
    public static class CommonFunction
    {
        public static void Printparameter(DynamicParameters pram,String logtype)
        {
            var log = new StringBuilder();
            foreach (var param in pram.ParameterNames)
            {
                var value = pram.Get<dynamic>(param);
                log.Append($"@{param} = '{value}',");
            }
            Logger.WriteLog(log.ToString(), logtype);
        }
        public static string GenerateOtp(int length = 6)
        {
            Random random = new Random();
            string otp = "";

            for (int i = 0; i < length; i++)
            {
                otp += random.Next(0, 10); // 0–9
            }

            return otp;
        }
    }
}
