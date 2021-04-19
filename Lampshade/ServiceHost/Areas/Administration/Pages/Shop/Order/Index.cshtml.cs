using System.Collections.Generic;
using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.OrderAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Order
{
    public class IndexModel : PageModel
    {
        private readonly IUserApplication _userApplication;
        private readonly IOrderApplication _orderApplication;

        public IEnumerable<AdminOrderVM> Orders { get; set; }

        public SearchOrderVM Search { get; set; }
        public SelectList Users { get; set; }

        public IndexModel(IUserApplication userApplication, IOrderApplication orderApplication)
        {
            _userApplication = userApplication;
            _orderApplication = orderApplication;
        }

        public void OnGet(SearchOrderVM search)
        {
            Users = new SelectList(_userApplication.GetAllForSearch(), "Id", "Fullname");
            Orders = _orderApplication.GetAllForAdmin(search);
        }

        public IActionResult OnGetPaymentSuccedded(long id)
        {
            _orderApplication.MakePaymentSuccedded(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetChangeStatus(long id)
        {
            var order = _orderApplication.GetDetailForChangeStatus(id);
            return Partial("ChangeStatus", order);
        }

        public IActionResult OnPostChangeStatus(ChangeStatusOrderVM command)
        {
            var result = _orderApplication.ChangeStatus(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetItems(long id)
        {
            var orderItems = _orderApplication.GetAllItemsForAdminBy(id);
            return Partial("Items", orderItems);
        }

        public IActionResult OnGetCustomer(long id)
        {
            var customer = _orderApplication.GetDetailOfOrderCustomer(id);
            return Partial("Customer", customer);
        }

        public IActionResult OnGetDelete(long id)
        {
            var deleteOrder = _orderApplication.GetDetailForDelete(id);
            return Partial("Delete", deleteOrder);
        }

        public IActionResult OnPostDelete(DeleteOrderVM command)
        {
            var result = _orderApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}
