using NowadaysIssueTracking.Interfaces;
using TCSorgu;

namespace NowadaysIssueTracking.Services;

public class TcKimlikNoValidationService : ITcKimlikNoValidationService
{
    private readonly KPSPublicSoapClient _client;

    public TcKimlikNoValidationService()
    {
        _client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
    }

    public async Task<bool> ValidateAsync(string tcKimlikNo, string firstName, string lastName, int birthYear)
    {
        try
        {
            var tcNo = Convert.ToInt64(tcKimlikNo);
            var ad = firstName.ToUpper();
            var soyad = lastName.ToUpper();

            TCKimlikNoDogrulaResponse response = await _client.TCKimlikNoDogrulaAsync(tcNo, ad, soyad, birthYear);

            return response.Body.TCKimlikNoDogrulaResult;
        }
        catch (Exception ex)
        {
            // Hata işleme
            Console.WriteLine($"Error validating TC Kimlik No: {ex.Message}");
            return false;
        }
    }
}