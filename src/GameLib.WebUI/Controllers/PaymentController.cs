using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Games;
using GameLib.Repository.Repositories.Payments;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GameLib.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly UserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public PaymentController(
                       IPaymentRepository paymentRepository,
                                  UserRepository userRepository,
                                             IGameRepository gameRepository,
                                                        IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var payments = _mapper.Map<IEnumerable<PaymentViewModel>>(await _paymentRepository.GetAllAsync());
            return View(payments);
        }
        public async Task<IActionResult> Create()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllWithRolesAsync());
            ViewBag.Users = users;
            var games = _mapper.Map<IEnumerable<GameViewModel>>(await _gameRepository.GetAllAsync());
            ViewBag.Games = games;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = _mapper.Map<Payment>(model);
                var user = _mapper.Map<User>(await _userRepository.GetOneWithRolesAsync(model.User.Id));
                payment.User = user;
                var game = await _gameRepository.GetAsync(model.Game.Id);
                payment.Game = game;
                payment.Amount = game.Price;
                payment.Date = DateTime.UtcNow;
                await _paymentRepository.CreateAsync(payment);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var payment = _mapper.Map<PaymentViewModel>(await _paymentRepository.GetAsync(id));
            var users = _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllWithRolesAsync());
            ViewBag.Users = users;
            var games = _mapper.Map<IEnumerable<GameViewModel>>(await _gameRepository.GetAllAsync());
            ViewBag.Games = games;
            return View(payment);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = _mapper.Map<Payment>(model);
                var user = _mapper.Map<User>(await _userRepository.GetOneWithRolesAsync(model.User.Id));
                payment.User = user;
                var game = await _gameRepository.GetAsync(model.Game.Id);
                payment.Game = game;
                await _paymentRepository.UpdateAsync(payment);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _paymentRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
