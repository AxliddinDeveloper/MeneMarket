using MeneMarket.Models.Foundations.Comments;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Comment> Comments { get; set; }

        public async ValueTask<Comment> InsertCommentAsync(Comment comment) =>
            await InsertAsync(comment);

        public IQueryable<Comment> SelectAllComments() =>
            SelectAll<Comment>();

        public async ValueTask<Comment> SelectCommentByIdAsync(Guid id) =>
            await SelectAsync<Comment>(id);

        public async ValueTask<Comment> UpdateCommentAsync(Comment comment) =>
            await UpdateAsync(comment);

        public async ValueTask<Comment> DeleteCommentAsync(Comment comment) =>
            await DeleteAsync(comment);
    }
}
