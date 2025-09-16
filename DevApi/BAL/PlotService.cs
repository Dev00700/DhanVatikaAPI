using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
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

        public async Task<CommonResponseDto<List<ValidationMessageDto>>> AddImagesService(CommonRequestDto<List<PlotImageDto>> commonRequest)
        {
            var response = new CommonResponseDto<List<ValidationMessageDto>>
            {
                Data = new List<ValidationMessageDto>()
            };

            string proc = "Proc_PlotImage";

            foreach (var image in commonRequest.Data)
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@ProcId", 1); // 1 for insert
                queryParameter.Add("@PlotId", image.PlotId);
                queryParameter.Add("@Image", image.Image);
                queryParameter.Add("@IsActive", image.IsActive);
                queryParameter.Add("@DelMark", image.DelMark);
                queryParameter.Add("@Remarks", image.Remarks);

                var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
                response.Data.Add(res);
            }

            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdateService(CommonRequestDto<PlotDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;

            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@PlotGuid", data.PlotGuid);
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

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<PlotResponseDto>>> GetListService(CommonRequestDto commonRequest)
        {
          
            var response = new CommonResponseDto<List<PlotResponseDto>>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<PlotResponseDto>(proc, queryParameter);
          
            return res;
        }
        public  CommonResponseDto<PlotResponseDto> GetPlotService(CommonRequestDto<PlotReqDto> commonRequest)
        {
            var response = new CommonResponseDto<PlotResponseDto>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@PlotGuid", data.PlotGuid);
            var res = DBHelperDapper.GetResponseModel<PlotResponseDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}