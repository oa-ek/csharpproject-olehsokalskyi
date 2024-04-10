using AutoMapper;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherController(
                       IPublisherRepository publisherRepository,
                                  IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var publishers = _mapper.Map<IEnumerable<PublisherViewModel>>(await _publisherRepository.GetAllAsync());
            return View(publishers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PublisherCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var publisher = _mapper.Map<Publisher>(model);

                await _publisherRepository.CreateAsync(publisher);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var publisher = _mapper.Map<PublisherEditModel>(await _publisherRepository.GetAsync(id));
            return View(publisher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PublisherEditModel model)
        {
            if (ModelState.IsValid)
            {
                var publisher = _mapper.Map<Publisher>(model);
                await _publisherRepository.UpdateAsync(publisher);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _publisherRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
