namespace Dima.Core.Responses;

public class PagedResponse<TData> : BaseResponse<TData> 
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }
}