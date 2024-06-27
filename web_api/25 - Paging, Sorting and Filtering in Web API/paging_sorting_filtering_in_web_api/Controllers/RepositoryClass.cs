using Microsoft.EntityFrameworkCore;
using paging_sorting_filtering_in_web_api.Models;
using System.Linq.Expressions;

namespace paging_sorting_filtering_in_web_api.Controllers
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync(ProductQueryParameters queryParameters);
        Task<int> GetTotalCountAsync();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductAsync(ProductQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(queryParameters.Filter))
            {
                products = products.Where(p => p.Name.Contains(queryParameters.Filter));
            }
            if(!string.IsNullOrEmpty(queryParameters.Category))
            {
                products = products.Where(p => p.Category == queryParameters.Category);
            }
            if(!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                products = products.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
            }

            return await products
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Products.CountAsync();
        }
    }

    public static class IQUeryableExtensions
    {
        public static IQueryable<T> OrderByCustom<T>(this IQueryable<T> source, string sortBy, string sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return source;

            var type = typeof(T);
            var property = type.GetProperty(sortBy);
            if (property == null)
                return source;

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var method = sortOrder.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(typeof(Queryable), method, new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
