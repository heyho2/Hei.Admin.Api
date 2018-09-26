using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hei.Admin.Models.Basic
{
    [Table("t_product_attr")]
    public partial class ProductAttr : BaseModel
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        [StringLength(30), Required]
        public string Name { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        [StringLength(30), Required]
        public string Value { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductTypeId { get; set; }
    }
}
