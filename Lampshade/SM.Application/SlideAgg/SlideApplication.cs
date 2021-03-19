using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using ShopManagement.Application.Contracts.SlideAgg;
using ShopManagement.Domain.SlideAgg;

namespace SM.Application.SlideAgg
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository) => _slideRepository = slideRepository;

        public OperationResult Create(CreateSlideVM command)
        {
            OperationResult result = new OperationResult();

            if (_slideRepository.IsExist(s => s.PictureName == command.PictureName))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var slide = new Slide(command.PictureName, command.PictureAlt, command.PictureTitle, command.Header,
                command.Title, command.Text, command.BtnText);

            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditSlideVM command)
        {
            OperationResult result = new OperationResult();

            if (_slideRepository.IsExist(s => s.PictureName == command.PictureName && s.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var slide = _slideRepository.Get(command.Id);

            if (slide == null) return result.Failed(ValidateMessage.IsExist);

            slide.Edit(command.PictureName, command.PictureAlt, command.PictureTitle, command.Header, command.Title, command.Text, command.BtnText);
            _slideRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteSlideVM command)
        {
            OperationResult result = new OperationResult();

            var slide = _slideRepository.Get(command.Id);
            if (slide == null) return result.Failed(ValidateMessage.IsExist);

            slide.Delete();
            _slideRepository.SaveChanges();

            return result.Succeeded();
        }

        public List<AdminSlideVM> GetAllForAdmin() => _slideRepository.GetAllForAdmin();

        public EditSlideVM GetDetailForEdit(long id) => _slideRepository.GetDetailForEdit(id);

        public DeleteSlideVM GetDetailForDelete(long id) => _slideRepository.GetDetailForDelete(id);
    }
}