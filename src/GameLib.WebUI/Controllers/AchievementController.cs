using AutoMapper;
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
        //public async Task<IActionResult> Create()
        //{
        //    var games = _mapper.Map<IEnumerable<AchievementCreateModel>>(await _gameRepository.GetAllAsync());
        //    ViewBag.Games = games;
        //    return View();
        //}
    }
}
