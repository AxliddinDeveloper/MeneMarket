using MeneMarket.Models.Foundations.Comments;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Comment> InsertCommentAsync(Comment client);
        IQueryable<Comment> SelectAllComments();
        ValueTask<Comment> SelectCommentByIdAsync(Guid clientId);
        ValueTask<Comment> UpdateCommentAsync(Comment client);
        ValueTask<Comment> DeleteCommentAsync(Comment client);
    }
}