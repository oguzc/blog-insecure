using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using Blog.Api.Models;
using Dapper;

namespace Blog.Api.Services
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly string _connectionString;

        public BlogPostRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<bool> AddComment(BlogPostComment blogPostComment)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync(
                    "insert into BlogPostComments values(@blogPostId,@comment)",
                    new
                    {
                        blogPostId = blogPostComment.BlogPostId,
                        comment = blogPostComment.Comment
                    }) > 0;
            }
        }

        public async Task<BlogPost> GetBlogPostDetail(int blogPostId)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<BlogPost>("SELECT * FROM BlogPosts where Id=@blogPostId", new { blogPostId = blogPostId });
            }
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostList()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<BlogPost>("SELECT * FROM BlogPosts");
            }
        }

        public async Task<IEnumerable<BlogPostComment>> GetBlogPostCommentList(int blogPostId)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<BlogPostComment>("SELECT * FROM BlogPostComments where BlogPostId=@blogPostId", new { blogPostId = blogPostId });
            }
        }
    }
}
