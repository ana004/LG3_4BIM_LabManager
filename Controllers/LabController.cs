using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context) 
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Labs);
}