using MeneMarket.Models.Foundations.Comments;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Comment> InsertCommentAsync(Comment comment);
        IQueryable<Comment> SelectAllComments();
        ValueTask<Comment> SelectCommentByIdAsync(Guid id);
        ValueTask<Comment> UpdateCommentAsync(Comment comment);
        ValueTask<Comment> DeleteCommentAsync(Comment comment);
    }
}