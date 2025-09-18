using DevApi.BAL;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService dashboardservice;

        public DashboardController(DashboardService adashboardservice)
        {
            dashboardservice = adashboardservice;
        }

        [HttpPost("GetDashboardListService")]
        public async Task<ActionResult<CommonResponseDto<List<DashboardResponseDto>>>> GetListDashboard(CommonRequestDto commonRequest)
        {
            var payments = await dashboardservice.GetListService(commonRequest);
            return payments;
        }
    }
}
