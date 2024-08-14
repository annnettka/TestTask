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

    public async Task<IEnumerable<Announcement>> GetAsync(Guid id)
    {
        var announcement = await _db.Announcements.FindAsync(id);
        var samiliarAnnouncements = await GetSimilarAnnouncementAsync(id);

        return new[] { announcement }.Concat(samiliarAnnouncements);
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
        var foundedUser = await _db.Announcements.FindAsync(id);
        _db.Announcements.Remove(foundedUser);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Announcement>> GetSimilarAnnouncementAsync(Guid id)
    {
        var mainAnnouncement = await _db.Announcements.FindAsync(id);
        
        var titleWords = mainAnnouncement.Title.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        var announcement = await _db.Announcements
            .Where(a => a.Id != id && titleWords.Any(word => a.Title.Contains(word)))
            .OrderByDescending(a => a.DateAdded)
            .Take(3).ToListAsync();

        return announcement;
    }
}