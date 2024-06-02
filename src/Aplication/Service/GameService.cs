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
using System.Numerics;
using System.Text;
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
        private readonly IAchievementUserRepository _achievementUserRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;
        public GameService(IGameRepository gameRepository, 
            IDeveloperRepository developerRepository, IPlatformRepository platformRepository,
            IGenreRepository genreRepository, IPublisherRepository publisherRepository, 
            ILanguageRepository languageRepository, IMapper mapper,
            IAchievementUserRepository achievementRepository, IWebHostEnvironment webHostEnvironment,
            IUserRepository userRepository, IFileService fileService)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _platformRepository = platformRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
            _achievementUserRepository = achievementRepository;
            _webHostEnvironment = webHostEnvironment;
            _userRepository = userRepository;
            _fileService = fileService;
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
          
            string url = model.Trailer;
            Uri uri = new Uri(url);
            string result = uri.PathAndQuery.Substring(1);
            game.Trailer = result;
            if (model.Image != null || model.ImagePath != null)
            {
                var fileResult = "Only";
                if (model.ImagePath != null)
                {
                    fileResult = _fileService.SaveImage(model.ImagePath, "game");
                }
                else if (model.Image != null)
                {
                    fileResult = _fileService.SaveIFormFile(model.Image, "actors");
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
            var game = _mapper.Map<Game>(model);
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

            string url = model.Trailer;
            Uri uri = new Uri(url);
            string result = uri.PathAndQuery.Substring(1);
            game.Trailer = result;
            if (model.Image != null || model.ImagePath != null)
            {
                var fileResult = "Only";
                if (model.ImagePath != null)
                {
                    fileResult = _fileService.SaveImage(model.ImagePath, "game");
                }
                else if (model.Image != null)
                {
                    fileResult = _fileService.SaveIFormFile(model.Image, "game");
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

    }
}
