using Application.Abstractions;
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
    public class DeveloperService: IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public DeveloperService(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        public async Task<DefaultMessageResponse> AddAsync(DeveloperCreateModel model)
        {
           await _developerRepository.CreateAsync(_mapper.Map<Developer>(model));
            return new DefaultMessageResponse { Message = "Developer created successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _developerRepository.ExistItem(id))
            
                throw new ObjectNotFound("Developer not found");
            await _developerRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Developer deleted successfully" };
            
        }

        public async Task<DeveloperViewModel> GetByIdAsync(Guid id)
        {
            var developer = _mapper.Map<DeveloperViewModel>(await _developerRepository.GetAsync(id));
            if (developer is null)
                throw new ObjectNotFound("Developer not found");
            return developer;
        }

        public async Task<IEnumerable<DeveloperViewModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<DeveloperViewModel>>(await _developerRepository.GetAllAsync());
        }

        public async Task<DefaultMessageResponse> UpdateAsync(DeveloperEditModel model)
        {
            if (!await _developerRepository.ExistItem(model.Id))

                throw new ObjectNotFound("Developer not found");
            await _developerRepository.UpdateAsync(_mapper.Map<Developer>(model));
            return new DefaultMessageResponse { Message = "Developer updated successfully" };
        }
    }
}
