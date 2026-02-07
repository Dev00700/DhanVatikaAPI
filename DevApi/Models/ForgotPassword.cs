using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models.Common;
namespace DevApi.Models
{
    public class CheckEmailReqDto:BaseDto
    {
        public string Email { get; set; }
        public string? OTP { get; set; }
    
    }
    public class PasswordChange
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
