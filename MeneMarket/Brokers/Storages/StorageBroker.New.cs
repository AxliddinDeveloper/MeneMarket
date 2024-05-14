using MeneMarket.Models.Foundations.News;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<News> News { get; set; }

        public async ValueTask<News> InsertNewsAsync(News news) =>
            await InsertAsync(news);

        public IQueryable<News> SelectAllNews() =>
            SelectAll<News>();

        public async ValueTask<News> SelectNewsById(Guid id) =>
            await this.SelectAsync<News>(id);

        public async ValueTask<News> DeleteNews(News news) =>
            await DeleteAsync(news);
    }
}