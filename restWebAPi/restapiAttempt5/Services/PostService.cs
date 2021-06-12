using restapiAttempt5.Contract;
using restapiAttempt5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> Posts;

        public PostService()
        {
            Posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                Posts.Add(new Post
                {
                    ID = Guid.NewGuid(),
                    Name = $"Post name is {i}"
                });
            }
        }

        public Post getPostByID(Guid postID)
        {
            return Posts.SingleOrDefault(x => x.ID == postID);

        }

        public List<Post> GetPosts()
        {
            return Posts;

        }

        public bool UpdatePost(Post updatedPost)
        {
            var exists = getPostByID(updatedPost.ID) != null;

            if (!exists)
            {
                return false;

            }

            var index = Posts.FindIndex(x => x.ID == updatedPost.ID);
            Posts[index] = updatedPost;
            return true;
        }


        public bool DeletePost(Guid postGuid)
        {
            var NodeToDelete = getPostByID(postGuid);
            if (NodeToDelete == null) 
            {
                return false;

            }

            Posts.Remove(NodeToDelete);
            return true;


        }
    }
}
