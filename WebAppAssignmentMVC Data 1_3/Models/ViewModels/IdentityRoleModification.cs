using System.ComponentModel.DataAnnotations;
 
namespace WebAppAssignmentMVC_Data_1_3.Models.ViewModels
{
    public class IdentityRoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}