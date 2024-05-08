using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Games;
using GameLib.Repository.Repositories.Ratings;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public RatingController(
        IRatingRepository ratingRepository,
        IGameRepository gameRepository,
        IUserRepository userRepository,
        UserManager<User> userManager,
        IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ratings = _mapper.Map<IEnumerable<RatingViewModel>>(await _ratingRepository.GetAllAsync());
            return View(ratings);
        }
        [Authorize]
        public async Task<IActionResult> Create(GameViewModel game)
        {
            var gamecur = await _gameRepository.GetAsync(game.Id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new RatingCreateModel
            {
                GameId = gamecur.Id,
                UserId = user.Id
            };
            return View(model);
        }
       
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RatingCreateModel model)
        {
            var game = await _gameRepository.GetAsync(model.GameId);
            model.GameId = game.Id;
            if (ModelState.IsValid)
            {
                var existingRating = await _ratingRepository.GetRatingByUserAndGame(model.UserId, model.GameId);
                if (existingRating != null)
                {
                    ModelState.AddModelError("", "You have already left a review for this game.");
                    return View(model);
                }
                var rating = _mapper.Map<Rating>(model);
                rating.Game = game;

                var user = await _userManager.GetUserAsync(HttpContext.User);
                rating.User = user;

                await _ratingRepository.CreateAsync(rating);
                return RedirectToAction("Details", "Game", new { id = model.GameId });
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var rating = _mapper.Map<RatingEditModel>(await _ratingRepository.GetAsync(id));
            var model = new RatingEditModel
            {
                Id = rating.Id,
                RatingValue = rating.RatingValue,
                Comment = rating.Comment,
                GameId = rating.GameId,
          
            };
            var games = _mapper.Map<IEnumerable<GameViewModel>>(await _gameRepository.GetAllAsync());
            ViewBag.Games = games;
          
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RatingEditModel model,string Game) //, string User
        {
            if (ModelState.IsValid)
            {
                var rating = _mapper.Map<Rating>(model);
                if(Game is not null)
                {
                    var game = await _gameRepository.GetAsync(Guid.Parse(Game));
                    rating.Game = game;
                }
                //if(User is not null)
                //{
                //    var user = _mapper.Map<User>(await _userRepository.GetOneWithRolesAsync(Guid.Parse(User)));
                //    rating.User = user;
                //}
                
      
                await _ratingRepository.UpdateAsync(rating);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> EditUser(Guid id)
        {
            var rating = _mapper.Map<RatingEditUserModel>(await _ratingRepository.GetAsync(id));
            var model = new RatingEditUserModel
            {
                Id = rating.Id,
                RatingValue = rating.RatingValue,
                Comment = rating.Comment,
                GameId = rating.GameId,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(RatingEditUserModel model) 
        {
            if (ModelState.IsValid)
            {
                
                var rating = _mapper.Map<Rating>(model);
                var game = await _gameRepository.GetAsync(model.GameId);
                rating.Game = game;
                await _ratingRepository.UpdateAsync(rating);

  
                return RedirectToAction("Details", "Game", new { id = model.GameId });
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var rate = await _ratingRepository.GetAsync(id);
            var gameId = rate.Game.Id;
            await _ratingRepository.DeleteAsync(id);
           
            return RedirectToAction("Details", "Game", new { id = gameId });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ratingRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
