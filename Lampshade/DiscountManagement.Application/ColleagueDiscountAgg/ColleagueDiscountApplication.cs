using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.ColleagueDiscountAgg;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Framework.Application;

namespace DiscountManagement.Application.ColleagueDiscountAgg
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository) => _colleagueDiscountRepository = colleagueDiscountRepository;

        public OperationResult Create(CreateColleagueDiscountVM command)
        {
            OperationResult result = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(c =>
                c.ProductId == command.ProductId && c.DiscountRate == command.DiscountRate))
                return result.Failed(ValidateMessage.IsDuplicated);

            var discount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(discount);
            _colleagueDiscountRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditColleagueDiscountVM command)
        {
            OperationResult result = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(c =>
                c.ProductId == command.ProductId && c.DiscountRate == command.DiscountRate && c.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var discount = _colleagueDiscountRepository.Get(command.Id);

            if (discount == null) return result.Failed(ValidateMessage.IsExist);

            discount.Edit(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteColleagueDiscountVM command)
        {
            OperationResult result = new OperationResult();

            var discount = _colleagueDiscountRepository.Get(command.Id);
            if (discount == null) return result.Failed(ValidateMessage.IsExist);

            discount.Delete();
            _colleagueDiscountRepository.SaveChanges();

            return result.Succeeded();
        }

        public EditColleagueDiscountVM GetDetailForEdit(long id) => _colleagueDiscountRepository.GetDetailForEdit(id);

        public DeleteColleagueDiscountVM GetDetailForDelete(long id) => _colleagueDiscountRepository.GetDetailForDelete(id);

        public IEnumerable<AdminColleagueDiscountVM> GetAllForAdmin(SearchColleagueDiscountVM search) => _colleagueDiscountRepository.GetAllForAdmin(search);
    }
}