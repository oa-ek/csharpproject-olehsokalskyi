using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Achievements;
using GameLib.Repository.Repositories.Developers;
using GameLib.Repository.Repositories.Games;
using GameLib.Repository.Repositories.Genres;
using GameLib.Repository.Repositories.Languages;
using GameLib.Repository.Repositories.Platforms;
using GameLib.Repository.Repositories.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public GameController(
            IGenreRepository genreRepository,
            IGameRepository gameRepository,
            IAchievementRepository achievementRepository,
            IDeveloperRepository developerRepository,
            IPublisherRepository publisherRepository,
            IPlatformRepository platformRepository,
            ILanguageRepository languageRepository,
            IMapper mapper)
        {
            _genreRepository = genreRepository;
            _gameRepository = gameRepository;
            _achievementRepository = achievementRepository;
            _developerRepository = developerRepository;
            _publisherRepository = publisherRepository;
            _platformRepository = platformRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var games = _mapper.Map<IEnumerable<GameViewModel>>(_gameRepository.GetAllAsync());
            return View(games);
        }
        public async Task<IActionResult> Create()
        {
            var developers = _mapper.Map<IEnumerable<DeveloperViewModel>>(await _developerRepository.GetAllAsync());
            var publishers = _mapper.Map<IEnumerable<PublisherViewModel>>(await _publisherRepository.GetAllAsync());
            var platforms = _mapper.Map<IEnumerable<PlatformViewModel>>(await _platformRepository.GetAllAsync());
            var languages = _mapper.Map<IEnumerable<LanguageViewModel>>(await _languageRepository.GetAllAsync());
            ViewBag.Developers = developers;
            ViewBag.Publishers = publishers;
            ViewBag.Platforms = platforms;
            ViewBag.Languages = languages;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var game = _mapper.Map<Game>(model);
                foreach (var genreId in model.Genres)
                {
                    var genre = await _genreRepository.GetAsync(genreId.Id);
                    game.Genres.Add(genre);
                }
                foreach (var achievementId in model.Achievements)
                {
                    var achievement = await _achievementRepository.GetAsync(achievementId.Id);
                    game.Achievements.Add(achievement);
                }
                foreach (var developerId in model.Developers)
                {
                    var developer = await _developerRepository.GetAsync(developerId.Id);
                    game.Developers.Add(developer);
                }


                var publisher = await _publisherRepository.GetAsync(model.Publisher.Id);
                var platform = await _platformRepository.GetAsync(model.PlatformId);
                var language = await _languageRepository.GetAsync(model.LanguageId);
                game.Developer = developer;
                game.Publisher = publisher;
                game.Platform = platform;
                game.Language = language;
                await _gameRepository.CreateAsync(game);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
