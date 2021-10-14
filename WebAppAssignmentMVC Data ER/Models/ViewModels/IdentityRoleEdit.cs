using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebAppAssignmentMVC_Data_ER.Models.ViewModels
{
    public class IdentityRoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityAppUsers> Members { get; set; }
        public IEnumerable<IdentityAppUsers> NonMembers { get; set; }
    }
}