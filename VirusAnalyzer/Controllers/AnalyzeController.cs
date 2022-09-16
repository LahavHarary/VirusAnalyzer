using Microsoft.AspNetCore.Mvc;
using VirusAnalyzer.Structures.Interfaces;
using VirusAnalyzer.Structures.Structs;

namespace VirusAnalyzer.Controllers;

[ApiController]
[Route("[controller]")]

public class AnalyzeController : Controller
{
    private IVirusChecker _virusChecker;
    
    public AnalyzeController(IVirusChecker virusChecker)
    {
        _virusChecker = virusChecker;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        FileData fileData = new FileData();
        return Ok(_virusChecker.GetFileThreat(fileData).ToString());
    }

    
}