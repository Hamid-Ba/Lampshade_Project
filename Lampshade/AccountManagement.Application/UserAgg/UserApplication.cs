using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Application.Contract.UserAgg;
using AccountManagement.Application.Contract.UserRoleAgg;
using AccountManagement.Domain.UserAgg;
using Framework.Application;
using Framework.Application.Authentication;
using Framework.Application.Email;
using Framework.Application.Hashing;

namespace AccountManagement.Application.UserAgg
{
    public class UserApplication : IUserApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IRoleApplication _roleApplication;
        private readonly IUserRoleApplication _userRoleApplication;

        public UserApplication(IAuthHelper authHelper, IEmailService emailService, IPasswordHasher passwordHasher, IUserRepository userRepository, IRoleApplication roleApplication, IUserRoleApplication userRoleApplication)
        {
            _authHelper = authHelper;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _roleApplication = roleApplication;
            _userRoleApplication = userRoleApplication;
        }

        public OperationResult Create(CreateUserVM command)
        {
            OperationResult result = new OperationResult();

            if (_userRepository.IsExist(u =>
                u.Username == command.Username.ToLower() || u.Email == command.Email || (!string.IsNullOrWhiteSpace(command.Mobile) && u.Mobile == command.Mobile)))
                return result.Failed(ValidateMessage.IsDuplicated);

            var path = "UserProfile";
            var picture = Uploader.ImageUploader(command.Picture, path, null!);

            var password = _passwordHasher.Hash(command.Password);

            var user = new User(command.Fullname, command.Username.ToLower(), command.Email, password, command.Mobile, picture);

            _userRepository.Create(user);
            _userRepository.SaveChanges();

            if (command.RolesId != null)
                _userRoleApplication.AddRolesToUser(user.Id, command.RolesId.ToArray());
            else
            {
                long[] roles = { 2 };
                _userRoleApplication.AddRolesToUser(user.Id, roles);
            }

            var message = $"{user.Fullname} عزیز به سایت Lampshade خوش آمدید";
            _emailService.SendEmail("خوش آمدید به Lampshade", message, user.Email);

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

            user.Edit(command.Fullname, command.Username.ToLower(), command.Email, command.Mobile, picture);
            _userRepository.SaveChanges();

            if (command.RolesId.Count > 0) _userRoleApplication.AddRolesToUser(user.Id, command.RolesId.ToArray());

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

        public OperationResult Login(LoginVM command, bool keepMe)
        {
            OperationResult result = new OperationResult();

            var user = _userRepository.GetUserBy(command.UserName);

            if (user == null) return result.Failed("کاربری با این مشخصات یافت نشد !");

            if (string.IsNullOrWhiteSpace(command.Password) || string.IsNullOrWhiteSpace(command.Email)) return result.Failed("تمام مقادیر را پر کنید");

            var passwordResult = _passwordHasher.Check(user.Password, command.Password);

            if (!passwordResult.Verified)
                return result.Failed("رمز عبور اشتباه می باشد!");

            if (!(user.Username == command.UserName.ToLower() && user.Email == command.Email))
                return result.Failed("نام کاربری یا پست الکترونیک صحیح نمی باشد!");

            var authVM = new AuthViewModel(user.Id, user.Fullname, user.Username,
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

            var message = $"{user.Fullname} گرامی ، رمز عبور جدید شما {command.NewPassword} می باشد";
            _emailService.SendEmail("رمز عبور جدید", message, user.Email);

            return result.Succeeded();
        }

        public EditUserVM GetDetailForEdit(long id) => _userRepository.GetDetailForEdit(id);

        public DeleteUserVM GetDetailForDelete(long id) => _userRepository.GetDetailForDelete(id);

        public IEnumerable<AdminUserVM> GetAllForAdmin(SearchUserVM search) => _userRepository.GetAllForAdmin(search);

        public bool IsUserHasPermissions(long permissionId, string userName)
        {
            var user = _userRepository.GetUserBy(userName.ToLower());
            var userRoles = user.UserRoles;

            var roles = userRoles.Select(r => r.RoleId).ToList();

            foreach (var roleId in roles) if (_roleApplication.IsRoleHasThePermission(roleId, permissionId)) return true;

            return false;
        }

        public bool IsColleague(string userName)
        {
            var user = _userRepository.GetUserBy(userName.ToLower());

            return user.UserRoles.Any(u => u.RoleId == 8);// 8 Belongs To Colleague Role
        }

        public IEnumerable<UserForSearchVM> GetAllForSearch() => _userRepository.GetAllForSearch();

        public OperationResult CanChangePassword(ForgetPasswordUserVM command)
        {
            var result = new OperationResult();

            var user = _userRepository.GetUserBy(command.Username);

            if (user != null)
                if (user.Email.ToLower() == command.Email.ToLower())
                    return result.Succeeded($"{user.Fullname} عزیز ، الان میتونی رمز عبورت رو تغییر بدی");

            return result.Failed("همچین کاربری وجود ندارد!");
        }

        public long GetUserIdBy(string userName) => _userRepository.GetUserBy(userName).Id;

    }
}
