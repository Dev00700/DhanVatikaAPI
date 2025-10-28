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
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly LocationService locationService;

        public LocationController(LocationService aLocationService)
        {
            locationService = aLocationService;
        }

        [HttpPost("AddLocationService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> AddLocation([FromBody] CommonRequestDto<LocationReqDto> request)
        {
            var result = await locationService.AddService(request);
            return result;
        }

        [HttpPost("UpdateLocationService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> UpdateLocation([FromBody] CommonRequestDto<LocationReqDto> request)
        {
            var result = await locationService.UpdateService(request);
            return result;
        }

        [HttpPost("GetLocationListService")]
        public async Task<ActionResult<CommonResponseDto<List<LocationResDto>>>> GetLocationList(CommonRequestDto commonRequest)
        {
            var result = await locationService.GetListService(commonRequest);
            return result;
        }

        [HttpPost("GetLocationService")]
        public async Task<ActionResult<CommonResponseDto<LocationResDto>>> GetLocation([FromBody] CommonRequestDto<LocationResDto> request)
        {
            var result = await locationService.GetLocationService(request);
            return result;
        }

    }
}