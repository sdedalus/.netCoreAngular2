using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTDNA_Coding_Task.Data
{
    public static class QueryableExtensions
    {
		/// <summary>
		/// Adds the query part.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queryable">The queryable.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="queryPart">The query part.</param>
		/// <returns></returns>
		public static IQueryable<T> AddOptionalQueryPart<T>(this IQueryable<T> queryable, Func<bool> condition, Func<IQueryable<T>, IQueryable<T>> queryPart)
		{
			if (condition())
			{
				return queryPart(queryable);
			}

			return queryable;
		}
	}
}
