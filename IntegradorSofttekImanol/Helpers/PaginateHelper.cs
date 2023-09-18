using IntegradorSofttekImanol.Models.DTOs;

namespace IntegradorSofttekImanol.Helpers
{
    public static class PaginateHelper
    {

        public static PaginateDto<T> Paginate<T>(IEnumerable<T> itemsToPaginate, int currentPage, string url)
        {
            int pageSize = 10;
            var totalItems = itemsToPaginate.ToList().Count;
            var paginateItems = itemsToPaginate.Skip((currentPage - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();

            var totalPages = (int)Math.Ceiling((double) totalItems / pageSize);

            var prevUrl = currentPage > 1 ? $"{url}?page={currentPage - 1}" : null;
            var nextUrl = currentPage < 1 ? $"{url}?page={currentPage + 1}" : null;

            return new PaginateDto<T>()
            {
                TotalPages = totalPages,
                CurrentPage = currentPage,
                TotalItems = totalItems,
                PageSize = pageSize,
                Items = paginateItems,
                PrevUrl = prevUrl,
                NextUrl = nextUrl

            };

        }


    }
}
