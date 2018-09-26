using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hei.Admin.Models.Basic
{
    [Table("sys_user_role")]
    public partial class SysUserRole : BaseModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Required]
        public int RoleId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public int UserId { get; set; }
    }
}
