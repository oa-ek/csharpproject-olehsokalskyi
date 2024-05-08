using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Games;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib.WebUI.Areas.Identity.Pages.Account.Manage
{
    public class GameListModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IGameRepository _gameRepository;
        public GameListModel(
            UserManager<User> userManager,
            IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            _userManager = userManager;
        }
        [TempData]
        public string StatusMessage { get; set; }
 
        public List<Game> Games { get; set; }
      
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Games = await _gameRepository.GetGamesByUserIdAsync(user.Id);
            return Page();
        }
    }
}
