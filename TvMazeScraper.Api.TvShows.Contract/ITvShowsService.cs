using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvMazeScraper.Api.TvShows.Domain;

namespace TvMazeScraper.Api.TvShows.Contract
{
    public interface ITvShowsService
    {
        Task<int> SaveTvShowWithCasts(List<TvShow> shows);
    }
}
