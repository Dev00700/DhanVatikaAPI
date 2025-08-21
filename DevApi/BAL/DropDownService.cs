using Azure;
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
    public  class DropDownService
    {
        public CommonResponseDto<  List<DropDownDto>> BindDropDown(CommonRequestDto<DropDownReq> commonRequest)
        {
            var response = new CommonResponseDto<List<DropDownDto>>();
            string _proc = "Proc_BindDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", commonRequest.Data.ProcId);
            queryparameter.Add("@ParentId", commonRequest.Data.ParentId);
           var res = DBHelperDapper.GetResponseModelList<DropDownDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
