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
        Task<List<Post>> GetPostsAsync();
        Task<Post> getPostByIDAsync(Guid postID);
        Task<bool> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post updatedPost);
        Task<bool> DeletePostAsync(Guid postGuid);

    }
}
