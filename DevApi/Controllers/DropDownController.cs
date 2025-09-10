using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DropDownController : ControllerBase
    {
        private readonly DropDownService dropDownService;

        public DropDownController(DropDownService adropDownService)
        {
            this.dropDownService = adropDownService;
        }

        [HttpPost("GetDropdownListService")]
        public async Task<ActionResult<CommonResponseDto<List<DropDownDto>>>> GetUserMenuList([FromBody] CommonRequestDto<DropDownReq> commonRequestDto)
        {
            DropDownReq obj = new DropDownReq();
            if (commonRequestDto.Data.SearchDDL == "Role")
            {
                obj.ProcId = 1; // Assuming ProcId 1 is for Role List
                obj.ParentId = 0; // Assuming ParentId 0 is for top-level roles 
            }
            else if (commonRequestDto.Data.SearchDDL == "PaymentMode")
            {
                obj.ProcId = 2; 
                obj.ParentId = 0; 
            }
            else if (commonRequestDto.Data.SearchDDL == "PaymentSource")
            {
                obj.ProcId = 3; 
                obj.ParentId = 0; 
            }

            commonRequestDto = new CommonRequestDto<DropDownReq>
                {
                    Data = obj,
                    UserId = commonRequestDto.UserId
                };

            var list =await dropDownService.BindDropDown(commonRequestDto);
            return list;
        }
    }
}
