using MeneMarket.Models.Foundations.Comments;
using MeneMarket.Services.Foundations.Comments;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : RESTFulController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Comment>> PostCommentAsync(Comment comment)
        {
            var httpContext = HttpContext;
            string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            comment.IpAddress = ipAddress;

            return await this.commentService.AddCommentAsync(comment);
        }

        [HttpGet]
        public ActionResult<IQueryable<Comment>> GetAllComments()
        {
            IQueryable<Comment> AllComments =
                this.commentService.RetrieveAllComments();

            return Ok(AllComments);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Comment>> GetCommentByIdAsync(Guid id) =>
            await this.commentService.RetrieveCommentByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<Comment>> PutCommentAsync(Comment comment) =>
            await this.commentService.ModifyCommentAsync(comment);

        [HttpDelete]
        public async ValueTask<ActionResult<Comment>> DeleteCommentAsync(Guid id) =>
            await this.commentService.RemoveCommentAsync(id);
    }
}