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
    public IActionResult Create([FromForm] Lab lab)
    {

        if (!ModelState.IsValid)
        {
            return View(lab);
        }

        // checkIfLabExistsByNumber(number);
        // checkIfLabExistsByName(name);

        // List<Lab> labs = _context.Labs.ToList();
        // int id = labs.Last().Id + 1; 
        
        // Lab lab = new Lab(id, number, name, block);

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

    public IActionResult Update(int id)
    {
        Lab lab = _context.Labs.Find(id);
        return View(lab);
    }

    [HttpPost]
    public IActionResult Update([FromForm] Lab lab)
    {
        // checkIfLabExistsByNumber(lab.Number);
        // checkIfLabExistsByName(lab.Name);

         if (!ModelState.IsValid)
        {
            return View(lab);
        }

        _context.Labs.Update(lab);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound(); 
        }

        _context.Labs.Remove(lab);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    private void checkIfLabExistsByNumber(int number) 
    {    
        if(_context.Labs.Any(e => e.Number.Equals(number)))
            throw new Exception($"Já existe um laboratório com número {number}");
    }

    private void checkIfLabExistsByName(string name) 
    {    
        if(_context.Labs.Any(e => e.Name.Equals(name)))
            throw new Exception($"O laboratório {name} já existe");
    }
}