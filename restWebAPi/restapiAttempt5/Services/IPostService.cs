using restapiAttempt5.Contract;
using restapiAttempt5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Services
{
    public interface  IPostService
    {
        List<Post> GetPosts();
        Post getPostByID(Guid postID);

        bool UpdatePost(Post updatedPost);
        public bool DeletePost(Guid postGuid);

    }
}
