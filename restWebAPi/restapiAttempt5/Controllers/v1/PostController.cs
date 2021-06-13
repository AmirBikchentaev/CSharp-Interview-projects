using Microsoft.AspNetCore.Mvc;
using RestApi.Controllers.v1.Requests;
using restapiAttempt5.Contract;
using restapiAttempt5.Controllers.v1.Requests;
using restapiAttempt5.Controllers.v1.Responses;
using restapiAttempt5.Domain;
using restapiAttempt5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;


        public PostController(IPostService iPostService)
        {
            postService = iPostService;
        }

          
        [HttpGet(ApiRoutes.Posts.getAllAPI)]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await postService.GetPostsAsync());

        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = postService.getPostByIDAsync(postId);
            if (post == null)
            {
                return NotFound();

            }


            return Ok(post);
        }


        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId) 
        {
            var deleted = await postService.DeletePostAsync(postId);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();



        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post
            {
                ID = postId,
                Name = postRequest.Name

            };
            var updated = await postService.UpdatePostAsync(post);
            if (updated)
            {
                return Ok(post);
            }
            return NotFound();
        }


        [HttpPost(ApiRoutes.Posts.Create)] 
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest) 
        {
            var post = new Post { Name = postRequest.Name };

/*            if (post.ID == Guid.Empty)
            {
                post.ID = new Guid();
            }*/      
            await postService.CreatePostAsync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationURL = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.ID.ToString());

            var response = new postResponse { ID = post.ID };

            return Created(locationURL, post);
        }
        


    }
}
