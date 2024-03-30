using BikeStoreQueryWithDapper.Domain.CommonQuery;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StaffEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CommonCQRS.Queries
{
    public class GetCommonQueryHandler<T> : IRequestHandler<GetCommonQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly ICommonQueryInterface _commonQueryInterface;

        public GetCommonQueryHandler(ICommonQueryInterface commonQueryInterface)
        {
            _commonQueryInterface = commonQueryInterface;
        }

        public async Task<IEnumerable<T>> Handle(GetCommonQuery<T> request, CancellationToken cancellationToken)
        {
            switch (request.Query)
            {
                case "cteQuery":
                    var stockData = await _commonQueryInterface.GetStoreStock(request.cteQuery);
                    return stockData as IEnumerable<T>;


                case "bestOrderAmount":
                    var bestOrderAmount = await _commonQueryInterface.GetBestOrderAmount(request.bestOrderAmount);
                    return bestOrderAmount as IEnumerable<T>;


                case "customerOrdersByOutParam":
                    var customerOrdersByOutParam = await _commonQueryInterface.GetCustomerOrdersByIds(request.id, request.outParam, request.customerOrdersByOutParam);
                    return customerOrdersByOutParam as IEnumerable<T>;



                case "customerOrdersById":
                    var q  = request.customerOrdersById(request.id);
                    var customerOrdersById = await _commonQueryInterface.GetCustomerOrdersById(q);
                    return customerOrdersById as IEnumerable<T>;

                case "dateWiseBestSaleProduct":
                    var query = request.GetBestSalePoductByDate(request.startDate, request.endDate);
                    var dateWiseBestSaleProduct = await _commonQueryInterface.GetBestSaleProducByDate(query);
                    return dateWiseBestSaleProduct as IEnumerable<T>;


                case "dailyAvgSellig":
                    var dailyAvgSellig = await _commonQueryInterface.GetDailyAvgSale(request.dailyAvgSellig);
                    return dailyAvgSellig as IEnumerable<T>;


                case "mostSoldProdcut":
                    var mostSoldProdcut = await _commonQueryInterface.GetMostSoldProduct(request.mostSoldProdcut);
                    return mostSoldProdcut as IEnumerable<T>;

                case "productCat":
                    var productCat = await _commonQueryInterface.GetProductWithCat(request.id);
                    return productCat as IEnumerable<T>;

                default:
                    throw new ArgumentException("Invalid query.");
            }
        }



    }
}
