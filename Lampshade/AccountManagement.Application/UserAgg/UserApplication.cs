using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Domain.UserAgg;
using Framework.Application;
using Framework.Application.Hashing;

namespace AccountManagement.Application.UserAgg
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Create(CreateUserVM command)
        {
            OperationResult result = new OperationResult();

            if (_userRepository.IsExist(u =>
                u.Username == command.Username || u.Email == command.Email || u.Mobile == command.Mobile))
                return result.Failed(ValidateMessage.IsDuplicated);

            var path = "UserProfile";
            var picture = Uploader.ImageUploader(command.Picture, path, null!);

            var password = _passwordHasher.Hash(command.Password);

            var user = new User(command.Fullname, command.Username, command.Email, password, command.Mobile, picture,
                command.RoleId);

            _userRepository.Create(user);
            _userRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditUserVM command)
        {
            OperationResult result = new OperationResult();

            var user = _userRepository.Get(command.Id);
            if (user == null) return result.Failed(ValidateMessage.IsExist);

            if (_userRepository.IsExist(u =>
                (u.Username == command.Username || u.Email == command.Email || u.Mobile == command.Mobile) && u.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var path = "UserProfile";
            var picture = Uploader.ImageUploader(command.Picture, path, user.Picture);

            user.Edit(command.Fullname, command.Username, command.Email, command.Mobile, picture, command.RoleId);
            _userRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteUserVM command)
        {
            OperationResult result = new OperationResult();

            var user = _userRepository.Get(command.Id);
            if (user == null) return result.Failed(ValidateMessage.IsExist);

            user.Delete();
            _userRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult ChangePassword(ChangePasswordVM command)
        {
            OperationResult result = new OperationResult();

            var user = _userRepository.Get(command.Id);
            if (user == null) return result.Failed(ValidateMessage.IsExist);

            if (command.NewPassword != command.RePassword) return result.Failed("رمزهای عبور تطابق ندارند!");

            var newPassword = _passwordHasher.Hash(command.NewPassword);

            user.ChangePassword(newPassword);
            _userRepository.SaveChanges();

            return result.Succeeded();
        }

        public EditUserVM GetDetailForEdit(long id) => _userRepository.GetDetailForEdit(id);

        public DeleteUserVM GetDetailForDelete(long id) => _userRepository.GetDetailForDelete(id);

        public IEnumerable<AdminUserVM> GetAllForAdmin(SearchUserVM search) => _userRepository.GetAllForAdmin(search);
    }
}
