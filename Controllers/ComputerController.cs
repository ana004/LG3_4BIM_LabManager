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
    public IActionResult Create([FromForm] Computer computer)
    {
        // List<Computer> computers = _context.Computers.ToList();
        // int id = computers.Last().Id + 1; 

        if (!ModelState.IsValid)
        {
            return View(computer);
        }

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

    public IActionResult Update(int id)
    {
        Computer computer = _context.Computers.Find(id);
        return View(computer);
    }

    [HttpPost]
    public IActionResult Update([FromForm] Computer computer)
    {
        // Computer? computerNovo = _context.Computers.Find(computer.Id);

        // if(computerNovo == null)
        // {
        //     return NotFound(); 
        // }

        if (!ModelState.IsValid)
        {
            return View(computer);
        }

        _context.Computers.Update(computer);
        _context.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound(); 
        }

        _context.Computers.Remove(computer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}