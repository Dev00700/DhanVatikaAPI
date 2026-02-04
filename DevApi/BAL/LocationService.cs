using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class LocationService
    {
        private readonly IConfiguration _configuration;
        public LocationService(IConfiguration aconfiguration)
        {
            _configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<LocationReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Location";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1); // 1 for insert
            queryParameter.Add("@LocationName", commonRequest.Data.LocationName);
            queryParameter.Add("@Image", commonRequest.Data.Image);
            queryParameter.Add("@Remarks", commonRequest.Data.Remarks);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdateService(CommonRequestDto<LocationReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Location";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 2); // 2 for update
            queryParameter.Add("@LocationGuid", commonRequest.Data.LocationGuid);
            queryParameter.Add("@LocationName", commonRequest.Data.LocationName);
            queryParameter.Add("@Image", commonRequest.Data.Image);
            queryParameter.Add("@IsActive", commonRequest.Data.IsActive);
            queryParameter.Add("@Remarks", commonRequest.Data.Remarks);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<LocationResDto>>> GetListService(CommonRequestDto <LocationResDto> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<List<LocationResDto>>();
            string proc = "Proc_Location";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3); // 3 for list
            queryParameter.Add("@LocationName", commonRequest.Data.LocationName);
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<LocationResDto>(proc, queryParameter);
            res.Data.ForEach(x => x.Image = x.Image != "" ? imageurl + x.Image : "");
          
            return res;
        }

        public async Task<CommonResponseDto<LocationResDto>> GetLocationService(CommonRequestDto<LocationResDto> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<LocationResDto>();
            string proc = "proc_GetLocation";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 4); // 4 for get single
            queryParameter.Add("@LocationGuid", commonRequest.Data.LocationGuid);

            var res =  DBHelperDapper.GetResponseModel<LocationResDto>(proc, queryParameter);
            if (res != null && !string.IsNullOrEmpty(res.Image))
            {
                res.ImageUrl = $"{imageurl}{res.Image}";
            }
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}