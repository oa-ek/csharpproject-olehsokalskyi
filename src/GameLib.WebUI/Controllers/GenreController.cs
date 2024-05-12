using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Genres;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreController(
                       IGenreRepository genreRepository,
                                  IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var genres = _mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepository.GetAllAsync());
            return View(genres);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GenreCreateModel model)
        {
            if (ModelState.IsValid)
            {
               var genre = _mapper.Map<Genre>(model);
               await  _genreRepository.CreateAsync(genre);
               return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var genre = _mapper.Map<GenreEditModel>(await _genreRepository.GetAsync(id));
            return View(genre);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GenreEditModel model)
        {
            if (ModelState.IsValid)
            {
                var genre = _mapper.Map<Genre>(model);
                await _genreRepository.UpdateAsync(genre);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _genreRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
