using Azure;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlotController : ControllerBase
    {
        private readonly PlotService plotService;

        public PlotController(PlotService aPlotService)
        {
            plotService = aPlotService;
        }

        [HttpPost("AddPlotService")]
        public async Task<ActionResult<CommonResponseDto<plotAddResDto>>> AddPlot([FromBody] CommonRequestDto<PlotDto> request)
        {
            var result = await plotService.AddService(request);
            return result;
        }

        [HttpPost("AddPlotImagesService")]
        public async Task<ActionResult<CommonResponseDto<List<ValidationMessageDto>>>> AddPlotImages([FromBody] CommonRequestDto<List<PlotImageDto>> request)
        {
            var result = await plotService.AddImagesService(request);
            return result;
        }
        [HttpPost("UpdatePlotService")]
        public async Task<ActionResult<CommonResponseDto<plotAddResDto>>> UpdatePlot([FromBody] CommonRequestDto<PlotDto> request)
        {
            var result = await plotService.UpdateService(request);
            return result;
        }

        [HttpPost("GetPlotListService")]
        public async Task<ActionResult<CommonResponseDto<List<PlotResponseDto>>>> GetPlotList([FromBody] CommonRequestDto request)
        {
            var result = await plotService.GetListService(request);
            return result;
        }
        [HttpPost("GetPlotService")]
        public ActionResult<CommonResponseDto<PlotResponseDto>> GetPlot([FromBody] CommonRequestDto<PlotReqDto> request)
        {
            var result =  plotService.GetPlotService(request);
            return result;
        }
        [HttpPost("AddPlotBookingService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> AddPlotBooking([FromBody] CommonRequestDto<PlotBookingReqDto> request)
        {
            var result = await plotService.AddPlotBookingService(request);
            return result;
        }

        [HttpPost("UpdatePlotBookingService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> UpdatePlotBooking([FromBody] CommonRequestDto<PlotBookingReqDto> request)
        {
            var result = await plotService.UpdatePlotBookingService(request);
            return result;
        }

        [HttpPost("DeletePlotImagesService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> DeletePlotImages([FromBody] CommonRequestDto<PlotImageDeleteDto> request)
        {
            var result = await plotService.DeletePLotImagesService(request);
            return result;
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
        public  ActionResult<CommonResponseDto<PlotResponseDto>> GetPlotWeb([FromBody] CommonRequestDto<PtotWebReq> request)
        {
            var result =  plotService.GetPlotWebService(request);
            return result;
        }
        [HttpPost("GetPlotWebHomeService")]
        public async Task<ActionResult<CommonResponseDto<List<PlotResponseDto>>>> GetHomePlotWeb([FromBody] CommonRequestDto request)
        {
            var result =await plotService.GetPlotWebHomeService(request);
            return result;
        }
    }
}