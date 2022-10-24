using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    // underline pode ser usada se atributo é private
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context) 
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Computers);

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] string ram, [FromForm] string processor)
    {
        List<Computer> computers = _context.Computers.ToList();
        int id = computers.Last().Id + 1; 
        Computer computer = new Computer(id, ram, processor);
        _context.Computers.Add(computer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound(); // HttpNotFound()
        }

        return View(computer);
    }

    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update([FromForm] Computer computer)
    {
        _context.Computers.Update(computer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        _context.Computers.Remove(_context.Computers.Find(id));
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}