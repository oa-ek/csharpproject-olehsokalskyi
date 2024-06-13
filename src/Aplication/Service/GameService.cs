using Application.Abstractions;
using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Service
{
    public class GameService: IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;
        private readonly HttpClient _httpClient;
        private readonly IAchievementRepository achievementRepository;
        public GameService(IGameRepository gameRepository, 
            IDeveloperRepository developerRepository, IPlatformRepository platformRepository,
            IGenreRepository genreRepository, IPublisherRepository publisherRepository, 
            ILanguageRepository languageRepository, IMapper mapper,
            IAchievementRepository achievementRepository, IWebHostEnvironment webHostEnvironment,
            IUserRepository userRepository, IFileService fileService, HttpClient httpClient)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _platformRepository = platformRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
            _achievementRepository = achievementRepository;
            _webHostEnvironment = webHostEnvironment;
            _userRepository = userRepository;

            _fileService = fileService;
            _httpClient = httpClient;
        }

        public async Task<DefaultMessageResponse> AddAsync(GameCreateModel model)
        {
            var game = _mapper.Map<Game>(model);
            foreach(Guid id in model.DevelopersList)
            {
                var dev = await _developerRepository.GetAsync(id);
                if (dev is not  null)
                    game.Developers.Add(dev);
            }
            foreach (Guid id in model.GenresList)
            {
                var gen = await _genreRepository.GetAsync(id);
                if (gen is not null)
                    game.Genres.Add(gen);
            }
            foreach (Guid id in model.PlatformsList)
            {
                var plat = await _platformRepository.GetAsync(id);
                if (plat is not null)
                    game.Platforms.Add(plat);
            }
            foreach(Guid id in model.LanguagesList)
            {
                var lang = await _languageRepository.GetAsync(id);
                if (lang is not null)
                    game.Languages.Add(lang);
            }
            var publisher = await _publisherRepository.GetAsync(model.PublisherId);
            if(publisher is not null)
                game.PublisherId = publisher.Id;
          
      
            if ( model.ImagePath != null) //model.Image != null ||
            {
                var fileResult = "Only";
                if (model.ImagePath != null)
                {
                    fileResult = _fileService.SaveImage(model.ImagePath, "game");
                }
                //else if (model.Image != null)
                //{
                //    fileResult = _fileService.SaveIFormFile(model.Image, "actors");
                //}
                if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                    throw new ObjectNotFound("Error");
                }
                else
                {
                    game.Image = fileResult;
                }
            }
            await _gameRepository.CreateAsync(game);
            return new DefaultMessageResponse { Message = "Game added successfully" };



        }

        public async Task<DefaultMessageResponse> BuyGame(GameBuyModel model)
        {
            var user = await _userRepository.GetByEmail(model.EmailUser);
            if(user is null)
                throw new ObjectNotFound("User not found");

            var game = await _gameRepository.GetAsync(model.GameId);
            if (game is null)
                throw new ObjectNotFound("Game not found");
            var gameToAdd = _mapper.Map<Game>(game);
            user.Games.Add(gameToAdd);
            await _userRepository.BuyGame(user, gameToAdd.Id);
            return new DefaultMessageResponse { Message = "Game added successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _gameRepository.ExistItem(id))
                throw new ObjectNotFound("Game not found");
            await _gameRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Game deleted successfully" };
        }

        public async Task<GameModel> GetByIdAsync(Guid id)
        {
            if (!await _gameRepository.ExistItem(id))
                throw new ObjectNotFound("Game not found");
            var game = await _gameRepository.GetAsync(id);
            return _mapper.Map<GameModel>(game);
        }

        public async Task<IEnumerable<GameModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<GameModel>>(await _gameRepository.GetAllAsync());
        }

        public async Task<DefaultMessageResponse> UpdateAsync(GameEditModel model)
        {
            if (!await _gameRepository.ExistItem(model.Id))
                throw new ObjectNotFound("Game not found");
            var game = await _gameRepository.GetAsync(model.Id);
            game.Title = model.Title;
            game.Description = model.Description;
            game.Price = model.Price;
            game.Trailer = model.Trailer;
            game.ReleaseDate = model.ReleaseDate;
            game.Developers.Clear();
            game.Genres.Clear();
            game.Platforms.Clear();
            game.Languages.Clear();
            foreach (Guid id in model.DevelopersList)
            {
                var dev = await _developerRepository.GetAsync(id);
                if (dev is not null)
                    game.Developers.Add(dev);
            }
            foreach (Guid id in model.GenresList)
            {
                var gen = await _genreRepository.GetAsync(id);
                if (gen is not null)
                    game.Genres.Add(gen);
            }
            foreach (Guid id in model.PlatformsList)
            {
                var plat = await _platformRepository.GetAsync(id);
                if (plat is not null)
                    game.Platforms.Add(plat);
            }
            foreach (Guid id in model.LanguagesList)
            {
                var lang = await _languageRepository.GetAsync(id);
                if (lang is not null)
                    game.Languages.Add(lang);
            }
            var publisher = await _publisherRepository.GetAsync(model.PublisherId);
            if (publisher is not null)
                game.PublisherId = publisher.Id;

            
            if ( model.ImagePath != null)
            {
                var fileResult = "Only";
                if (model.ImagePath != null)
                {
                    fileResult = _fileService.SaveImage(model.ImagePath, "game");
                }
    
                if (fileResult.Contains("Only") || fileResult.Contains("Error"))
                {
                    throw new ObjectNotFound("Error");
                }
                else
                {
                    game.Image = fileResult;
                }
            }
            await _gameRepository.UpdateAsync(game);
            return new DefaultMessageResponse { Message = "Game added successfully" };
        }
        public async Task<DefaultMessageResponse> GetGameFromAPI()
        {
            var gamesApiURL = "https://api.rawg.io/api/games?key=e8408e3fb5254b2fa3638b003fbce07e";
            var gamesResponse = await _httpClient.GetAsync(gamesApiURL);

            if (gamesResponse.IsSuccessStatusCode)
            {
                var gamesContent = await gamesResponse.Content.ReadAsStringAsync();

                var gamesResponseModel = JsonSerializer.Deserialize<GameAPIResponse>(gamesContent);


                foreach (var gameId in gamesResponseModel.Results)
                {
                    var gameDetailsResponse = await _httpClient.GetAsync($"https://api.rawg.io/api/games/{gameId.Id}?key=e8408e3fb5254b2fa3638b003fbce07e");
                    if (!gameDetailsResponse.IsSuccessStatusCode)
                    {
                        continue;
                    }
                    var gameDetailsContent = await gameDetailsResponse.Content.ReadAsStringAsync();
                    var game = JsonSerializer.Deserialize<GameAPIModel>(gameDetailsContent);
                    List<Genre> genres = new List<Genre>();
                    foreach (var genre in game.Genres)
                    {
                        Console.WriteLine(genre.Name);
                        var locGenre = await _genreRepository.GetGenreByName(genre.Name);
                        if (locGenre == null)
                        {
                            Genre newGenre = new Genre
                            {
                                Title = genre.Name
                            };
                            await _genreRepository.CreateAsync(newGenre);
                        }
                        Genre genre1 = await _genreRepository.GetGenreByName(genre.Name);
                        Console.WriteLine(genre1.Id);
                        genres.Add(genre1);
                    }
                    List<Platform> platforms = new List<Platform>();
                    foreach (var platform in game.Platforms)
                    {
                        Console.WriteLine(platform.Platform.Name);
                        var locPlatform = await _platformRepository.GetPlatformByName(platform.Platform.Name);
                        if (locPlatform == null)
                        {
                            Platform newPlatform = new Platform
                            {
                                Title = platform.Platform.Name
                            };
                            await _platformRepository.CreateAsync(newPlatform);
                        }
                        Platform platform1 = await _platformRepository.GetPlatformByName(platform.Platform.Name);
                        Console.WriteLine(platform1.Id);
                        platforms.Add(platform1);
                    }
                    List<Developer> developers = new List<Developer>();
                    foreach (var developer in game.Developers)
                    {
                        Console.WriteLine(developer.Name);
                        var locDeveloper = await _developerRepository.GetDeveloperByName(developer.Name);
                        if (locDeveloper == null)
                        {
                            Developer newDeveloper = new Developer
                            {
                                Title = developer.Name
                            };
                            await _developerRepository.CreateAsync(newDeveloper);
                        }
                        Developer developer1 = await _developerRepository.GetDeveloperByName(developer.Name);
                        Console.WriteLine(developer1.Id);
                        developers.Add(developer1);
                    }
                    List<Publisher> publishers = new List<Publisher>();
                    foreach (var publisher in game.Publishers)
                    {
                        Console.WriteLine(publisher.Name);
                        var locPublisher = await _publisherRepository.GetPublisherByName(publisher.Name);
                        if (locPublisher == null)
                        {
                            Publisher newPublisher = new Publisher
                            {
                                Title = publisher.Name,
                                Description = publisher.Description

                            };
                            await _publisherRepository.CreateAsync(newPublisher);
                        }
                        Publisher publisher1 = await _publisherRepository.GetPublisherByName(publisher.Name);
                        Console.WriteLine(publisher1.Id);
                        publishers.Add(publisher1);
                    }

                    var locgame = await _gameRepository.ExitGameByName(game.Name);
                    if (locgame == null)
                    {
                        Game gameCreateModel = new Game
                        {
                            Title = game.Name,
                            ReleaseDate = game.Released,
                            Description = game.Description,
                            Image = game.Background_image,
                            Trailer = "https://www.youtube.com/watch?v=6ZfuNTqbHE8",
                            Genres = genres,
                            Platforms = platforms,
                            Developers = developers,
                            Publisher = publishers[0],
                        };
                        await _gameRepository.CreateAsync(gameCreateModel);
                        locgame = await _gameRepository.ExitGameByName(game.Name);
                    }
                    var achivementResponse = await _httpClient.GetAsync($"https://api.rawg.io/api/games/{game.Id}/achievements?key=e8408e3fb5254b2fa3638b003fbce07e");
                    if (!achivementResponse.IsSuccessStatusCode)
                    {
                        continue;
                    }
                    var achievementContent = await achivementResponse.Content.ReadAsStringAsync();
                    var achievements = JsonSerializer.Deserialize<AchievementsAPIResponse>(achievementContent);
                    var achievementsContent = new List<Achievement>();
                    foreach (var achievement in achievements.Results)
                    {
                        Console.WriteLine(achievement.Name);
                        var locAchievement = await _achievementRepository.GetAchievementByName(achievement.Name);

                        if (locAchievement == null)
                        {
                            Achievement newAchievement = new Achievement
                            {
                                Title = achievement.Name,
                                Description = achievement.Description,
                                Game = locgame
                            };
                            await _achievementRepository.CreateAsync(newAchievement);
                        }
                        Achievement achievement1 = await _achievementRepository.GetAchievementByName(achievement.Name);
                        Console.WriteLine(achievement1.Id);
                        achievementsContent.Add(achievement1);
                    }
                  
                }
                return new DefaultMessageResponse { Message = "Game added successfully" };
            }
            return new DefaultMessageResponse { Message = "Error" };
        }

    }
    
}
