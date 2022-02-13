using System.Collections.Generic;

namespace TvMazeScraper.Api.TvShows.Domain.Paging
{
    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index
    /// and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    /// <typeparam name="T">The type of object the collection contains.</typeparam>
    /// <seealso cref="IEnumerable{T}"/>
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        /// <summary>
        /// Gets the element at the specified index.
        /// </summary> 
        /// <param name="index">The 0-based index of the element to retrieve.</param>
        T this[int index] { get; }

        /// <summary>
        /// Gets the number of objects in this subset.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a non-enumerable copy of this paged list.
        /// </summary>
        IPagedList Metadata { get; }
    }

    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index
    /// and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    public interface IPagedList
    {
        /// <summary>
        /// The total number of subsets within the superset.
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// The total number of objects within the superset.
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// The 1-based index of this subset within the superset.
        /// </summary>
        int CurrentPage { get; }

        /// <summary>
        /// The 0-based index of this subset within the superset.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// The maximum size of any individual subset within the superset.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Returns <c>true</c> if this is NOT the first subset within the superset.
        /// </summary>
        bool HasPreviousPage { get; }

        int NextPage { get; }
        int PreviousPage { get; }

        int FirstPage { get; }
        int LastPage { get; }

        /// <summary>
        /// Returns <c>true</c> if this is NOT the last subset within the superset.
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// Returns <c>true</c> if this is the first subset within the superset.
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Returns <c>true</c> if this is the last subset within the superset.
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// The 1-based index of the first item in this subset.
        /// </summary>
        int FirstItemOnPage { get; }

        /// <summary>
        /// The 1-based index of the last item in this subset.
        /// </summary>
        int LastItemOnPage { get; }
    }
}