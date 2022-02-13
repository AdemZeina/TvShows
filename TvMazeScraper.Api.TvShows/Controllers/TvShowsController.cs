using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeScraper.Api.TvShows.Contract;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Paging;
using TvMazeScraper.Api.TvShows.Domain.Response;
using TvMazeScraper.Api.TvShows.Model;

namespace TvMazeScraper.Api.TvShows.Controllers
{
    [Route("tv-shows")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly ISearchTvShowService _tvShowService;
        private readonly IMapper _mapper;
        public TvShowsController(ISearchTvShowService tvShowService, IMapper mapper)
        {
            _tvShowService = tvShowService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<PagedResponse<List<TvShowDto>>> Filter(int pageNumber, int pageSize)
        {
            var filter = new PaginationFilter(pageNumber, pageSize);


            var result = await _tvShowService.GetTvShowsAsync(filter);

            return new PagedResponse<List<TvShowDto>>(
                _mapper.Map<List<TvShowDto>>(result.ToList()),
                pageNumber, pageSize,
                result.TotalItemCount,
                result.PageCount, result.FirstPage,
                result.LastPage, result.HasNextPage,
                result.HasPreviousPage,
                result.IsFirstPage, result.IsLastPage
                );
        }

        [HttpGet]
        [Route("getById")]
        public async Task<TvShowDto> GetByIdAsync(int showId)
        {
            return _mapper.Map<TvShowDto>(await _tvShowService.GetTvShowByIdAsync(showId));
        }
    }
}
