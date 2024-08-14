using Microsoft.AspNetCore.Mvc;
using TestTask.Persistence;

namespace TestTaskNerdySoft.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementController : ControllerBase
{
    private readonly AnnouncementRepository _announcementRepository;

    public AnnouncementController(AnnouncementRepository announcementRepository)
    {
        _announcementRepository = announcementRepository;
    }
}