using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CakoiGame.Services.Interfaces;
using CakoiGame.Repositories.Entities;

namespace CakoiGame.WebApp.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserSvc _userSvc;

        public IndexModel(IUserSvc userSvc)
        {
            _userSvc = userSvc;
        }
        public List<QlUser> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _userSvc.GetAllUsersAsync();

        }
    }
}
