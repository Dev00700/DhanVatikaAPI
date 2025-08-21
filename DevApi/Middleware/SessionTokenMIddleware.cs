using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Models.Common;
using System.IdentityModel.Tokens.Jwt;

public class SessionValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;

    public SessionValidationMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token))
        {
            await _next(context);
            return;
        }
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        var tokenJti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;


        //using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        //await conn.OpenAsync();

        //var cmd = new SqlCommand(@"
        //    SELECT u.UserId, c.IsSingleUser, u.SessionToken
        //    FROM Users u
        //    JOIN UM_MCompany c ON u.CompanyId = c.CompanyId
        //    WHERE u.SessionToken = @Token", conn);

        var mCompanyId = _config.GetValue<long>("CompanyDetail:ID");

     //   string _proc = "Proc_Login";
     //   var queryparameter = new DynamicParameters();
     //   queryparameter.Add("@ProcId", 3);
     //   queryparameter.Add("@MCompanyID", mCompanyId);
     //   queryparameter.Add("@UserId", userId);
     //var   res = DBHelperDapper.GetAddRespinseModel<UserResponseDto>(_proc, queryparameter);

        //if(res==null)
        //{
        //    context.Response.StatusCode = 401;
        //    await context.Response.WriteAsync("Invalid or expired session.");
        //    return;
        //}

     

        //cmd.Parameters.AddWithValue("@Token", Guid.Parse(token));

        //using var reader = await cmd.ExecuteReaderAsync();
        //if (!reader.Read())
        //{
        //    context.Response.StatusCode = 401;
        //    await context.Response.WriteAsync("Invalid or expired session.");
        //    return;
        //}

        //var isSingleUser = (bool)reader["IsSingleUser"];
        //var dbToken = reader["SessionToken"].ToString();

        //if (isSingleUser && dbToken != token)
        //{
        //    context.Response.StatusCode = 401;
        //    await context.Response.WriteAsync("Session expired due to another login.");
        //    return;
        //}

        await _next(context);
    }
}
