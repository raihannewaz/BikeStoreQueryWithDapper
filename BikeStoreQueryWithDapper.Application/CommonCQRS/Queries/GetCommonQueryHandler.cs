using BikeStoreQueryWithDapper.Domain.CommonQueryInterface;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CommonCQRS.Queries
{
    public class GetCommonQueryHandler<T> : IRequestHandler<GetCommonQuery<T>, List<T>> where T : class
    {
        private readonly ICommonQueryInterface<T> _commonQueryInterface;

        public GetCommonQueryHandler(ICommonQueryInterface<T> commonQueryInterface)
        {
            _commonQueryInterface = commonQueryInterface;
        }

        public async Task<List<T>> Handle(GetCommonQuery<T> request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "cteQuery":
                    var stockData = await _commonQueryInterface.GetStoreStock(request.cteQuery);
                    return stockData;
                case "bestOrderAmount":
                    var bestOrderAmount = await _commonQueryInterface.GetBestOrderAmount(request.bestOrderAmount);
                    return bestOrderAmount;
                default:
                    throw new ArgumentException("Invalid query.");
            }
        }
    }
}
