using System;
using System.Collections;
using System.Collections.Generic;

namespace TvMazeScraper.Api.TvShows.Domain.Paging
{
    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index
    /// and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    /// <typeparam name="T">The type of object the collection contains.</typeparam>
    /// <seealso cref="IPagedList{T}"/>
    /// <seealso cref="List{T}"/>
    public abstract class PagedListBase<T> : PagedListMetadata, IPagedList<T>
    {
        #region Base

        protected readonly List<T> Subset = new List<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListBase{T}"/> class.
        /// </summary>
        protected internal PagedListBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListBase{T}"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based index of the subset of objects contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <param name="totalItemCount">The size of the superset.</param>
        /// <exception cref="ArgumentOutOfRangeException">The specified <paramref name="pageNumber"/> cannot be less than 1.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified <paramref name="pageSize"/> cannot be less than 1.</exception>
        protected internal PagedListBase(int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "pageNumber cannot be less than 1");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "pageSize cannot be less than 1");

            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            PageIndex = pageNumber - 1;

            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

            HasPreviousPage = CurrentPage > 1;
            HasNextPage = CurrentPage < PageCount;

            NextPage = IsLastPage ? NextPage = CurrentPage : NextPage = CurrentPage + 1;

            PreviousPage = IsFirstPage ? PreviousPage = CurrentPage : PreviousPage = CurrentPage - 1;

            IsFirstPage = CurrentPage == 1;
            IsLastPage = CurrentPage >= PageCount;

            FirstPage = 1;
            LastPage = PageCount;

            FirstItemOnPage = (CurrentPage - 1) * PageSize + 1;
            var lastPageSize = FirstItemOnPage + PageSize - 1;

            LastItemOnPage = lastPageSize > TotalItemCount ? TotalItemCount : lastPageSize;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="PagedListBase{T}"/>.
        /// </summary>
        /// <returns>
        /// An enumerator for the <see cref="PagedListBase{T}"/>.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="PagedListBase{T}"/>.
        /// </summary>
        /// <returns>
        /// An enumerator for the <see cref="PagedListBase{T}"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The 0-based index of the element to retrieve.</param>
        public T this[int index]
        {
            get
            {
                return Subset[index];
            }
        }

        /// <summary>
        /// Gets the number of objects in this subset.
        /// </summary>
        public int Count
        {
            get
            {
                return Subset.Count;
            }
        }

        /// <summary>
        /// Gets a non-enumerable copy of this paged list.
        /// </summary>
        public IPagedList Metadata
        {
            get
            {
                return new PagedListMetadata(this);
            }
        }

        #endregion

    }
}