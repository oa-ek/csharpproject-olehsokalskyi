using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Games;
using GameLib.Repository.Repositories.GameTimes;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class GameTimeController : Controller
    {
        private readonly IGameTimeRepository _gameTimeRepository;
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly UserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public GameTimeController(
        IGameTimeRepository gameTimeRepository,
        IMapper mapper,
        IGameRepository gameRepository,
        UserRepository userRepository,
        UserManager<User> userManager
        )
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _gameTimeRepository = gameTimeRepository;
            _mapper = mapper;
        }
        public async  Task<IActionResult> Index()
        {
            var gameTimes = _mapper.Map<IEnumerable<GameTimeViewModel>>(await _gameTimeRepository.GetAllAsync());
            return View(gameTimes);
        }
        public async Task<IActionResult> Create(GameViewModel game)
        {
            var gamecur = await _gameRepository.GetAsync(game.Id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new GameTimeCreateModel
            {
                GameId = gamecur.Id,
                UserId = user.Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(GameTimeCreateModel model)
        {
            var game = await _gameRepository.GetAsync(model.GameId);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                var gameTime = _mapper.Map<GameTime>(model);
                gameTime.Game = game;

                gameTime.User = user;
                await _gameTimeRepository.CreateAsync(gameTime);
                return RedirectToAction("Details", "Game", new { id = model.GameId });
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var gameTime = await _gameTimeRepository.GetAsync(id);
            var model = _mapper.Map<GameTimeEditModel>(gameTime);
            var games = _mapper.Map<IEnumerable<GameLowViewModel>>(await _gameRepository.GetAllAsync());

            ViewBag.Games = games;

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(GameTimeEditModel model)
        {
            if (ModelState.IsValid)
            {
                var gameTime = _mapper.Map<GameTime>(model);
                var game = await _gameRepository.GetAsync(model.GameId);

                gameTime.Game = game;
                var user = await _userManager.GetUserAsync(HttpContext.User);
                gameTime.User = user;
                await _gameTimeRepository.UpdateAsync(gameTime);
                return RedirectToAction("Details", "Game", new { id = model.GameId });
            }
            return View(model);
        }
    }
}
