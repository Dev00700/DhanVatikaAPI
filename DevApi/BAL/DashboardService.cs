using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DevApi.BAL
{
    public class DashboardService
    {
        private readonly IConfiguration _configuration;
        public DashboardService(IConfiguration aconfiguration)
        {
            _configuration = aconfiguration;
        }

        public async Task<CommonResponseDto<List<DashboardResponseDto>>> GetListService(CommonRequestDto commonRequest)
        {
           
            var response = new CommonResponseDto<List<DashboardResponseDto>>();
            string proc = "Proc_Dashboard";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            var res = await DBHelperDapper.GetResponseModelList<DashboardResponseDto>(proc, queryParameter);
           response.Data=  res;
            return response;
        }
    }
}
