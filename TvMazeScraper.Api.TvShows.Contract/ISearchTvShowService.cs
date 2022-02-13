using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Paging;
using TvMazeScraper.Api.TvShows.Domain.Response;

namespace TvMazeScraper.Api.TvShows.Contract
{
    public interface ISearchTvShowService
    {
        Task<PagedList<TvShow>> GetTvShowsAsync(PaginationFilter filter);
        Task<TvShow> GetTvShowByIdAsync(int id);
    }
}
