using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class PlotService
    {
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<PlotDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            var data = commonRequest.Data;
          
            queryParameter.Add("@PlotName", data.PlotName);
            queryParameter.Add("@Description", data.Description);
            queryParameter.Add("@LocationId", data.LocationId);
            queryParameter.Add("@Address", data.Address);
            queryParameter.Add("@Latitude", data.Latitude);
            queryParameter.Add("@Longitude", data.Longitude);
            queryParameter.Add("@AreaSize", data.AreaSize);
            queryParameter.Add("@UnitTypeId", data.UnitTypeId);
            queryParameter.Add("@Price", data.Price);
            queryParameter.Add("@Status", data.Status);
            queryParameter.Add("@Facing", data.Facing);
            queryParameter.Add("@PlotType", data.PlotType);
            queryParameter.Add("@NearbyLandmarks", data.NearbyLandmarks);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);
            queryParameter.Add("@Remarks", data.Remarks);

            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}