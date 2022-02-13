namespace TvMazeScraper.Api.TvShows.Domain.Response
{
    public class PagedResponse<T> : Response<T>
    {
        public Controls Controls { get; set; } = new Controls();

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            Controls.CurrentPage = pageNumber;
            Controls.PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }


        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            Controls.CurrentPage = pageNumber;
            Controls.PageSize = pageSize;
            Controls.TotalRecords = totalRecords;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords, int totalPages,
            int firstPage, int lastPage, bool hasNextPage, bool hasPreviousPage, bool isFirstPage, bool isLastPage)
        {
            Controls.CurrentPage = pageNumber;
            Controls.PageSize = pageSize;
            Controls.TotalRecords = totalRecords;
            Controls.TotalPages = totalPages;
            Controls.FirstPage = firstPage;
            Controls.LastPage = lastPage;
            Controls.HasNextPage = hasNextPage;
            Controls.HasPreviousPage = hasPreviousPage;
            Controls.IsFirstPage = isFirstPage;
            Controls.IsLastPage = isLastPage;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}
