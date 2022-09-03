using System.Collections.Generic;

namespace Lingvo.Application.Common.Responses
{
    public record PaginatedList<T>
    {
        public PaginatedList(IEnumerable<T> content, int totalItems)
        {
            Content = content;
            TotalItems = totalItems;
        }

        public int TotalItems { get; init; }
        public IEnumerable<T> Content { get; init; }
    }
}
