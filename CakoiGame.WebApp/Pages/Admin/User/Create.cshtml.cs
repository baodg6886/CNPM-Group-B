using CakoiGame.Repositories.Entities;
using CakoiGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CakoiGame.WebApp.Pages.Admin.User
{
    public class CreateModel : PageModel
    {
        private readonly IUserSvc _userSvc;

        public CreateModel(IUserSvc userSvc)
        {
            _userSvc = userSvc;
        }

        [BindProperty]
        public QlUser Users { get; set; }
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _userSvc.CreateUserAsync(Users);
            return RedirectToPage("/Admin/User/Index");
        }
    }
}
