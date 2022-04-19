using Posting.Core.Entities;
using Posting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task AddPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);

            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("Sex"))
            {
                throw new Exception("Contain not allowed");
            }
            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }
        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}
