namespace Application.Commons.Models;

public class DefaultMessageResponse
{
    public string Message { get; set; }
}

public class ImageResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PaginationRequest
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}

public class PaginationResponse<T>
{
    public IEnumerable<T> Items { get; set; }
    public TodoPagination Pagination { get; set; }
}

public class TodoPagination
{
    public List<int> Prev { get; set; }
    public List<int> Next { get; set; }
}