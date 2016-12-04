using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Data
{
    /// <summary>
    /// Result of a batched context query that contains requested entries and the number
    /// of batches of the specified size available
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class BatchedResult<TResult> where TResult : class
    {
        public IList<TResult> Entries { get; set; }

        /// <summary>
        /// Overall number of batches currently available for entries of this time
        /// </summary>
        public int BatchCount { get; set; }
    }
}
