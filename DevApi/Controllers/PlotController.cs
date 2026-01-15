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
        public async Task<ActionResult<CommonResponseDto<List<PlotResponseDto>>>> GetPlotList([FromBody] CommonRequestDto<PlotSerchDto> request)
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

        [HttpPost("GetPlotBookingListService")]
        public async Task<ActionResult<CommonResponseDto<List<PlotBookingListRespDto>>>> PlotBookingGetListService([FromBody] CommonRequestDto<PlotBookingListReqDto> request)
        {
            var result = await plotService.PlotBookingListService(request);
            return result;
        }
        [HttpPost("GetPlotBookingService")]
        public  ActionResult<CommonResponseDto<PlotBookingResponseDto>> PlotBookingGetService([FromBody] CommonRequestDto<PlotBookingListReqDto> request)
        {
            var result =  plotService.PlotBookingService(request);
            return result;
        }
        [HttpPost("UpdatePlotStatusService")]
        public async Task< ActionResult<CommonResponseDto<ValidationMessageDto>>> PlotStatusUpdate([FromBody] CommonRequestDto<PlotStatusUpdateDto> request)
        {
            var result = await plotService.PlotStatusUpdateService(request);
            return result;
        }
    }
}