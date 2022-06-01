using AvaMina.Models;
using AvaMina.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public class PostsService :IPostsService
    {
        private readonly IPostRepository _post;

        public PostsService(IPostRepository post)
        {
            _post = post;
        }

        public IEnumerable<Post> GetAll()
        {
            return _post.List().OrderByDescending(x => x.CreateDate);
        }
        public Post GetById(int id)
        {
            return _post.Find(id);
        }
        public Post Add(Post post)
        {
             _post.Add(post);
            return post;
        }

        public Post Delete(Post post)
        {
             _post.Remove(post);
            return post;

        }
        public Post Update(int id, Post post)
        {
             _post.Update(id, post);
            return post;
        }
    }
}
