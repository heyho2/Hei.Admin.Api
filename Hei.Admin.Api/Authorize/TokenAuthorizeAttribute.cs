using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hei.Admin.Api.Authorize
{
    /// <summary>
    /// 不知道咋写
    /// </summary>
    public class TokenAuthorizeAttribute : Attribute, IAuthorizeData
    {
        public string Policy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AuthenticationSchemes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
