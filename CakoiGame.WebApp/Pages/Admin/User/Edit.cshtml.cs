using CakoiGame.Repositories.Entities;
using CakoiGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CakoiGame.WebApp.Pages.Admin.User
{
    public class EditModel : PageModel
    {
        private readonly IUserSvc _userSvc;

        public EditModel(IUserSvc userSvc)
        {
            _userSvc = userSvc;
        }

        [BindProperty]
        public QlUser Users { get; set; }
        public async Task<IActionResult> OnGetAsync(int itemid)
        {
            Users = await _userSvc.GetAllUserByIdAsync(itemid);
            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _userSvc.EditUserAsync(Users);
            return RedirectToPage("/Admin/User/Index");
        }
    }
}
