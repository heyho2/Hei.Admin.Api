using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hei.Admin.Models.Basic
{
    [Table("t_news")]
    public partial class News : BaseModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(30),Required]
        public string Title { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [StringLength(200)]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 是否外部
        /// </summary>
        public bool IsExternal { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>
        [StringLength(200)]
        public string ExternalUrl { get; set; }
        /// <summary>
        /// 阅读数量
        /// </summary>
        public int ReadCount { get; set; }
    }
}
