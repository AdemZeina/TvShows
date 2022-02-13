using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TvMazeScraper.Api.TvShows.Client;
using TvMazeScraper.Api.TvShows.Contract;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Model;

namespace TvMazeScraper.Api.TvShows.Controllers
{
    [Route("scraper")]
    [ApiController]
    public class TvMazeScraperController : ControllerBase
    {
        private readonly ITvMazeClient _httpClient;
        private readonly ITvShowsService _tvService;
        private readonly IMapper _mapper;


        public TvMazeScraperController(TvMazeClient httpClient, ITvShowsService tvService, IMapper mapper)
        {
            _httpClient = httpClient;
            _tvService = tvService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<OkObjectResult> Get()
        {
            IList<ScraperTvShowsDto> tvShow = await _httpClient.GetTvShows();

            int count= await _tvService.SaveTvShowWithCasts(_mapper.Map<List<TvShow>>(tvShow));
            
            return Ok($"{count} row were inserted...");
        }
    }
}
