using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;

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

        [HttpPost("GetRoleListService")]
        public ActionResult<List<UserMenuDto>> GetUserMenuList([FromBody] CommonRequestDto<DropDownReq> commonRequestDto)
        {
            DropDownReq obj = new DropDownReq();
            obj.ProcId = 1; // Assuming ProcId 1 is for Role List
            obj.ParentId = 0; // Assuming ParentId 0 is for top-level roles 
            commonRequestDto = new CommonRequestDto<DropDownReq>
            {
                Data = obj,
                UserId = commonRequestDto.UserId
            };

            var list = dropDownService.BindDropDown(commonRequestDto);
            return Ok(list);
        }
    }
}
