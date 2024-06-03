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
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly UserManagerService _userManagerService;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public RatingService(IRatingRepository ratingRepository, UserManagerService userManagerService, IGameRepository gameRepository,IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _userManagerService = userManagerService;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<DefaultMessageResponse> AddAsync(RatingCreateModel model)
        {
            var rating = _mapper.Map<Rating>(model);
            var user = await _userManagerService.GetUserByEmail(model.UserEmail);
            if(user is null)
                throw new ObjectNotFound("User not found");
            var game = await _gameRepository.GetAsync(model.GameId);
            if(game is null)
                throw new ObjectNotFound("Game not found");
            if(await _ratingRepository.GetRatingByUserAndGame(user.Id, game.Id) is not null)
                throw new ObjectAlreadyExistException("Rating already exist");
            rating.User = user;
            rating.Game = game;
            await _ratingRepository.CreateAsync(rating);
            return new DefaultMessageResponse { Message = "Rating created successfully" };
        }

        public  async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _ratingRepository.ExistItem(id))
                throw new ObjectNotFound("Rating not found");
            await _ratingRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Rating deleted successfully" };
        }

        public async Task<RatingModel> GetByIdAsync(Guid id)
        {
            var rate = _ratingRepository.GetAsync(id);
            if(rate is null)
                throw new ObjectNotFound("Rating not found");
            return _mapper.Map<RatingModel>(rate);
        }

        public async Task<IEnumerable<RatingModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<RatingModel>>(await _ratingRepository.GetAllAsync()); 
        }

        public async Task<DefaultMessageResponse> UpdateAsync(RatingEditModel model)
        {
           
            var rate = _mapper.Map<Rating>(model);
            if(!await _ratingRepository.ExistItem(model.Id))
                throw new ObjectNotFound("Rating not found");
            var user = await _userManagerService.GetUserByEmail(model.UserEmail);
            if(user is null)
                throw new ObjectNotFound("User not found");
            var game = await _gameRepository.GetAsync(model.GameId);    
            if(game is null)
                throw new ObjectNotFound("Game not found");

            //TODO зробити метод в репозиторії який буде перевіряти чи збігаються користувачі 
            rate.User = user;
            rate.Game = game;
            await _ratingRepository.UpdateAsync(rate);
            return new DefaultMessageResponse { Message = "Rating updated successfully" };


        }
    }
}
