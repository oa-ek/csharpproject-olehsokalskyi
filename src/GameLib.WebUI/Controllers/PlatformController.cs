using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Platforms;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public PlatformController(
                       IPlatformRepository platformRepository,
                                  IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var platforms = _mapper.Map<IEnumerable<PlatformViewModel>>(await _platformRepository.GetAllAsync());
            return View(platforms);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlatformCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var platform = _mapper.Map<Platform>(model);
                await _platformRepository.CreateAsync(platform);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var platform = _mapper.Map<PlatformEditModel>(await _platformRepository.GetAsync(id));
            return View(platform);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PlatformEditModel model)
        {
            if (ModelState.IsValid)
            {
                var platform = _mapper.Map<Platform>(model);
                await _platformRepository.UpdateAsync(platform);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _platformRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
