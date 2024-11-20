using CakoiGame.Repositories.Entities;
using CakoiGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CakoiGame.WebApp.Pages.Admin.User
{
    public class DeleteModel : PageModel
    {
        private readonly IUserSvc _userSvc;

        public DeleteModel(IUserSvc userSvc)
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
            await _userSvc.DeleteUserAsync(itemid);
            return Page();
        }


    }
}
