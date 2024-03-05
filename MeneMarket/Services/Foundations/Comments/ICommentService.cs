using MeneMarket.Models.Foundations.Comments;

namespace MeneMarket.Services.Foundations.Comments
{
    public interface ICommentService
    {
        ValueTask<Comment> AddCommentAsync(Comment comment);
        IQueryable<Comment> RetrieveAllComments();
        ValueTask<Comment> RetrieveCommentByIdAsync(Guid id);
        ValueTask<Comment> ModifyCommentAsync(Comment comment);
        ValueTask<Comment> RemoveCommentAsync(Guid id);
    }
}
