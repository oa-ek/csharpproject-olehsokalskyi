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
    public class PlatformService: IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public PlatformService(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<DefaultMessageResponse> AddAsync(PlatformCreateModel model)
        {
            var platform = _mapper.Map<Platform>(model);
            await _platformRepository.CreateAsync(platform);
            return new DefaultMessageResponse { Message = "Platform added successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _platformRepository.ExistItem(id)) { 
                throw new ObjectNotFound("Platform not found");}
            await _platformRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Platform deleted successfully" };
        }

        public async Task<Commons.Models.PlatformViewModel> GetByIdAsync(Guid id)
        {
           var platform  = await _platformRepository.GetAsync(id);
            if(platform is null)
                throw new ObjectNotFound("Platform not found");
            return _mapper.Map<Commons.Models.PlatformViewModel>(platform);
        }

        public async Task<IEnumerable<PlatformViewModel>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<PlatformViewModel>>(await _platformRepository.GetAllAsync());
        }

        public async Task<DefaultMessageResponse> UpdateAsync(PlatformEditModel model)
        {
            if (!await _platformRepository.ExistItem(model.Id))
                throw new ObjectNotFound("Platform not found");
            var platform = _mapper.Map<Platform>(model);
            await _platformRepository.UpdateAsync(platform);
            return new DefaultMessageResponse { Message = "Platform updated successfully" };
            
        }
    }
}
