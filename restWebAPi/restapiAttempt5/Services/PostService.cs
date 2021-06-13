using Microsoft.EntityFrameworkCore;
using restapiAttempt5.Contract;
using restapiAttempt5.Data;
using restapiAttempt5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Services
{
    public class PostService : IPostService
    {
        //context for manipulating the data;    
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();

        }  

        public async Task<Post> getPostByIDAsync(Guid postID)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.ID == postID);

        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            var created =  await _dataContext.SaveChangesAsync();
            return created > 0;
        }



        public async Task<bool> UpdatePostAsync(Post updatedPost)
        {

             _dataContext.Posts.Update(updatedPost);
            var updated =  await _dataContext.SaveChangesAsync();
            return updated >0;
        }


        public async Task<bool> DeletePostAsync (Guid postGuid)
        {
            //WTL : Why we need put await after deleted to return deleted>0;



            var post = await getPostByIDAsync(postGuid);
            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;


        }
    }
}
