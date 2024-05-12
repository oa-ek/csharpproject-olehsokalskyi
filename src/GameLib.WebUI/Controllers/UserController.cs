using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await userRepository.GetAllWithRolesAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserCreateDto());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userRepository.CreateWithPasswordAsync(model);

                if (user != null)
                {
                    return RedirectToAction(nameof(Edit), new { id = user.Id });
                }
            }

            return View(new UserCreateDto());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Roles = await userRepository.GetRolesAsync();
            return View(await userRepository.GetOneWithRolesAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDto model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await userRepository.UpdateUserAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await userRepository.GetRolesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<int> CheckDelete(Guid id)
        {
            var check = await userRepository.CheckUser(id);
            return check ? 1 : 0;
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await userRepository.DeleteUser(id);
        }
    }
}
