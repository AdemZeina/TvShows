using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Entity;
using TvMazeScraper.Api.TvShows.Domain.Paging;
using TvMazeScraper.Api.TvShows.Domain.Response;
using TvMazeScraper.Api.TvShows.Infrastructure.SqlServer.Db;
using DbConnection = System.Data.Common.DbConnection;

namespace TvMazeScraper.Api.TvShows.Infrastructure.SqlServer
{
    public class TvShowDbAccess : BaseDataAccess
    {
        public TvShowDbAccess(IConfiguration configuration) 
            : base(configuration)
        {
        }
        

        public async Task<TvShow> GetTvShowById(int id)
        {
            var tableName = "TvShow";
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM {tableName} " +
                                  $" where Id={id} ";
            var items = await GetTvShowList(command);

            
            var item = items.FirstOrDefault();
            if (item == null)
                return null;

            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM Cast where TvShowId={item.Id}";
            item.Casts = await GetCastList(command);

            return item;
        }

        public async Task<PagedList<TvShow>> GetPaginatedTvShow<T>(PaginationFilter filter)
        {
            var tableName = typeof(T).Name;
            

            int totalCount = await GetTotalRecordsCountAsync(tableName);
            
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM {tableName} " +
                                  $" ORDER BY Id " +
                                  $" OFFSET({filter.PageNumber - 1}) * {filter.PageSize} ROWS " +
                                  $"FETCH NEXT {filter.PageSize} ROWS ONLY";

            var items = await GetTvShowList(command);

            foreach (var item in items)
            {
                command.CommandType = CommandType.Text;
                command.CommandText = $"SELECT * FROM Cast where TvShowId={item.Id}";
                
                item.Casts = await GetCastList(command);
            }

            return new PagedList<TvShow>(items,filter.PageNumber,filter.PageSize, totalCount);
        }

        private async Task<int> GetTotalRecordsCountAsync(string tableName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT Count(*) FROM {tableName} ";
            command.Connection = GetConnection();
            int count = 0;
            using (SqlDataReader res = await command.ExecuteReaderAsync())
            {
                while (res.Read())
                {
                    count = res.GetInt32(0);
                }
            }
            
            await command.Connection.CloseAsync();
            return count;
        }

        public async Task<List<TvShow>> GetTvShowList(SqlCommand command)
        {
            List<TvShow> tvShowList = new List<TvShow>();

            List<DbParameter> parameterList = new List<DbParameter>();
            try
            {
                command.Connection = this.GetConnection();
                using (DbDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var tvShow = new TvShow
                            {
                                Id = (int)dataReader["Id"],
                                Name = (string)dataReader["Name"],
                                Type = (string)dataReader["Type"],
                                Language = (string)dataReader["Language"],
                                Genres = (string)dataReader["Genres"],
                                Status = (string)dataReader["Status"],
                                Runtime = (int?)dataReader["Runtime"],
                                AverageRuntime = (int)dataReader["AverageRuntime"],
                                Premiered = (string)dataReader["Premiered"],
                                Ended = (string)dataReader["Ended"],
                                OfficialSite = (string)dataReader["OfficialSite"],
                                TheTvDb = (int)dataReader["TheTvDb"],
                                Weight = (int)dataReader["Weight"],
                                DvdCountry = (string)dataReader["DvdCountry"],
                                Summary = (string)dataReader["Summary"],
                                Updated = (int)dataReader["Updated"],
                                Href = (string)dataReader["Href"],
                                ImageMedium = (string)dataReader["ImageMedium"],
                                ImageOriginal = (string)dataReader["ImageOriginal"],
                                Imdb = (string)dataReader["Imdb"],
                                NetworkName = (string)dataReader["NetworkName"],
                                NetworkCountryCode = (string)dataReader["NetworkCountryCode"],
                                NetworkOfficialSite = (string)dataReader["NetworkOfficialSite"],
                                NextEpisodeHref = (string)dataReader["NextEpisodeHref"],
                                PreviousEpisodeHref = (string)dataReader["PreviousEpisodeHref"],
                                RatingAverage = (float?)dataReader["RatingAverage"],
                                ScheduleDays = (string)dataReader["ScheduleDays"],
                                ScheduleTime = (string)dataReader["ScheduleTime"],
                                TvRage = (int)dataReader["TvRage"],
                                WebChannelCountryCode = (string)dataReader["WebChannelCountryCode"],
                                WebChannelCountryName = (string)dataReader["WebChannelCountryName"],
                                WebChannelName = (string)dataReader["WebChannelName"]
                            };


                            tvShowList.Add(tvShow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tvShowList;
        }

        public async Task<List<Cast>> GetCastList(SqlCommand command)
        {
            List<Cast> castList = new List<Cast>();

            List<DbParameter> parameterList = new List<DbParameter>();
            command.Connection = this.GetConnection();
            using (DbDataReader dataReader = await command.ExecuteReaderAsync())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (await dataReader.ReadAsync())
                    {
                        var cast = new Cast
                        {
                            Id = (int)dataReader["Id"],
                            TvShowId = (int)dataReader["TvShowId"],
                            PersonName = (string)dataReader["PersonName"],
                            PersonBirthday = (string)dataReader["PersonBirthday"],
                            PersonGender = (string)dataReader["PersonGender"],
                            PersonDeathDay = (string)dataReader["PersonDeathDay"],
                            PersonHref = (string)dataReader["PersonHref"],
                            PersonImageMedium = (string)dataReader["PersonImageMedium"],
                            PersonImageOrginal = (string)dataReader["PersonImageOrginal"],
                            PersonCountryName = (string)dataReader["PersonCountryName"],
                            PersonUpdated = (int)dataReader["PersonUpdated"],
                            PersonNextEpisodeHref = (string)dataReader["PersonNextEpisodeHref"],
                            PersonPreviousEpisodeHref = (string)dataReader["PersonPreviousEpisodeHref"],
                            CharacterName = (string)dataReader["CharacterName"],
                            CharacterHref = (string)dataReader["CharacterHref"],
                            CharacterNextEpisodeHref = (string)dataReader["CharacterNextEpisodeHref"],
                            CharacterPreviousEpisodeHref = (string)dataReader["CharacterPreviousEpisodeHref"],
                            CharacterUrl = (string)dataReader["CharacterUrl"],
                            CharacterImageMedium = (string)dataReader["CharacterImageMedium"],
                            CharacterImageOrginal = (string)dataReader["CharacterImageOrginal"],
                            Self = (bool)dataReader["Self"],
                            Voice = (bool)dataReader["Voice"]
                        };

                        castList.Add(cast);
                    }
                }
            }
            return castList;
        }
        public async Task<int> InsertNewItemsAsync<T>(List<T> data, bool identityInsert = false) where T : BaseEntity
        {
            int result = 0;

            var tableName = typeof(T).Name;
            var connection = GetConnection();
            
            //Get Ids list from db
            SqlCommand command = new SqlCommand();
            command.CommandText = $"Select Id from {tableName}";
            command.Connection = connection;
            
            List<int> idsList = new List<int>();
            using (SqlDataReader res = await command.ExecuteReaderAsync())
            {
                while (res.Read())
                {
                    idsList.Add(res.GetInt32(0));
                }
            }

            //insert not exist data only 
            foreach (T item in data.Where(s => !idsList.Contains(s.Id)))
            {
                var sqlCommand = InsertCommand<T>(item, identityInsert);
                sqlCommand.Connection = connection;

                result += await sqlCommand.ExecuteNonQueryAsync();

            }
            await connection.CloseAsync();
            return result;
        }
    }
}
