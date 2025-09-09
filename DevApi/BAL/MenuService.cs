using Azure.Core;
using Dapper;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class MenuService
    {


        public async Task<CommonResponseDto<List<UserMenuDto>>> GetUserMenuList(CommonRequestDto<UserMenuReq> commonRequest)
        {
            var response = new CommonResponseDto<List<UserMenuDto>>();
            string proc = "Proc_Menu";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@userId", commonRequest.UserId);
            var res =await DBHelperDapper.GetResponseModelList<UserMenuDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto< List<MenuDto>>> GetMenuList(CommonRequestDto commonRequest)
        {
            var response = new CommonResponseDto<List<MenuDto>>();
            string proc = "Proc_Menu";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 3);
            var res =await DBHelperDapper.GetResponseModelList<MenuDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public async Task<CommonResponseDto< ValidationMessageDto>> AddService(CommonRequestDto<List<UserMenuAddReq>> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Menu";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@UserMenuJson",
              Newtonsoft.Json.JsonConvert.SerializeObject(commonRequest.Data));
            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public async Task<CommonResponseDto<List<UserMenuDto>>> UserMenuUpdateService(CommonRequestDto<UserMenuReq> commonRequest)
        {
            var response = new CommonResponseDto<List<UserMenuDto>>();
            string proc = "Proc_Menu";
            var queryParameter = new DynamicParameters();
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@userId", commonRequest.UserId);
            var res =await DBHelperDapper.GetResponseModelList<UserMenuDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
