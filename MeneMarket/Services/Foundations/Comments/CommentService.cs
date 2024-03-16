using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.Comments;

namespace MeneMarket.Services.Foundations.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IStorageBroker storageBroker;

        public CommentService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Comment> AddCommentAsync(Comment comment)
        {
            comment.Id = Guid.NewGuid();
            return await this.storageBroker.InsertCommentAsync(comment);
        }

        public IQueryable<Comment> RetrieveAllComments() =>
          this.storageBroker.SelectAllComments();

        public async ValueTask<Comment> RetrieveCommentByIdAsync(Guid id) =>
            await this.storageBroker.SelectCommentByIdAsync(id);

        public async ValueTask<Comment> ModifyCommentAsync(Comment comment) =>
            await this.storageBroker.UpdateCommentAsync(comment);

        public async ValueTask<Comment> RemoveCommentAsync(Guid id)
        {
            var comment = await this.storageBroker.SelectCommentByIdAsync(id);

            return await this.storageBroker.DeleteCommentAsync(comment);
        }
    }
}
