using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Languages;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public LanguageController(
                ILanguageRepository languageRepository,
                IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var languages = _mapper.Map<IEnumerable<LanguageViewModel>>(await _languageRepository.GetAllAsync());
            return View(languages);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var language = _mapper.Map<Language>(model);
                await _languageRepository.CreateAsync(language);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var language = _mapper.Map<LanguageEditModel>(await _languageRepository.GetAsync(id));
            return View(language);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LanguageEditModel model)
        {
            if (ModelState.IsValid)
            {
                var language = _mapper.Map<Language>(model);
                await _languageRepository.UpdateAsync(language);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _languageRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
