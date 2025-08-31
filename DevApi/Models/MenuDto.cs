using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class MenuDto : BaseDto
    {
        public long MenuId { get; set; }
        public Guid MenuGuid { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public string ParentName { get; set; }

    }

    public class UserMenuDto 
    {
        public Guid MenuGuid { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }    
        public string  MenuCode { get; set; }
        public int ParentId { get; set; }   
        public bool? Checked { get; set; }
    }
    public class UserMenuReq
    {
        public int UserId { get; set; }
    }
    public class UserMenuAddReq 
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public bool IsActive { get; set; }

    }
}
