using VirusAnalyzer.Structures.Structs;

namespace VirusAnalyzer.Structures.Interfaces;

public interface IVirusChecker
{
    E_Threat GetFileThreat(FileData filedata);
}