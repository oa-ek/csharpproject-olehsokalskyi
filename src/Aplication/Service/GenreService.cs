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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<DefaultMessageResponse> AddAsync(GenreCreateModel model)
        {
            await _genreRepository.CreateAsync(_mapper.Map<Genre>(model));
            return new DefaultMessageResponse { Message = "Genre created successfully" };
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            if(!await _genreRepository.ExistItem(id))
                throw new ObjectNotFound("Genre not found");
            await _genreRepository.DeleteAsync(id);
            return new DefaultMessageResponse { Message = "Genre deleted successfully" };

        }

        public async Task<GenreModel> GetByIdAsync(Guid id)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre is null)
                throw new ObjectNotFound("Genre not found");
            return _mapper.Map<GenreModel>(genre);
        }

        public async Task<IEnumerable<GenreModel>> GetListAsync()
        {
            IEnumerable<Genre> genres = await _genreRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenreModel>>(genres);
        }

        public async Task<DefaultMessageResponse> UpdateAsync(GenreEditModel model)
        {
            if (!await _genreRepository.ExistItem(model.Id))
                throw new ObjectNotFound("Genre not found");
            await _genreRepository.UpdateAsync(_mapper.Map<Genre>(model));
            return new DefaultMessageResponse { Message = "Genre updated successfully" };
        }
    }
}
