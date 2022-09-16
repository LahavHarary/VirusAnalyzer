using VirusAnalyzer.Structures.Interfaces;
using VirusAnalyzer.Structures.Structs;

namespace VirusAnalyzer.Core;

public class DummyVirusChecker : IVirusChecker 
{
    public E_Threat GetFileThreat(FileData filedata)
    {
        return E_Threat.NoThreat;
    }
}