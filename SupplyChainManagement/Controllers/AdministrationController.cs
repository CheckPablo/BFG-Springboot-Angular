
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyChainManagement.Controllers
{
    public class AdministrationController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
 
    

        // GET: Administration/Create
        public ActionResult CreateRole()
        {
            return View();
        }

        // POST: Administration/Create
        [HttpPost]
        public async Task< ActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName,

                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            return View(model);
        }
    }
}
