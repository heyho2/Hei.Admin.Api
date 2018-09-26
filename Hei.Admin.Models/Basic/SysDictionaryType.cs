using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Models.Basic
{
    [Table("sys_dictionary_type")]
    public partial class SysDictionaryType : BaseModel
    {
        /// <summary>
        /// 类型编码
        /// </summary>
        [StringLength(50), Required]
        public string Code { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [StringLength(50), Required]
        public string Name { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(2000)]
        public string Description { get; set; }
    }
}
