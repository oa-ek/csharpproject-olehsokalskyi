using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAllWithRolesAsync());
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userRepository.GetOneWithRolesAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateAsync(userCreateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userCreateDto);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userRepository.GetOneWithRolesAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Roles = await _userRepository.GetRolesAsync();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserDto userDto, string[] roles)
        {
            if (id != userDto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _userRepository.UpdateAsync(userDto, roles);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Roles = await _userRepository.GetRolesAsync();
            return View(userDto);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
