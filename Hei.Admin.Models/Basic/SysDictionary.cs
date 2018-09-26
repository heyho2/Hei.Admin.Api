using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hei.Admin.Models.Basic
{
    [Table("sys_dictionary")]
    public partial class SysDictionary : BaseModel
    {
        /// <summary>
        /// 编码
        /// </summary>
        [StringLength(50), Required]
        public string Code { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [StringLength(500), Required]
        public string Value { get; set; }
        /// <summary>
        /// 类型编码
        /// </summary>
        [StringLength(50), Required]
        public string DictionaryTypeCode { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        public int DictionaryTypeId { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序 
        /// </summary>
        public int Sort { get; set; }

    }
}
