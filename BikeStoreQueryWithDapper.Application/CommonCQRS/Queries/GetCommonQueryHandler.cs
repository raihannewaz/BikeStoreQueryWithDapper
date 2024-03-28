using BikeStoreQueryWithDapper.Domain.CommonQuery;
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
        private readonly ICommonQueryInterface _commonQueryInterface;

        public GetCommonQueryHandler(ICommonQueryInterface commonQueryInterface)
        {
            _commonQueryInterface = commonQueryInterface;
        }

        public async Task<List<T>> Handle(GetCommonQuery<T> request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "cteQuery":
                    var stockData = await _commonQueryInterface.GetStoreStock(request.cteQuery);
                    return stockData as List<T>;


                case "bestOrderAmount":
                    var bestOrderAmount = await _commonQueryInterface.GetBestOrderAmount(request.bestOrderAmount);
                    return bestOrderAmount as List<T>;


                case "customerOrdersByOutParam":
                    var customerOrdersByOutParam = await _commonQueryInterface.GetCustomerOrdersById(request.id, request.outParam, request.customerOrdersByOutParam);
                    return customerOrdersByOutParam as List<T>;


                case "dateWiseBestSaleProduct":
                    var query = request.GetBestSalePoductByDate(request.startDate, request.endDate);
                    var dateWiseBestSaleProduct = await _commonQueryInterface.GetBestSaleProducByDate(query);
                    return dateWiseBestSaleProduct as List<T>;

                case "dailyAvgSellig":
                    var dailyAvgSellig = await _commonQueryInterface.GetDailyAvgSale(request.dailyAvgSellig);
                    return dailyAvgSellig as List<T>;

                case "mostSoldProdcut":
                    var mostSoldProdcut = await _commonQueryInterface.GetMostSoldProduct(request.mostSoldProdcut);
                    return mostSoldProdcut as List<T>;

                default:
                    throw new ArgumentException("Invalid query.");
            }
        }

    }
}
