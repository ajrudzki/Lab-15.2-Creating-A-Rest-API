using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab_15._2_Creating_A_Rest_API
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public long id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public static Random rand = new Random();
        public static void Create(string title, string category)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=MovieAPI;user id=testuser;password=abc123");
            Movie movie = new Movie()
            {
                Title = title,
                Category = category
            };
            db.Insert(movie);
        }

        public static List<Movie> ReadAll()
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=MovieAPI;user id=testuser;password=abc123");
            List<Movie> M = db.Query<Movie>($"select * from [Movie]").AsList<Movie>();
            return M;
        }

        public static List<Movie> CategorySearch(string category)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=MovieAPI;user id=testuser;password=abc123");
            List<Movie> M = db.Query<Movie>($"select * from [Movie] where Category = {category}").AsList<Movie>();
            return M;
        }

        public static List<Movie> TitleSearch(string title)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=MovieAPI;user id=testuser;password=abc123");
            List<Movie> M = db.Query<Movie>($"select * from [Movie] where Title = {title}").AsList<Movie>();
            return M;
        }

        public static Movie RandomMovie()
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=MovieAPI;user id=testuser;password=abc123");
            List<Movie> M = db.Query<Movie>($"select * from [Movie]").AsList<Movie>();
            int result = rand.Next(0, M.Count);
            return M[result];
        }

        public static Movie RandomCategory(string category)
        {
            List<Movie> M = new List<Movie>();
            int result = rand.Next(0, M.Count);
            return M[result];
        }
    }   
}
