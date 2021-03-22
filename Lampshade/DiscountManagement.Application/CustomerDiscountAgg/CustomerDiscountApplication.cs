using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Framework.Application;

namespace DiscountManagement.Application.CustomerDiscountAgg
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;
        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository) => _customerDiscountRepository = customerDiscountRepository;

        public OperationResult Create(CreateCustomerDiscountVM command)
        {
            OperationResult result = new OperationResult();

            if (_customerDiscountRepository.IsExist(c =>
                c.ProductId == command.ProductId && c.DiscountRate == command.DiscountRate))
                return result.Failed(ValidateMessage.IsDuplicated);

            var discount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                command.StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.Reason);

            _customerDiscountRepository.Create(discount);
            _customerDiscountRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditCustomerDiscountVM command)
        {
            OperationResult result = new OperationResult();

            if (_customerDiscountRepository.IsExist(c =>
                c.ProductId == command.ProductId && c.DiscountRate == command.DiscountRate && c.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var discount = _customerDiscountRepository.Get(command.Id);

            if (discount == null) return result.Failed(ValidateMessage.IsExist);

            discount.Edit(command.ProductId, command.DiscountRate, command.StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.Reason);
            _customerDiscountRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteCustomerDiscountVM command)
        {
            OperationResult result = new OperationResult();

            var discount = _customerDiscountRepository.Get(command.Id);

            if (discount == null) return result.Failed(ValidateMessage.IsExist);

            discount.Delete();
            _customerDiscountRepository.SaveChanges();

            return result.Succeeded();
        }

        public IEnumerable<AdminCustomerDiscountVM> GetAllForAdmin(SearchCustomerDiscountVM search) => _customerDiscountRepository.GetAllForAdmin(search);

        public EditCustomerDiscountVM GetDetailForEdit(long id) => _customerDiscountRepository.GetDetailForEdit(id);

        public DeleteCustomerDiscountVM GetDetailForDelete(long id) => _customerDiscountRepository.GetDetailForDelete(id);

    }
}