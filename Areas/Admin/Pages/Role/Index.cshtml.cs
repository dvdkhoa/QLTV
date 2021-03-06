using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;

namespace QLTV.AppMVC.Areas.Admin.Pages.Role
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : RolePageModel
    {
        public IndexModel(AppDbContext context, RoleManager<IdentityRole> roleManager) : base(context, roleManager)
        {
        }

        public List<IdentityRole> Roles { get; set; }
        public async Task OnGet()
        {
            Roles = await _roleManager.Roles.ToListAsync();
        }
    }
}
