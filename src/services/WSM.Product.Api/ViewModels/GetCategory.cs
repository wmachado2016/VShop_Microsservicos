using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace WSM.Catalog.Api.ViewModels
{
    public class GetCategory : ICustomQueryable, IQueryPaging, IQuerySort
    {
        public int? Limit { get; set; } = 10;
        public int? Offset { get; set; }
        public string Sort { get; set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Name { get; set; }
    }
}
