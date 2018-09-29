using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Models.Basic
{
    [Table("sys_menu_role")]
    public partial class SysMenuRole : BaseModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Required]
        public int RoleId { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Required]
        public int MenuId { get; set; }
    } 
}
