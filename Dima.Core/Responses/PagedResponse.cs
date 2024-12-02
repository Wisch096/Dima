﻿using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class PagedResponse<TData> : BaseResponse<TData> 
{
    [JsonConstructor]
    public PagedResponse(
        TData? data, 
        int totalCount,
        int currentPage, 
        int pageSize
        ) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(
        TData? data, 
        int code = Configuration.DefaultStatusCode, 
        string? message = null
        ) : base(data, code, message)
    {
        
    }
    
    public int CurrentPage { get; set; }
    public int TotalPages 
        => (int)Math.Ceiling((double)TotalCount / PageSize);
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }
}