using Microsoft.AspNetCore.Mvc;
using TestTask.Domain.Models;
using TestTask.Persistence;

namespace TestTaskNerdySoft.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementController : ControllerBase
{
    private readonly AnnouncementRepository _repository;

    public AnnouncementController(AnnouncementRepository announcementRepository)
    {
        _repository = announcementRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var announcements = await _repository.GetAsync();
        return Ok(announcements);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var announcement = await _repository.GetAsync(id);
        return Ok(announcement);
    }

    [HttpPost]
    public async Task PostAsync(Announcement announcement)
    {
        await _repository.AddAsync(announcement);
    }
    
    [HttpPut] 
    public async Task PutAsync(Announcement announcement)
    {
        await _repository.UpdateAsync(announcement);
    }
    
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}