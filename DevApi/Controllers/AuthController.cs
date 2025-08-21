using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApp.BAL;
using MyApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly LoginService loginService;

    public AuthController(IConfiguration configuration, LoginService loginService)
    {
        _configuration = configuration;
        this.loginService = loginService;   
    }

    [HttpPost("UserLogin")]
    public UserResponseDto Login([FromBody] UserReqDto userLogin)
    {
        // Validate user credentials (this should check against a database)
        var e = loginService.Login(userLogin.UserName, userLogin.Password);

        return e;
    }
    [HttpPost("EncryptD")]
    public string Encrypt([FromBody] CommonRequestDto<string> commonRequestDto)
    {
        var e = loginService.Encrypt(commonRequestDto.Data);
        return e;
    }
    [HttpPost("Decrypt")]
    public string Decrypt(string data)
    {
        var e = loginService.Decrypt(data);
        return e;
    }

}
