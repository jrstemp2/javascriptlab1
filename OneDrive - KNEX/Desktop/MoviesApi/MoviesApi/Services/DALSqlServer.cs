using Dapper;
using Microsoft.Extensions.Configuration;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public class DALSqlServer : IDAL
    {
        private string connectionString;

        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("MoviesDB");
        }


        public IEnumerable<Movie> GetMoviesAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Films";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }

        public IEnumerable<Movie> GetMoviesByCategory(string category)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Films WHERE Category = @cat";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString, new { cat = category });
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }

        

        public Movie GetRandomMovie1()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Films ORDER BY NEWID()";
            Movie M = null;
            connection = new SqlConnection(connectionString);
            M = connection.QueryFirstOrDefault<Movie>(queryString);
            return M;
        }

        public Movie GetRandomMovieByCategory(string category)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Films WHERE Category = @val ORDER BY NEWID()";
            Movie M = null;
            connection = new SqlConnection(connectionString);
            M = connection.QueryFirstOrDefault<Movie>(queryString, new { val = category});
            return M;
        }


    }
}
