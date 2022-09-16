using System.Text;
using VirusAnalyzer.Structures.Interfaces;
using VirusAnalyzer.Structures.Structs;
using VirusTotalNet;
using VirusTotalNet.ResponseCodes;
using VirusTotalNet.Results;

namespace VirusAnalyzer.Core;

public class VirusTotalChecker : IVirusChecker
{
    // TODO: Make the key not hardcoded.
    private const string VIRUS_TOTAL_API_KEY = "140a2997f15baf888800e3967bd507aace1bf4086b9fa0bd291fd6583f60f9c2";
    private VirusTotal _virusTotal;
    
    public VirusTotalChecker()
    { 
        _virusTotal = new VirusTotal(VIRUS_TOTAL_API_KEY);    
    }

    public async Task<E_Threat> GetFileThreat(FileData fileData)
    {
        //Use HTTPS instead of HTTP
        _virusTotal.UseTLS = true;

        //Create the EICAR test virus. See http://www.eicar.org/86-0-Intended-use.html
        //byte[] eicar = Encoding.ASCII.GetBytes(@"X5O!P%@AP[4\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*");

        //Check if the file has been scanned before.
        FileReport report = await _virusTotal.GetFileReportAsync(fileData.Data);

        E_Threat eThreat = E_Threat.NoThreat;
        if (report.Positives > 1 && report.Positives < 4)
        {
            eThreat = E_Threat.LowThreat;
        }
        else if (report.Positives > 4 && report.Positives < 7)
        {
            eThreat = E_Threat.MediumThreat;
        }
        else if (report.Positives > 7)
        {
            eThreat = E_Threat.HighThreat;
        }

        Console.WriteLine("Seen before: " + (report.ResponseCode == FileReportResponseCode.Present ? "Yes" : "No"));

        return eThreat;
    }
}