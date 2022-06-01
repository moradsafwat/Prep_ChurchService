using AvaMina.Models;
using AvaMina.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public interface IPostsService 
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Add(Post post);
        Post Delete(Post post);
        Post Update(int id, Post post);



    }
}
