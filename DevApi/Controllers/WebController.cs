using DevApi.Models.Common;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using DevApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebController : Controller
    {
        private readonly PlotService plotService;
    private readonly CustomerService customerService;

        public WebController(PlotService aplotService, CustomerService customerService)
        {
            plotService = aplotService;
            this.customerService = customerService;
        }

        [HttpPost("GetLocationListService")]
        public async Task<ActionResult<CommonResponseDto<List<LocationDto>>>> GetLocationList([FromBody] CommonRequestDto request)
        {
            var result = await plotService.GetLocationListService(request);
            return result;
        }
        [HttpPost("GetPlotWebListService")]
        public async Task<ActionResult<CommonResponseDto<List<PlotWebResponseDto>>>> GetPlotWebList([FromBody] CommonRequestDto<PtotWebReq> request)
        {
            var result = await plotService.GetPlotWebListService(request);
            return result;
        }

        [HttpPost("GetPlotWebService")]
        public ActionResult<CommonResponseDto<PlotResponseDto>> GetPlotWeb([FromBody] CommonRequestDto<PtotWebReq> request)
        {
            var result = plotService.GetPlotWebService(request);
            return result;
        }
        [HttpPost("GetPlotWebHomeService")]
        public async Task<ActionResult<CommonResponseDto<List<PlotResponseDto>>>> GetHomePlotWeb([FromBody] CommonRequestDto request)
        {
            var result = await plotService.GetPlotWebHomeService(request);
            return result;
        }


        [HttpPost("CheckCusmtomerEmailService")]
        public ActionResult<CommonResponseDto<ValidationMessagePasswordDto>> CheckEmailCusmtomerService([FromBody] CommonRequestDto<CheckEmailReqDto> request)
        {
            var result =  customerService.CheckCustomerEmail(request);
            return result;
        }

        [HttpPost("ValidateOtpService")]
        public ActionResult<CommonResponseDto<ValidationMessagePasswordDto>> OtpValidateService([FromBody] CommonRequestDto<CheckEmailReqDto> request)
        {
            var result = customerService.OtpValidateSerivce(request);
            return result;
        }

        [HttpPost("PasswordChangeService")]
        public ActionResult<CommonResponseDto<ValidationMessagePasswordDto>> ChangePasswordService([FromBody] CommonRequestDto<PasswordChange> request)
        {
            var result = customerService.PasswordChange(request);
            return result;
        }
    }
}
