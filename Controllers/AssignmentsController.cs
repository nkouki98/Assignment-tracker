using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using assignment_tracker.Data;
using assignment_tracker.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class AssignmentsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AssignmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: Assignments
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var assignments = _context.Assignments.Where(a => a.UserId == user.Id).ToList();
        return View(assignments);
    }

    // GET: Assignments/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Assignments/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Description,Deadline,Course,InstructorEmail,Status")] Assignment assignment)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            assignment.UserId = user.Id;
            assignment.Status = "Pending"; // Set the default status
            _context.Add(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(assignment);
    }

    // Complete assignments
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Complete(int id)
    {
        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            return NotFound();
        }

        assignment.Status = "Completed";
        _context.Update(assignment);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Delete Assignments
    [HttpPost]
    [ValidateAntiForgeryToken]

public IActionResult Delete(int id)
{
    Console.WriteLine($"Delete called with id: {id}"); // Log the id
    var assignment = _context.Assignments.Find(id);
    if (assignment != null)
    {
        _context.Assignments.Remove(assignment);
        _context.SaveChanges();
        Console.WriteLine($"Assignment with id: {id} deleted");
    }
    else
    {
        Console.WriteLine($"Assignment with id: {id} not found");
    }
    return RedirectToAction(nameof(Index));
}


    // GET: Assignments/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            return NotFound();
        }
        return View(assignment);
    }

    // POST: Assignments/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]

public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Deadline,Course,InstructorEmail")] Assignment assignment)
{
    if (id != assignment.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            var existingAssignment = await _context.Assignments.FindAsync(id);
            if (existingAssignment == null)
            {
                return NotFound();
            }

            // Update fields excluding Status
            existingAssignment.Title = assignment.Title;
            existingAssignment.Description = assignment.Description;
            existingAssignment.Deadline = assignment.Deadline;
            existingAssignment.Course = assignment.Course;
            existingAssignment.InstructorEmail = assignment.InstructorEmail;

            _context.Update(existingAssignment);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AssignmentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(assignment);
}

    private bool AssignmentExists(int id)
    {
        return _context.Assignments.Any(e => e.Id == id);
    }
}
