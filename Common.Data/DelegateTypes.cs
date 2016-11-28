using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Data
{
    public delegate IOrderedQueryable<TEntity> OrderByFunc<TEntity>(IQueryable<TEntity> initialQuery);
}
