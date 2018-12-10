using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Admin.Api.Models;

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
                dbConnection.Open();
                return await dbConnection.ExecuteAsync(
                    "insert BlogPosts values(@id,@title,@content)",
                    new
                    {
                        id = blogPost.Id,
                        title = blogPost.Title,
                        content = blogPost.Content
                    });
            }
        }
    }
}
