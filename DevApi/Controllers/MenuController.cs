using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly MenuService menuService;

        public MenuController(MenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpPost("GetUserMenuListService")]
        public async Task<ActionResult<List<UserMenuDto>>> GetUserMenuList([FromBody] CommonRequestDto<UserMenuReq> commonRequestDto)
        {
            var list =await menuService.GetUserMenuList(commonRequestDto);
            return Ok(list);
        }
        [HttpPost("GetMenuListService")]
        public async Task<ActionResult<List<UserMenuDto>>> GetMenuList([FromBody] CommonRequestDto commonRequestDto)
        {
            var list =await menuService.GetMenuList(commonRequestDto);
            return Ok(list);
        }
        [HttpPost("AddMenuService")]
        public async Task<ActionResult<List<UserMenuDto>>> MenuAddService([FromBody] CommonRequestDto<List<UserMenuAddReq>> commonRequestDto)
        {
            var list =await menuService.AddService(commonRequestDto);
            return Ok(list);
        }
    }
}