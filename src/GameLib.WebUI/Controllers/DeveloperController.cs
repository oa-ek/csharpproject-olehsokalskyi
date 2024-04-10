using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Developers;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public DeveloperController(
                       IDeveloperRepository developerRepository,
                                  IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var developers = _mapper.Map<IEnumerable<DeveloperViewModel>>(await _developerRepository.GetAllAsync());
            return View(developers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DeveloperCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var developer = _mapper.Map<Developer>(model);
                await _developerRepository.CreateAsync(developer);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var developer = _mapper.Map<DeveloperEditModel>(await _developerRepository.GetAsync(id));
            return View(developer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DeveloperEditModel model)
        {
            if (ModelState.IsValid)
            {
                var developer = _mapper.Map<Developer>(model);
                await _developerRepository.UpdateAsync(developer);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _developerRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
