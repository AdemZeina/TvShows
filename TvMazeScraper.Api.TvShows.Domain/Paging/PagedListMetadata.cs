using System;

namespace TvMazeScraper.Api.TvShows.Domain.Paging
{
    /// <summary>
    /// A non-enumerable version of the <see cref="PagedList{T}"/> class.
    /// </summary>
    [Serializable]
    public class PagedListMetadata : IPagedList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListMetadata"/> class.
        /// </summary>
        protected PagedListMetadata() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListMetadata"/> class.
        /// </summary>
        /// <param name="list">A <see cref="IPagedList"/> to copy metadata from.</param>
        public PagedListMetadata(IPagedList list)
        {
            PageCount = list.PageCount;
            TotalItemCount = list.TotalItemCount;
            CurrentPage = list.CurrentPage;
            PageIndex = list.PageIndex;
            PageSize = list.PageSize;
            HasPreviousPage = list.HasPreviousPage;
            HasNextPage = list.HasNextPage;
            IsFirstPage = list.IsFirstPage;
            IsLastPage = list.IsLastPage;
            FirstItemOnPage = list.FirstItemOnPage;
            LastItemOnPage = list.LastItemOnPage;
        }

        /// <summary>
        /// The total number of subsets within the superset.
        /// </summary>
        public int PageCount { get; protected set; }

        /// <summary>
        /// The total number of objects within the superset.
        /// </summary>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        /// The 1-based index of this subset within the superset.
        /// </summary>
        public int CurrentPage { get; protected set; }

        /// <summary>
        /// The 0-based index of this subset within the superset.
        /// </summary>
        public int PageIndex { get; protected set; }

        /// <summary>
        /// The maximum size of any individual subset within the superset.
        /// </summary>
        public int PageSize { get; protected set; }

        /// <summary>
        /// Returns <c>true</c> if this is NOT the first subset within the superset.
        /// </summary>
        public bool HasPreviousPage { get; protected set; }

        public int NextPage { get; protected set; }
        public int PreviousPage { get; protected set; }
        public int FirstPage { get; protected set; }
        public int LastPage { get; protected set; }

        /// <summary>
        /// Returns <c>true</c> if this is NOT the last subset within the superset.
        /// </summary>
        public bool HasNextPage { get; protected set; }

        /// <summary>
        /// Returns <c>true</c> if this is the first subset within the superset.
        /// </summary>
        public bool IsFirstPage { get; protected set; }

        /// <summary>
        /// Returns <c>true</c> if this is the last subset within the superset.
        /// </summary>
        public bool IsLastPage { get; protected set; }

        /// <summary>
        /// The 1-based index of the first item in this subset.
        /// </summary>
        public int FirstItemOnPage { get; protected set; }

        /// <summary>
        /// The 1-based index of the last item in this subset.
        /// </summary>
        public int LastItemOnPage { get; protected set; }
    }
}