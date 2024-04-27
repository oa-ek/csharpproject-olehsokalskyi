using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Achievements;
using GameLib.Repository.Repositories.AchievementUsers;
using GameLib.Repository.Repositories.Games;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GameLib.WebUI.Controllers
{
    public class AchievementUserController : Controller
    {
        private readonly IAchievementUserRepository _achievementUserRepository;

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly UserManager<User> _userManager;
        public AchievementUserController(
            IAchievementUserRepository achievementUserRepository,
            IMapper mapper,
            IUserRepository userRepository,
            IGameRepository gameRepository,
            IAchievementRepository achievementRepository,
            UserManager<User> userManager
            )
        {
            _achievementUserRepository = achievementUserRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _achievementRepository = achievementRepository;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var achievementUsers = _mapper.Map<IEnumerable<AchievementUserViewModel>>(await _achievementUserRepository.GetAllAsync());
            return View(achievementUsers);
        }
        public async Task<IActionResult> Create(GameViewModel game)
        {
            var gamecur = await _gameRepository.GetAsync(game.Id);
            var model = new AchievementUserCreateModel
            {
                AchievementId = gamecur.Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Guid AchievementId)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var model = new AchievementUserCreateModel
                {
                    AchievementId = AchievementId
                };
                var alreadyExists = await _achievementUserRepository.AnyAsync(
                    au => au.User.Id == user.Id && au.Achievement.Id == model.AchievementId);

                var achievementUser = _mapper.Map<AchievementUser>(model);

               
                achievementUser.User = user;
                achievementUser.Date = DateTime.UtcNow;
                var achievement = await _achievementRepository.GetAsync(model.AchievementId);
                achievementUser.Achievement = achievement;

                if (alreadyExists)
                {
                    ModelState.AddModelError("", "User has already received this achievement.");
                    return RedirectToAction("Details", "Game", new { id = achievement.Game.Id });
                }

                

                await _achievementUserRepository.CreateAsync(achievementUser);
                return RedirectToAction("Details", "Game", new { id = achievement.Game.Id });
            }
            return View();
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var achievementUser = _mapper.Map<AchievementUserCreateModel>(await _achievementUserRepository.GetAsync(id));
            var users = _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllWithRolesAsync());
            var games = _mapper.Map<IEnumerable<GameLowViewModel>>(await _gameRepository.GetAllAsync());
            ViewBag.Users = users;
            ViewBag.Games = games;
            return View(achievementUser);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AchievementUserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var achievementUser = _mapper.Map<AchievementUser>(model);
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var user = await _userRepository.GetOneWithRolesAsync(currentUser.Id);

                var achievement = await _achievementRepository.GetAsync(model.AchievementId);
                achievementUser.Achievement = achievement;
                achievementUser.User = _mapper.Map<User>(user);
                await _achievementUserRepository.UpdateAsync(achievementUser);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await _achievementUserRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }



        

    }
}
