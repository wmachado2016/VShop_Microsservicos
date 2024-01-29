using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace WSM.Catalog.Api.ViewModels
{
    public class GetProduct : ICustomQueryable, IQueryPaging, IQuerySort
    {
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Name { get; set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Description { get; set; }
        [QueryOperator(Operator = WhereOperator.GreaterThan)]
        public decimal Price { get; set; }
        public int? Limit { get; set; } = 2;
        public int? Offset { get; set; }
        public string Sort { get; set; }
    }
}
