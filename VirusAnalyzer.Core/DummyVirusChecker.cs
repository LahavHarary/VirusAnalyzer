using VirusAnalyzer.Structures.Interfaces;
using VirusAnalyzer.Structures.Structs;

namespace VirusAnalyzer.Core;

public class DummyVirusChecker : IVirusChecker 
{
    public  Task<E_Threat> GetFileThreat(FileData filedata)
    {
        return Task.FromResult(E_Threat.NoThreat);
    }
}