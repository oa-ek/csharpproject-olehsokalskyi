using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class GameTimeService : IGameTimeService
    {
        private readonly IGameTimeRepository _gameTimeRepository;
        private readonly IGameRepository _gameRepository;
        private readonly UserManagerService _userManagerService;
        private readonly IMapper _mapper;
        public GameTimeService(IGameTimeRepository gameTimeRepository, IGameRepository gameRepository, UserManagerService userManagerService, IMapper mapper)
        {
            _gameTimeRepository = gameTimeRepository;
            _gameRepository = gameRepository;
            _userManagerService = userManagerService;
            _mapper = mapper;
        }

        public async Task<DefaultMessageResponse> AddAsync(GameTimeCreateModel model)
        {
            var gameTime = _mapper.Map<GameTime>(model);
            var user = await _userManagerService.GetUserByEmail(model.UserEmail);
            if(user is null)
                throw new ObjectNotFound("User not found");
            var game = await _gameRepository.GetAsync(model.GameId);
            if(game is null)
                throw new ObjectNotFound("Game not found");
            if (await _gameTimeRepository.GetGameTimeByUserAndGame(user.Id, game.Id) is not null)
                throw new ObjectAlreadyExistException("GameTime already exist");
            gameTime.User = user;
            gameTime.Game = game;
            await _gameTimeRepository.CreateAsync(gameTime);
            return new DefaultMessageResponse { Message = "GameTime created successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _gameTimeRepository.ExistItem(id))
                throw new ObjectNotFound("GameTime not found");
            await _gameTimeRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "GameTime deleted successfully" };
        }

        public async Task<GameTimeModel> GetByIdAsync(Guid id)
        {
            var rate = await _gameTimeRepository.GetAsync(id);
            if(rate is null)
                throw new ObjectNotFound("GameTime not found");
            return _mapper.Map<GameTimeModel>(rate);

        }

        public async Task<IEnumerable<GameTimeModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<GameTimeModel>>(await _gameTimeRepository.GetAllAsync());
        }

        public async Task<DefaultMessageResponse> UpdateAsync(GameTimeEditModel model)
        {
            if(!await _gameTimeRepository.ExistItem(model.Id))
                throw new ObjectNotFound("GameTime not found");
            var gameTime = _mapper.Map<GameTime>(model);
            var game = await _gameRepository.GetAsync(model.GameId);
            if(game is null)
                throw new ObjectNotFound("Game not found");
            var user = await _userManagerService.GetUserByEmail(model.UserEmail);
            if (user is null)
                throw new ObjectNotFound("User not found");
            gameTime.User = user;
            gameTime.Game = game;
            await _gameTimeRepository.UpdateAsync(gameTime);
            return new DefaultMessageResponse { Message = "GameTime updated successfully" };
        }
    }
}
