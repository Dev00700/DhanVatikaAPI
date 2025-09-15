using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using DevApi.Models;
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
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> AddPlot([FromBody] CommonRequestDto<PlotDto> request)
        {
            var result = await plotService.AddService(request);
            return result;
        }
    }
}