using Microsoft.EntityFrameworkCore;


namespace BikeStoreQueryWithDapper.Domain.CommonQuery
{
    public class Pagination<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public bool HasPrevoius => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;


        public Pagination(List<T> item, int totalCount, int pageSize, int currentPage)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
            AddRange(item);

        }
        public static async Task<Pagination<T>> ToPagedList(IQueryable<T> source, int pageNum, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
           
            return new Pagination<T>(items, count, pageNum, pageSize);
        }
    }
}
