using Dapper;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public  class UserService
    {
        public async Task<CommonResponseDto<List<UserDto>>> GetListService(CommonRequestDto<UserDto> request)
        {
            var response = new CommonResponseDto<List<UserDto>>( );
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 3);
            queryparameter.Add("@UserCode", request.Data.UserCode);
            queryparameter.Add("@UserName", request.Data.UserName);
            queryparameter.Add("@Email", request.Data.Email);
            queryparameter.Add("@MobileNo", request.Data.MobileNo);
            queryparameter.Add("@PageNumber", request.PageSize);
            queryparameter.Add("@PageRecordCount", request.PageRecordCount);
            var res =await DBHelperDapper.GetPagedModelList<UserDto>(_proc, queryparameter);
            return res;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<UserDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserName", commonRequest.Data.UserName);
            queryparameter.Add("@UserCode", commonRequest.Data.UserCode);
            queryparameter.Add("@Email", commonRequest.Data.Email);
            queryparameter.Add("@MobileNo", commonRequest.Data.MobileNo);
            queryparameter.Add("@RoleId", commonRequest.Data.RoleId);
            queryparameter.Add("@password", Crypto.Encrypt(commonRequest.Data.Password));
            queryparameter.Add("@IsActive", commonRequest.Data.IsActive);
            queryparameter.Add("@Remarks", commonRequest.Data.Remarks);
            queryparameter.Add("@createdBy", commonRequest.UserId);
            CommonFunction.Printparameter(queryparameter, "User paramer for saving:");//FOR WRITE LOG'
            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = res != null ? res.Flag : 0;
            response.Message = res != null ? res.Message : "Failed to save user.";
            return response;
        }

        public async Task<CommonResponseDto<UserDto>> GetUser(CommonRequestDto<UserReqDto> commonRequest)
        {
            var response = new CommonResponseDto<UserDto>();
            string _proc = "Proc_userForEdit";
            var queryparameter = new DynamicParameters();
            //queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@UserGuid", commonRequest.Data.UserGuid);
            CommonFunction.Printparameter(queryparameter, "Get User:");//FOR WRITE LOG'
            var res =await DBHelperDapper.GetAddResponseModel<UserDto>(_proc, queryparameter);
            if (res != null)
            {
                res.Password = Crypto.Decrypt(res.Password);
                response.Data = res;
                response.Flag = 1;
                response.Message = "Success";
            }
            else
            {
                response.Data = null;
                response.Flag = 0;
                response.Message = "User not found.";
            }
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdateService(CommonRequestDto<UserDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            queryparameter.Add("@UserName", commonRequest.Data.UserName);
            queryparameter.Add("@UserCode", commonRequest.Data.UserCode);
            queryparameter.Add("@Email", commonRequest.Data.Email);
            queryparameter.Add("@MobileNo", commonRequest.Data.MobileNo);
            queryparameter.Add("@password", Crypto.Encrypt(commonRequest.Data.Password));
            queryparameter.Add("@RoleId", commonRequest.Data.RoleId);
            queryparameter.Add("@createdBy", commonRequest.Data.UserId);
            queryparameter.Add("@IsActive", commonRequest.Data.IsActive);
            queryparameter.Add("@Remarks", commonRequest.Data.Remarks);
            queryparameter.Add("@UserGuid", commonRequest.Data.UserGuid);
            CommonFunction.Printparameter(queryparameter, "User paramer for updating:");//FOR WRITE LOG'
            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = res != null ? res.Flag : 0;
            response.Message = res != null ? "User updated successfully." : "Failed to update user.";
            return response;
        }
    }
}
