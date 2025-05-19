using Microsoft.AspNetCore.Mvc;
using PureAirPro.Common;
using PureAirPro.DBContext;

namespace PureAirPro.Controllers
{
	public class ProductOrderController : Controller
	{
		private readonly PureAirProWebContext _context;
		public ProductOrderController(PureAirProWebContext context)
		{
			_context = context;
		}
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
				try
				{
					_context.OrderDetails.Add(orderDetail);
					_context.SaveChanges();
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
