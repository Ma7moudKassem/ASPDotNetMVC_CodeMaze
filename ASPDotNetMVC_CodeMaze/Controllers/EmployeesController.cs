namespace ASPDotNetMVC_CodeMaze.Controllers;

public class EmployeesController : Controller
{
    private readonly ApplicationDbContext _context;
    public EmployeesController(ApplicationDbContext context) =>
        _context = context;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        IEnumerable<Employee> employees = await _context.Employees.ToListAsync();

        return SortByDisplayIndex(employees);
    }

    public async Task<IActionResult> Index() =>
        View(await GetEmployeesAsync());

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        Employee? employee = await _context
            .Employees
            .FirstOrDefaultAsync(x => x.Id == id);

        if (employee is null) return NotFound();

        return View(employee);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        Employee? employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        if (employee is null) return NotFound();

        return View(employee);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        Employee? employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        if (employee is null) return NotFound();

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee)
    {

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Employee employee)
    {
        await Task.Run(() =>
        {
            _context.Employees.Update(employee);
        });

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Employee employee)
    {
        await Task.Run(() =>
        {
            _context.Employees.Remove(employee);
        });

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    static IEnumerable<Employee> SortByDisplayIndex(IEnumerable<Employee> employees)
    {
        int i = 1;
        employees.ToList().ForEach(e => { e.DisplayIndex = i; i++; });

        return employees;
    }

    [HttpPost]
    public IActionResult AddToCookies(string userName)
    {
        CookieOptions options = new();

        options.Expires = DateTime.Now.AddMinutes(1);

        Response.Cookies.Append("UserName", userName, options);

        return Ok();
    }

    [HttpGet]
    public IActionResult GetFromCookies()
    {
        string userName = Request.Cookies["UserName"];

        return Ok(userName);
    }

}