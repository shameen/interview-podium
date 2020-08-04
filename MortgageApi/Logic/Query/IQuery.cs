using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Logic.Query
{
    /// <summary>
    /// Self-contained piece of work that returns data, without modifying the database.
    /// More info: "Command Pattern" and "Command-Query separation".
    /// </summary>
    /// <seealso cref="Command.ICommand"/>
    interface IQuery<T>
    {
        Task<T> ExecuteAsync();
    }
}
