using Microsoft.Extensions.Configuration;
using Moq;
using TvMazeScraper.Api.TvShows.Contract;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Paging;
using TvMazeScraper.Api.TvShows.Infrastructure.SqlServer;
using Xunit;

namespace TvMazeScraper.Api.TvShows.Service.UnitTest
{
    public class TvShowsServiceTests
    {

        public static ISearchTvShowService CreateTvShowsService()
        {
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig
                .SetupGet(x => x[It.Is<string>(s => s == "connectionString")])
                .Returns("Server=ZEINA\\SQLEXPRESS;Database=TvShows;Trusted_Connection=True;");

            return new TvShowsService(new TvShowDbAccess(mockConfig.Object));
        }

        [Fact]
        public void Test_Service_Should_Return_TvShow_Item()
        {
            var service=CreateTvShowsService();
            var item= service.GetTvShowByIdAsync(1).Result;

            Assert.Equal(typeof(TvShow),item.GetType());
        }

        [Fact]
        public void Test_Service_Should_Return_Null()
        {
            var service = CreateTvShowsService();
            var item = service.GetTvShowByIdAsync(0).Result;


            Assert.Null(item);
        }

        [Fact]
        public void Test_Service_Should_Return_List()
        {
            var service = CreateTvShowsService();
            var item = service.GetTvShowsAsync(new PaginationFilter()).Result;


            Assert.Equal(typeof(PagedList<TvShow>),item.GetType());
        }
    
    }
}
