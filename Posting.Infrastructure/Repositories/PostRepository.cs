using Microsoft.EntityFrameworkCore;
using Posting.Core.Entities;
using Posting.Core.Interfaces;
using Posting.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Posting.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostingContext _context;
        public PostRepository(PostingContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }
        
        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x=> x.PostId == id);
            return post;
        }

        public async Task AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.PostId);
            currentPost.Description = post.Description;
            currentPost.Date = post.Date;
            currentPost.Image = post.Image;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPost(id);
            _context.Posts.Remove(currentPost);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
