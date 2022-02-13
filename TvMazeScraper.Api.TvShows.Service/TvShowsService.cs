using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TvMazeScraper.Api.TvShows.Contract;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Paging;
using TvMazeScraper.Api.TvShows.Domain.Response;
using TvMazeScraper.Api.TvShows.Infrastructure.SqlServer;

namespace TvMazeScraper.Api.TvShows.Service
{
    public class TvShowsService : ITvShowsService, ISearchTvShowService
    {
        private readonly TvShowDbAccess _showDbContext;

        public TvShowsService(TvShowDbAccess showDbContext)
        {
            _showDbContext = showDbContext;
        }

        public async Task<PagedList<TvShow>> GetTvShowsAsync(PaginationFilter filter)
        {
            return await _showDbContext.GetPaginatedTvShow<TvShow>(filter);
        }

        public async Task<TvShow> GetTvShowByIdAsync(int id)
        {
            return await _showDbContext.GetTvShowById(id);
        }

        public async Task<int> SaveTvShowWithCasts(List<TvShow> shows)
        {
            var insertCount = await _showDbContext.InsertNewItemsAsync(shows,true);
            var casts = shows.SelectMany(s => s.Casts).ToList();

            var uniqueCasts = casts
                .GroupBy(x => x.Id)
                .Select(g => g.First())
                .ToList();

            var castsResult = await _showDbContext.InsertNewItemsAsync(uniqueCasts, true);

            return insertCount;
        }
    }
}
