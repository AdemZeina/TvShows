using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TvMazeScraper.Api.TvShows.Domain;

namespace TvMazeScraper.Api.TvShows.Infrastructure.SqlServer.Db
{
    public class BaseDataAccess
    {
        private readonly IConfiguration _configuration;
        public BaseDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_configuration["connectionString"]);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }

        public SqlCommand InsertCommand<T>(T item, bool identityInsert = false)
        {
            List<string> tableColumns = GetTableColumns<T>(item, identityInsert);
            
            List<SqlParameter> parameters = GetSqlParameteresForCurrentData(tableColumns,item);

            string sqlQuery = BuildInsertQuery(item, identityInsert,parameters,tableColumns);
            
            var command = new SqlCommand();
            command.CommandType= CommandType.Text;
            command.CommandText = sqlQuery;
            command.Parameters.AddRange(parameters.ToArray());

            return command;
        }


        private string BuildInsertQuery<T>(T item, bool identityInsert, List<SqlParameter> parameters, List<string> tableColumns)
        {
            var tableName = typeof(T).Name;

            StringBuilder builder = new StringBuilder();

            if (identityInsert)
            {
                builder.Append($"SET IDENTITY_INSERT {tableName} ON ");
            }

            builder.Append($" insert into {tableName} (");
            builder.Append(string.Join(", ", tableColumns));
            builder.Append(") values (");
            
            builder.Append($" {string.Join(", ", parameters.Select(x => x.ParameterName))}) ");

            if (identityInsert)
            {
                builder.Append($" SET IDENTITY_INSERT {tableName} OFF");
            }

            return builder.ToString();
        }

        private List<SqlParameter> GetSqlParameteresForCurrentData<T>(List<string> tableColumns, T item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            Type type = typeof(T);
            
            foreach (var column in tableColumns)
            {
                var value = type.GetProperty(column)?.GetValue(item, null);
                var parameterName = $"@p{column}";

                parameters.Add(new SqlParameter(parameterName, value ?? ""));
            }

            return parameters;
        }

        private List<string> GetTableColumns<T>(T item, bool identityInsert)
        {
            List<string> columns = new List<string>();

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.GetType() == typeof(IEnumerable))
                    continue;

                if (!identityInsert)
                    if (property.Name.Equals("Id"))
                        continue;

                columns.Add(property.Name);
            }

            return columns;
        }
    }
}
