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
    public class AchievementUserService : IAchievementUserService
    {
        private readonly IAchievementUserRepository _achievementUserRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IGameRepository _gameRepository;
        private readonly UserManagerService _userManagerService;
        private readonly IMapper _mapper;
        public AchievementUserService(IAchievementUserRepository achievementUserRepository, IMapper mapper,
            UserManagerService userManagerService, IAchievementRepository achievementRepository, IGameRepository gameRepository)
        {
            _achievementUserRepository = achievementUserRepository;
            _mapper = mapper;
            _userManagerService = userManagerService;
            _achievementRepository = achievementRepository;
            _gameRepository = gameRepository;
        }

        public async Task<DefaultMessageResponse> AddAsync(AchievementUserCreateModel model)
        {
            var achievementUser = _mapper.Map<AchievementUser>(model);
            var user = await _userManagerService.GetUserByEmail(model.UserEmail);
            if(user is null)
                throw new ObjectNotFound("User not found");
            achievementUser.User = user;
            var achievement = await _achievementRepository.GetAsync(model.AchievementId);
            if(achievement is null)
                throw new ObjectNotFound("Achievement not found");
            achievementUser.AchievementId = achievement.Id;
            await _achievementUserRepository.CreateAsync(achievementUser);
            return new DefaultMessageResponse { Message = "AchievementUser created successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _achievementUserRepository.ExistItem(id))
                throw new ObjectNotFound("AchievementUser not found");
            await _achievementUserRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "AchievementUser deleted successfully" };
        }

        public async Task<AchievementUserModel> GetByIdAsync(Guid id)
        {
            var achievementUser = await _achievementUserRepository.GetAsync(id);
            if(achievementUser is null)
                throw new ObjectNotFound("AchievementUser not found");
            return _mapper.Map<AchievementUserModel>(achievementUser);
        }

        public async Task<IEnumerable<AchievementUserModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<AchievementUserModel>>(await _achievementUserRepository.GetAllAsync());    
        }

        public async Task<DefaultMessageResponse> UpdateAsync(AchievementUserEditModel model)
        {
            var achievementUser = _mapper.Map<AchievementUser>(model);
            var user = await _userManagerService.GetUserByEmail(model.UserEmail);
            if (user is null)
                throw new ObjectNotFound("User not found");
            achievementUser.UserId = user.Id;
            var achievement = await _achievementRepository.GetAsync(model.AchievementId);
            if (achievement is null)
                throw new ObjectNotFound("Achievement not found");
            achievementUser.AchievementId = achievement.Id;
            await _achievementUserRepository.UpdateAsync(achievementUser);
            return new DefaultMessageResponse { Message = "AchievementUser updated successfully" };
        }

        public async Task<IEnumerable<AchievementUserModel>> GetByUserAndGame(Guid gameId, string email)
        {
            var user = await _userManagerService.GetUserByEmail(email);
            if (user is null)
                throw new ObjectNotFound("User not found");
            if(!await _gameRepository.ExistItem(gameId))
                                throw new ObjectNotFound("Game not found");
            var achievementUsers = await _achievementUserRepository.GetByUserAndGame(gameId, user.Id);
            return _mapper.Map<IEnumerable<AchievementUserModel>>(achievementUsers);
        }
    }
}
