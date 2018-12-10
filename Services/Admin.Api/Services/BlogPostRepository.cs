using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Admin.Api.Models;
using System;

namespace Admin.Api.Services
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly string _connectionString;

        public BlogPostRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<int> AddBlogPost(BlogPost blogPost)
        {
            using (var dbConnection = Connection)
            {
                try
                {

                    dbConnection.Open();
                    return await dbConnection.ExecuteAsync(
                        "insert into BlogPosts values(@title,@content)",
                        new
                        {
                            title = blogPost.Title,
                            content = blogPost.Content
                        });
                }
                catch(Exception e)
                {
                    return 0;
                }
            }
        }
    }
}
