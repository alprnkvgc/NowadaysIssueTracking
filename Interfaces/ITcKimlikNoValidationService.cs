namespace NowadaysIssueTracking.Interfaces
{
    public interface ITcKimlikNoValidationService
    {
        Task<bool> ValidateAsync(string tcKimlikNo, string firstName, string lastName, int birthYear);
    }

}
