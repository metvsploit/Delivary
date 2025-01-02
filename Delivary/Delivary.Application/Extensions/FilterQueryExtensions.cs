namespace Delivary.Application.Extensions
{
    public static class FilterQueryExtensions
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, int page, int size)
        {
            return queryable.Skip((page - 1) * size).Take(size);    
        }
    }
}
