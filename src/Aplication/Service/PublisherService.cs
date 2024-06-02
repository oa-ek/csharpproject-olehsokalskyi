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
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        public async Task<DefaultMessageResponse> AddAsync(PublisherCreateModel model)
        {
            
                var modelEntity = _mapper.Map<Publisher>(model);
                await _publisherRepository.CreateAsync(modelEntity);
                return new DefaultMessageResponse { Message = "Publisher created successfully" };
            
          
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            
                var publisher = await _publisherRepository.ExistItem(id);
                if (!publisher)
                    throw new ObjectNotFound("Publisher not found22");
                await _publisherRepository.DeleteAsync(id);
                return new DefaultMessageResponse { Message = "Publisher deleted successfully" };
           

        }

        public async Task<PublisherModel> GetByIdAsync(Guid id)
        {
           
                var publisher = _mapper.Map<PublisherModel>(await _publisherRepository.GetAsync(id));   
                if(publisher is null)
                    throw new ObjectNotFound("Publisher not found");
                return publisher;
            
        }

        public async Task<IEnumerable<PublisherModel>> GetListAsync()
        {
               return _mapper.Map<IEnumerable<PublisherModel>>(await _publisherRepository.GetAllAsync()); 
        }

        public async Task<DefaultMessageResponse> UpdateAsync(PublisherEditModel model)
        {
            
                var pubExits = await _publisherRepository.ExistItem(model.Id);
                if (!pubExits)
                    throw new ObjectNotFound("Publisher not found");

                var publisher = _mapper.Map<Publisher>(model);
                await _publisherRepository.UpdateAsync(publisher);
                return new DefaultMessageResponse { Message = "Publisher updated successfully" };
           
        }
    }
}
