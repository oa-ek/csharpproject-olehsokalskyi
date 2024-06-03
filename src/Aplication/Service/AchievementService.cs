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
    public class AchievementService: IAchievementService
    {
        private readonly IAchievementRepository _achievmentRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public AchievementService(IAchievementRepository achievmentRepository, IMapper mapper, IGameRepository gameRepository)
        {
            _achievmentRepository = achievmentRepository;
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<DefaultMessageResponse> AddAsync(AchievementCreateModel model)
        {
            var achievment = _mapper.Map<Achievement>(model);
            var game = await _gameRepository.GetAsync(model.GameId);
            if(game is null)
                throw new ObjectNotFound("Game not found");
            achievment.GameId = game.Id;
            await _achievmentRepository.CreateAsync(achievment);
            return new DefaultMessageResponse { Message = "Achievment created successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _achievmentRepository.ExistItem(id))
                throw new ObjectNotFound("Achiecment not found");
            await _achievmentRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Achievment deleted successfully" };
        }

        public async Task<AchievementViewModel> GetByIdAsync(Guid id)
        {
            var genre = await _achievmentRepository.GetAsync(id);
            if(genre is null)
                throw new ObjectNotFound("Achiecment not found");
            return _mapper.Map<AchievementViewModel>(genre);
        }

        public async Task<IEnumerable<AchievementViewModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<AchievementViewModel>>(await _achievmentRepository.GetAllAsync());
        }

        public async Task<DefaultMessageResponse> UpdateAsync(AchievementEditModel model)
        {
            var achievment = _mapper.Map<Achievement>(model);
            if (!await _achievmentRepository.ExistItem(model.Id))
                throw new ObjectNotFound("Achiecment not found");
            var game = await _gameRepository.GetAsync(model.GameId);
            if (game is null)
                throw new ObjectNotFound("Game not found");
            achievment.GameId = game.Id;
            await _achievmentRepository.UpdateAsync(achievment);
            return new DefaultMessageResponse { Message = "Achievment updated successfully" };
        }
    }
}
