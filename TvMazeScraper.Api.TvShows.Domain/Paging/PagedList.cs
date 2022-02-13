using System;
using System.Collections.Generic;
using System.Linq;

namespace TvMazeScraper.Api.TvShows.Domain.Paging
{
    [Serializable]
    public class PagedList<T> : PagedListBase<T>
    {
        #region Ctors

        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
            : this(superset.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, x => superset.Count()) { }

        public PagedList(IEnumerable<T> subset, int pageNumber, int pageSize, Func<IEnumerable<T>, int> total)
            : base(pageNumber, pageSize, total(subset))
        {
            Subset.AddRange(subset);
        }

        public PagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalCount)
            : base(pageNumber, pageSize, totalCount)
        {
            Subset.AddRange(subset);
        }

        #endregion

    }
}