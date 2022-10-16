using Identity_Demo1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Identity_Demo1.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public Register Model { get; set; }


        public RegisterModel(UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {


        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };
    var result= await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();


        }
    }
}
        










//private readonly Microsoft.AspNet.Identity.UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;

        //public RegisterModel(Microsoft.AspNet.Identity.UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
        //{
        //    this.userManager = userManager;
        //    this.signInManager = signInManager;
        //}


