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
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using static System.Collections.Specialized.BitVector32;

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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        
        private readonly IMapper _mapper;
        public GameController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IGenreRepository genreRepository,
            IGameRepository gameRepository,
            IAchievementRepository achievementRepository,
            IDeveloperRepository developerRepository,
            IPublisherRepository publisherRepository,
            IPlatformRepository platformRepository,
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _genreRepository = genreRepository;
            _gameRepository = gameRepository;
            _achievementRepository = achievementRepository;
            _developerRepository = developerRepository;
            _publisherRepository = publisherRepository;
            _platformRepository = platformRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var games = _mapper.Map<IEnumerable<GameViewModel>>(await _gameRepository.GetAllAsync());
            return View(games);
        }
        public async Task<IActionResult> Create()
        {
            var developers = _mapper.Map<IEnumerable<DeveloperViewModel>>(await _developerRepository.GetAllAsync());
            var publishers = _mapper.Map<IEnumerable<PublisherViewModel>>(await _publisherRepository.GetAllAsync());
            var languages = _mapper.Map<IEnumerable<LanguageViewModel>>(await _languageRepository.GetAllAsync());
            var genres = _mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepository.GetAllAsync());
            var platfomrs = _mapper.Map<IEnumerable<PlatformViewModel>>(await _platformRepository.GetAllAsync());

            ViewBag.Platforms = platfomrs;
            ViewBag.Languages = languages;
            ViewBag.Genres = genres;
            ViewBag.Publishers = publishers;
            ViewBag.Developers = developers;

            return View(new GameCreateModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            GameCreateModel model,
            string[] Developers,
            string[] Platforms,
            string[] Languages,
            string[] Genres,
            string Publisher
            )
        {
            Console.Write(model.Title, "\n\n\n");
            if (ModelState.IsValid)
            {

                var game = _mapper.Map<Game>(model);
                foreach (var genreId in model.Genres)
                {
                    var genre = await _genreRepository.GetAsync(genreId.Id);
                    game.Genres.Add(genre);
                }
                foreach (var developerId in Developers)
                {
                    if (developerId.Count() > 0)
                    {
                        game.Developers.Add(await _developerRepository.GetAsync(Guid.Parse(developerId)));
                    }
                }
                foreach (var platformId in Platforms)
                {
                    if (platformId.Count() > 0)
                    {
                        game.Platforms.Add(await _platformRepository.GetAsync(Guid.Parse(platformId)));
                    }

                }
                foreach (var languageId in Languages)
                {
                    if (languageId.Count() > 0)
                    {
                        game.Languages.Add(await _languageRepository.GetAsync(Guid.Parse(languageId)));
                    }
                }
                foreach (var genresId in Genres)
                {
                    if (genresId.Count() > 0)
                    {
                        game.Genres.Add(await _genreRepository.GetAsync(Guid.Parse(genresId)));
                    }
                }
                var publisher = await _publisherRepository.GetAsync(Guid.Parse(Publisher));
                game.Publisher = publisher;
                string url = model.Trailer;
                Uri uri = new Uri(url);
                string result = uri.PathAndQuery.Substring(1);
                game.Trailer = result;

                if (model.Image is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var fileExt = Path.GetExtension(model.Image.FileName);
                    var filePath = Path.Combine("/data/img/", $"{game.Id}{fileExt}");
                    string path = Path.Combine(wwwRootPath, "data\\img\\", $"{game.Id}{fileExt}");

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }

                    game.Image = filePath;
                }
                await _gameRepository.CreateAsync(game);
                return View("Index");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(p => p.ErrorMessage)).ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var game = _mapper.Map<GameViewModel>(await _gameRepository.GetAsync(id));
            return View(game);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var game = _mapper.Map<GameEditModel>(await _gameRepository.GetAsync(id));
            var developers = _mapper.Map<IEnumerable<DeveloperViewModel>>(await _developerRepository.GetAllAsync());
            var publishers = _mapper.Map<IEnumerable<PublisherViewModel>>(await _publisherRepository.GetAllAsync());
            ViewBag.Publishers = publishers;
            var platforms = _mapper.Map<IEnumerable<PlatformViewModel>>(await _platformRepository.GetAllAsync());
            var languages = _mapper.Map<IEnumerable<LanguageViewModel>>(await _languageRepository.GetAllAsync());
            var genres = _mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepository.GetAllAsync());
            ViewBag.Genres = genres;
            ViewBag.Developers = developers;
            ViewBag.Platforms = platforms;
            ViewBag.Languages = languages;
            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(
            GameEditModel model,
            string[] Developers,
            string[] Platforms,
            string[] Languages,
            string[] Genres,
            string Publisher)
        {
            if (ModelState.IsValid)
            {

                var game = await _gameRepository.GetAsync(model.Id);

                game.Title = model.Title;
                game.Description = model.Description;
                game.Price = model.Price;
                game.ReleaseDate = model.ReleaseDate;
                if (Developers.Count() != 0)
                {
                    game.Developers.Clear();
                    foreach (var developerId in Developers)
                    {
                        if (developerId.Count() > 0)
                        {
                            game.Developers.Add(await _developerRepository.GetAsync(Guid.Parse(developerId)));
                        }
                    }
                }
                if (Languages.Count() != 0)
                {
                    game.Languages.Clear();
                    foreach (var languageId in Languages)
                    {
                        if (languageId.Count() > 0)
                        {
                            game.Languages.Add(await _languageRepository.GetAsync(Guid.Parse(languageId)));
                        }
                    }
                }
                if (Genres.Count() != 0)
                {
                    game.Genres.Clear();
                    foreach (var genresId in Genres)
                    {
                        if (genresId.Count() > 0)
                        {
                            game.Genres.Add(await _genreRepository.GetAsync(Guid.Parse(genresId)));
                        }
                    }
                }
                if (Platforms.Count() != 0)
                {
                    game.Platforms.Clear();

                    foreach (var platformId in Platforms)
                    {
                        if (platformId.Count() > 0)
                        {
                            game.Platforms.Add(await _platformRepository.GetAsync(Guid.Parse(platformId)));
                        }

                    }
                }
                if (Publisher is not null)
                {
                    var publisher = await _publisherRepository.GetAsync(Guid.Parse(Publisher));
                    game.Publisher = publisher;
                }



                string url = model.Trailer;
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    Uri uri = new Uri(url);
                    string result = uri.PathAndQuery.Substring(1);
                    game.Trailer = result;
                }



                if (model.ImagePath is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var fileExt = Path.GetExtension(model.ImagePath.FileName);
                    var filePath = Path.Combine("/data/img/", $"{game.Id}{fileExt}");
                    string path = Path.Combine(wwwRootPath, "data\\img\\", $"{game.Id}{fileExt}");

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.ImagePath.CopyTo(fileStream);
                    }

                    game.Image = filePath;
                }
                await _gameRepository.UpdateAsync(game);
                return RedirectToAction("Index");

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BuyGame(GameViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var user = await _userRepository.GetOneWithRolesAsync(currentUser.Id);


            var gameToAdd = _mapper.Map<GameLowViewModel>(await _gameRepository.GetAsync(model.Id));

            if (user.Games.Any(game => game.Id == gameToAdd.Id))
            {
           
                return View("Index");
            }

            user.Games.Add(gameToAdd);
            await _userRepository.BuyGame(user, model.Id);

            return View("Details", gameToAdd);
        }

    }



}

