using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Models.Business
{
    [Table("t_advertising_image")]
    public partial class AdvertisingImage : BaseModel
    {
        /// <summary>
        /// Url
        /// </summary>
        [StringLength(500)]
        public string Url { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public short Type { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public enum TypeEnum
        {
            /// <summary>
            /// 登陆
            /// </summary>
            [Description("首页")]
            Home = 1
        }
    }
}
