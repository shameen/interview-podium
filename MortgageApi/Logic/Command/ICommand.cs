using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Logic.Command
{
    /// <summary>
    /// Self-contained executable piece of work that performs an action but does not return any data.
    /// More info: "Command Pattern" and "Command-Query separation". 
    /// </summary>
    /// <seealso cref="Query.IQuery{T}"/>
    interface ICommand
    {
        Task ExecuteAsync();
    }
}
