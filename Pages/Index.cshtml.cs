using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using DataObjects;

namespace RazorPagesMovie.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }


    public DatabaseContext dbContext;
    public void OnGet()
    {
        dbContext = new DatabaseContext("Data Source=fairfielduniversity-4357-3260.database.windows.net;Database=AdventureWorksDW2019;Integrated Security=False;User ID=TestLogin;Password=SuperSecret52&&;Connection Timeout=30;");
    }

}