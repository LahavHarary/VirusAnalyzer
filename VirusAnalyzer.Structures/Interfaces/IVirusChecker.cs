using VirusAnalyzer.Structures.Structs;

namespace VirusAnalyzer.Structures.Interfaces;

public interface IVirusChecker
{
    Task<E_Threat> GetFileThreat(FileData filedata);
}