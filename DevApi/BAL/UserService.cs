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
    public static class UserService
    {
        public static CommonResponseDto<List<UserDto>> GetUserList()
        {
            var response = new CommonResponseDto<List<UserDto>>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            var res = DBHelperDapper.GetResponseModelList<UserDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public static CommonResponseDto<ValidationMessageDto> SaveUser(UserDto user)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserCode", user.UserCode);
            queryparameter.Add("@UserName", user.UserName);
            queryparameter.Add("@Email", user.Email);
            queryparameter.Add("@Mobile", user.MobileNo);
            queryparameter.Add("@password", Crypto.Encrypt(user.Password));
            queryparameter.Add("@IsActive", user.IsActive);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "User paramer for saving:");//FOR WRITE LOG'
            var res = DBHelperDapper.GetAddRespinseModel<ValidationMessageDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = res != null ? res.Flag : 0;
            response.Message = res != null ? res.Message : "Failed to save user.";
            return response;
        }

        public static CommonResponseDto<UserDto> GetUser(string userguid)
        {
            var response = new CommonResponseDto<UserDto>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 3);
            queryparameter.Add("@UserGuid", userguid);
            CommonFunction.Printparameter(queryparameter, "Get User:");//FOR WRITE LOG'
            var res = DBHelperDapper.GetAddRespinseModel<UserDto>(_proc, queryparameter);
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

        public static CommonResponseDto<ValidationMessageDto> UpdateUser(UserDto user)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@UserCode", user.UserCode);
            queryparameter.Add("@UserName", user.UserName);
            queryparameter.Add("@Email", user.Email);
            queryparameter.Add("@Mobile", user.MobileNo);
            queryparameter.Add("@password", user.Password);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            queryparameter.Add("@IsActive", user.IsActive);
            queryparameter.Add("@UserGuid", user.UserGuid);
            CommonFunction.Printparameter(queryparameter, "User paramer for updating:");//FOR WRITE LOG'
            var res = DBHelperDapper.GetAddRespinseModel<ValidationMessageDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = res != null ? res.Flag : 0;
            response.Message = res != null ? "User updated successfully." : "Failed to update user.";
            return response;
        }
    }
}
