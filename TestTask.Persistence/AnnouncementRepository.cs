using TestTask.Domain.Models;
using TestTask.Domain.Stores;

namespace TestTask.Persistence;

public class AnnouncementRepository : IAnnouncementStore
{
    public Task<IEnumerable<Announcement>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Announcement> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Announcement>> GetSimilarAnnouncementAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }
}