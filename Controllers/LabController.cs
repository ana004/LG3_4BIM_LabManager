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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] int number, [FromForm] string name, [FromForm] string block)
    {
        ErrorExistsByLabNumber(number);
        ErrorExistsByLabName(name);

        List<Lab> labs = _context.Labs.ToList();
        int id = labs.Last().Id + 1; 
        
        Lab lab = new Lab(id, number, name, block);

        _context.Labs.Add(lab);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound(); 
        }

        return View(lab);
    }

    private void ErrorExistsByLabNumber(int number) 
    {    
        if(_context.Labs.Any(e => e.Number.Equals(number)))
            throw new Exception($"Já existe um laboratório com número {number}");
    }

    private void ErrorExistsByLabName(string name) 
    {    
        if(_context.Labs.Any(e => e.Name.Equals(name)))
            throw new Exception($"O laboratório {name} já existe");
    }
}