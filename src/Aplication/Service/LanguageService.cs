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
    public class LanguageService: ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<DefaultMessageResponse> AddAsync(LanguageCreateModel model)
        {
            var language = _mapper.Map<Language>(model);
            await _languageRepository.CreateAsync(language);
            return new DefaultMessageResponse { Message = "Language added successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _languageRepository.ExistItem(id))
                throw new ObjectNotFound("Language not found");
            await _languageRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Language deleted successfully" };
        }

        public async Task<LanguageModel> GetByIdAsync(Guid id)
        {
            if (!await _languageRepository.ExistItem(id))
                throw new ObjectNotFound("Language not found");
            return _mapper.Map<LanguageModel>(await _languageRepository.GetAsync(id));
        }

        public async Task<IEnumerable<LanguageModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<LanguageModel>>(await _languageRepository.GetAllAsync());
        }

        public async Task<DefaultMessageResponse> UpdateAsync(LanguageEditModel model)
        {
            if (!await _languageRepository.ExistItem(model.Id))
                throw new ObjectNotFound("Language not found");
            await _languageRepository.UpdateAsync(_mapper.Map<Language>(model));
            return new DefaultMessageResponse { Message = "Language updated successfully" };
        }
    }
}
