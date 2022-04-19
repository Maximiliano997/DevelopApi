using Posting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(int id);

        Task AddPost(Post post);

        Task<bool> UpdatePost(Post post);

        Task<bool> DeletePost(int id);
    }
}
