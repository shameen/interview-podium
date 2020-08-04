namespace PodiumInterview.MortgageApi.Models
{
    public class ApiApplicantCreatedResult : IApiResponse
    {
        public bool Success { get; set; }
        public long? UserId { get; set; }
    }
}