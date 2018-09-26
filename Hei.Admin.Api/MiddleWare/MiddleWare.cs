using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hei.Admin.Api.MiddleWare
{
    public abstract class MiddleWare
    {
        internal RequestDelegate Next { get; }

        public MiddleWare(RequestDelegate next)
        {
            Next = next;
        }
        public abstract Task Invoke(HttpContext context);
    }
}
