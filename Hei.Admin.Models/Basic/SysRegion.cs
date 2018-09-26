using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Models.Basic
{
    [Table("sys_region")]
    public partial class SysRegion : BaseModel
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        [StringLength(50), Required]
        public string Name { get; set; }

        /// <summary>
        /// 区域行政代码
        /// </summary>
        public long Code { get; set; }

        /// <summary>
        /// 上级地区
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 地区层级
        /// </summary>
        public short Level { get; set; }

        public enum LevelEnum
        {
            /// <summary>
            /// 省
            /// </summary>
            Province = 1,

            /// <summary>
            /// 市
            /// </summary>
            City = 2,

            /// <summary>
            /// 区/县
            /// </summary>
            District = 3,

            /// <summary>
            /// 镇/乡
            /// </summary>
            Town = 4
        }
    }
}
