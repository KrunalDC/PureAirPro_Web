using Microsoft.AspNetCore.Mvc;
using PureAirPro.Common;
using PureAirPro.DBContext;

namespace PureAirPro.Controllers
{
    public class ProductOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductOrder()
        {
            OrderDetail orderDetail = new();
            orderDetail.OrderName = "PureAir Pro";
            orderDetail.Quantity = 1;
            orderDetail.Price = 49.99M;
            orderDetail.TotalPrice = 49.99M;
            return View(orderDetail);
        }
        public IActionResult AddProductOrder(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                var context = new PureAirProWebContext();
                try
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                    return Json(true);
                }
                catch (Exception ex)
                {

                }
            }
            return Json(true);
        }
    }
}
