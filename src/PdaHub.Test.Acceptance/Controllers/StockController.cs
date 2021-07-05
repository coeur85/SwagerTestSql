using FluentAssertions;
using PdaHub.Test.Acceptance.Brokers;
using PdaHub.Test.Acceptance.Models.Response;
using PdaHub.Test.Acceptance.Models.Stock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PdaHub.Test.Acceptance.Controllers
{
    public class StockController
    {

        private readonly ApiBroker _api;
        private readonly string relevantUrl;

        public StockController()
        {
            _api = new ApiBroker();
            relevantUrl = "stock";
        }

        [Fact]
        public async Task ShouldReturnStringAsync()
        {
            //given
            string excpectedString = "Stock Controller Get method";

            // when
            string outputString = await _api.GetAsync(relevantUrl);

            // then
            outputString.Should().BeEquivalentTo(excpectedString);
        }
        [Fact]
        public async Task ShouldReturnSuccessResponseModelWithOrderInOnlyAsync()
        {
            // given
            DateTime orderDate = new DateTime(2019, 12, 11);
            int branchCode = 601;
            int orderNo = 15;
            StockReviewModel modelToPost = new StockReviewModel
            { BranchCode = branchCode, DocType = 2012, OrderNo = orderNo, OrderDate = orderDate };
            StockOrderModel expectedModel = new();
            expectedModel.Branch = branchCode;
            expectedModel.DocType = 2012;
            expectedModel.Orderno = orderNo;
            expectedModel.Orderdate = orderDate;

            // when
            SucessResponseModel<StockInOutDetailModel> responseModel =
                await _api.PostAsync<SucessResponseModel<StockInOutDetailModel>, StockReviewModel>(relevantUrl, modelToPost);

            // then
            responseModel.Succsess.Should().BeTrue();
            responseModel.Messages.Count.Should().Be(0);
            responseModel.Data.StockOrderIn.StockOrderItems.Count.Should().BeGreaterOrEqualTo(1);
            responseModel.Data.StockOrderIn.StockOrder.Branch.Should().Be(expectedModel.Branch);
            responseModel.Data.StockOrderIn.StockOrder.DocType.Should().Be(expectedModel.DocType);
            responseModel.Data.StockOrderIn.StockOrder.Orderno.Should().Be(expectedModel.Orderno);
            responseModel.Data.StockOrderIn.StockOrder.Orderdate.Should().Be(expectedModel.Orderdate);
            responseModel.Data.StockOrderOut.Should().BeNull();


        }
        [Fact]
        public async Task ShouldReturnSuccessResponseModelWithOrderInAndOutAsync()
        {
            // given
            DateTime orderInDate = new DateTime(2021, 3, 14);
            DateTime orderOutDate = new DateTime(2021, 3, 6);
            int branchInCode = 601;
            int branchOutCode = 607;
            int orderNo = 261;
            StockReviewModel modelToPost = new StockReviewModel
            { BranchCode = branchInCode, DocType = 2012, OrderNo = orderNo, OrderDate = orderInDate };
            StockOrderModel expectedOrderInModel = new();
            expectedOrderInModel.Branch = branchInCode;
            expectedOrderInModel.DocType = 2012;
            expectedOrderInModel.Orderno = orderNo;
            expectedOrderInModel.Orderdate = orderInDate;

            StockOrderModel expectedOrderOutModel = new();
            expectedOrderOutModel.Branch = branchOutCode;
            expectedOrderOutModel.DocType = 5052;
            expectedOrderOutModel.Invoiceno = orderNo;
            expectedOrderOutModel.Invoicedate = orderInDate;
            expectedOrderOutModel.Sites = branchInCode;
            expectedOrderOutModel.Orderno = 6;
            expectedOrderOutModel.Orderdate = orderOutDate;

            // when
            SucessResponseModel<StockInOutDetailModel> responseModel =
                await _api.PostAsync<SucessResponseModel<StockInOutDetailModel>, StockReviewModel>(relevantUrl, modelToPost);

            // then
            responseModel.Succsess.Should().BeTrue();
            responseModel.Messages.Count.Should().Be(0);
            responseModel.Data.StockOrderIn.StockOrderItems.Count.Should().BeGreaterOrEqualTo(1);
            responseModel.Data.StockOrderIn.StockOrder.Branch.Should().Be(expectedOrderInModel.Branch);
            responseModel.Data.StockOrderIn.StockOrder.DocType.Should().Be(expectedOrderInModel.DocType);
            responseModel.Data.StockOrderIn.StockOrder.Orderno.Should().Be(expectedOrderInModel.Orderno);
            responseModel.Data.StockOrderIn.StockOrder.Orderdate.Should().Be(expectedOrderInModel.Orderdate);
            responseModel.Data.StockOrderOut.Should().NotBeNull();

          //  responseModel.Data.StockOrderOut.StockOrder.Invoiceno.Should().Be()



        }
    }
}
