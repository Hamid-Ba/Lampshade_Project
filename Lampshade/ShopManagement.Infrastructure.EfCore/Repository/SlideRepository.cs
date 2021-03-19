using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.SlideAgg;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;
        public SlideRepository(ShopContext context) : base(context) => _context = context;

        public List<AdminSlideVM> GetAllForAdmin() => _context.Slides.Select(s =>
            new AdminSlideVM()
            {
                Id = s.Id,
                Header = s.Header,
                PictureName = s.PictureName,
                Title = s.Title
            }).ToList();

        public EditSlideVM GetDetailForEdit(long id) => _context.Slides.Where(s => s.Id == id).Select(s =>
            new EditSlideVM()
            {
                Id = s.Id,
                Title = s.Title,
                PictureName = s.PictureName,
                Header = s.Header,
                BtnText = s.BtnText,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Text = s.Text
            }).FirstOrDefault();

        public DeleteSlideVM GetDetailForDelete(long id) => _context.Slides.Where(s => s.Id == id).Select(s =>
            new DeleteSlideVM()
            {
                Id = s.Id,
                Header = s.Header
            }).FirstOrDefault();
    }
}