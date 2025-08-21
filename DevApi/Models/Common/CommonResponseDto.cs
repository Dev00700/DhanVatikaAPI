using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevApi.Models.Common
{
    public class CommonResponseDto<T>
    {
        public int? CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public int? TotalRecordCount { get; set; }
        public T Data { get; set; } // Can hold any DTO or list of DTOs
        public int Flag { get; set; }
        public string Message { get; set; }

    }
    public class PageInfoDto
    {
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public int? TotalRecordCount { get; set; }

    }
}
