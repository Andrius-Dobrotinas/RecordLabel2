using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Data
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntry> GetBatch<TEntry>(this IOrderedQueryable<TEntry> query, int batch, int itemsPerBatch)
        {
            return query.Skip((batch - 1) * itemsPerBatch).Take(itemsPerBatch);
        }
    }
}
