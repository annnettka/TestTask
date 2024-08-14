using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Infrastructure;
using TestTask.Domain.Models;
using TestTask.Domain.Stores;

namespace TestTask.Persistence;

public class AnnouncementRepository : IAnnouncementStore
{
    private readonly AppDbContext _db;
    
    public AnnouncementRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<Announcement>> GetAsync()
    {
        return await _db.Announcements.ToListAsync();
    }

    public async Task<Announcement> GetAsync(Guid id)
    {
        return await _db.Announcements.FindAsync(id);
    }

    public async Task AddAsync(Announcement announcement)
    {
        await _db.Announcements.AddAsync(announcement);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Announcement announcement)
    {
        _db.Announcements.Update(announcement);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var foundedUser = await GetAsync(id);
        _db.Announcements.Remove(foundedUser);
        await _db.SaveChangesAsync();
    }

    public Task<IEnumerable<Announcement>> GetSimilarAnnouncementAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }
}