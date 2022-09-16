using Microsoft.AspNetCore.Mvc;
using VirusAnalyzer.Models;
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
    public async Task<IActionResult> GetVirusThreatLocal([FromQuery]string path)
    {
        byte[] byteArray = System.IO.File.ReadAllBytes(path);

        FileData fileData = new FileData()
        {
            Data = byteArray,
            Extension = Path.GetExtension(path),
        };

        var threatLevel = await _virusChecker.GetFileThreat(fileData);
        return Ok(threatLevel.ToString());
    }

    [HttpPost]
    public async Task<IActionResult> GetVirusThreatLocal([FromBody] FileDataInput fileDataInput)
    {
        FileData fileData = new FileData()
        {
            Extension = fileDataInput.Extension,
            Data = fileDataInput.Data,
        };

        var threatLevel = await _virusChecker.GetFileThreat(fileData);
        return Ok(threatLevel.ToString());
    }
    
}