using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Common
{
    public class DropDownDto
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class DropDownReq
    {
        public int? ProcId { get; set; }
        public int? ParentId { get; set; }
    }
}
