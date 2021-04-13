using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Domain.UserAgg;
using Framework.Application;
using Framework.Application.Authentication;
using Framework.Application.Hashing;

namespace AccountManagement.Application.UserAgg
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;

        public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher, IAuthHelper authHelper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateUserVM command)
        {
            OperationResult result = new OperationResult();

            if (_userRepository.IsExist(u =>
                u.Username == command.Username.ToLower() || u.Email == command.Email || (!string.IsNullOrWhiteSpace(command.Mobile) &&  u.Mobile == command.Mobile)))
                return result.Failed(ValidateMessage.IsDuplicated);

            var path = "UserProfile";
            var picture = Uploader.ImageUploader(command.Picture, path, null!);

            var password = _passwordHasher.Hash(command.Password);

            var user = new User(command.Fullname, command.Username.ToLower(), command.Email, password, command.Mobile, picture,
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
                (u.Username == command.Username.ToLower() || u.Email == command.Email || (!string.IsNullOrWhiteSpace(command.Mobile) && u.Mobile == command.Mobile)) && u.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var path = "UserProfile";
            var picture = Uploader.ImageUploader(command.Picture, path, user.Picture);

            user.Edit(command.Fullname, command.Username.ToLower(), command.Email, command.Mobile, picture, command.RoleId);
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

        public OperationResult Login(LoginVM command,bool keepMe)
        {
            OperationResult result = new OperationResult();

            var user = _userRepository.GetUserBy(command.UserName);

            if (user == null) return result.Failed("کاربری با این مشخصات یافت نشد !");

            var passwordResult = _passwordHasher.Check(user.Password, command.Password);

            if (!passwordResult.Verified)
                return result.Failed("رمز عبور اشتباه می باشد!");

            if (!(user.Username == command.UserName.ToLower() && user.Email == command.Email))
                return result.Failed("نام کاربری یا پست الکترونیک صحیح نمی باشد!");

            var authVM = new AuthViewModel(user.Id, user.RoleId, user.Role.Name, user.Fullname, user.Username,
                user.Mobile, keepMe);

            _authHelper.Signin(authVM);

            return result.Succeeded();
        }

        public void Logout() => _authHelper.SignOut();

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
