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

        public WebController(PlotService aplotService)
        {
            plotService = aplotService;
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


        //[HttpPost("CheckCusmtomerService")]
        //public async Task<ActionResult<CommonResponseDto<List<PlotResponseDto>>>> GetHomePlotWeb([FromBody] CommonRequestDto request)
        //{
        //    var result = await plotService.GetPlotWebHomeService(request);
        //    return result;
        //}
    }
}
