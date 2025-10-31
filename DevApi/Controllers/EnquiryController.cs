using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using DevApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class EnquiryController : ControllerBase
    {
        private readonly EnquiryService enquiryService;

        public EnquiryController(EnquiryService aEnquiryService)
        {
            enquiryService = aEnquiryService;
        }

        [HttpPost("AddEnquiryService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> AddEnquiry([FromBody] CommonRequestDto<EnquiryReqDto> request)
        {
            var result = await enquiryService.AddService(request);
            return result;
        }
        [Authorize]
        [HttpPost("CloseEnquiryService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> CloseEnquiry([FromBody] CommonRequestDto<EnquiryClosedDto> request)
        {
            var result = await enquiryService.CloseService(request);
            return result;
        }
        [Authorize]
        [HttpPost("GetEnquiryListService")]
        public async Task<ActionResult<CommonResponseDto<List<EnquiryResDto>>>> GetEnquiryList(CommonRequestDto commonRequest)
        {
            var result = await enquiryService.GetListService(commonRequest);
            return result;
        }
    }
}