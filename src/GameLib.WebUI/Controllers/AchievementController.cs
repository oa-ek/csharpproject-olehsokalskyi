using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Achievements;
using GameLib.Repository.Repositories.Games;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class AchievementController : Controller
    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public AchievementController(
            IAchievementRepository achievementRepository,
            IGameRepository gameRepository,
            IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async  Task<IActionResult> Index()
        {
            var achievements = _mapper.Map<IEnumerable<AchievementViewModel>>(await _achievementRepository.GetAllAsync());
            return View(achievements);
        }
        public async Task<IActionResult> Create(GameViewModel game)
        {
            var gamecur = await _gameRepository.GetAsync(game.Id);
            var model = new AchievementCreateModel
            {
                GameId = gamecur.Id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AchievementCreateModel model)
        {
            var game = await _gameRepository.GetAsync(model.GameId);
            model.GameId = game.Id;
            if (ModelState.IsValid)
            {
                var achievement = _mapper.Map<Achievement>(model);
               
                achievement.Game = game;
                await _achievementRepository.CreateAsync(achievement);
                return RedirectToAction("Details", "Game", new { id = model.GameId });
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var achievement = _mapper.Map<AchievementEditModel>(await _achievementRepository.GetAsync(id));
            var games = _mapper.Map<IEnumerable<GameLowViewModel>>(await _gameRepository.GetAllAsync());

            ViewBag.Games = games;
            return View(achievement);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AchievementEditModel model, string Game)
        {
            if (ModelState.IsValid)
            {
                var achievement = _mapper.Map<Achievement>(model);
                if (Game is not null)
                {
                    var game = await _gameRepository.GetAsync(Guid.Parse(Game));
                    achievement.Game = game;
                }
              
                await _achievementRepository.UpdateAsync(achievement);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _achievementRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
