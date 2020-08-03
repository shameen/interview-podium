using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Logic.Command
{
    /// <summary>
    /// Self-contained executable piece of work, similar to the Command Pattern.
    /// </summary>
    interface ICommand
    {
        Task ExecuteAsync();
    }
}
