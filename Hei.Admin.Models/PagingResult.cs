using System;
using System.Collections.Generic;
using System.Text;

namespace Hei.Admin.Models
{
    public class PagingResult<TResult>
    {
        public List<TResult> Items { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
    }
}
