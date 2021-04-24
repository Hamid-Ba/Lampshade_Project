using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.UserAgg
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        [EmailAddress(ErrorMessage = "فرمت درست نیست!")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Password { get; set; }
        public string Mobile { get; set; }
        public IFormFile Picture { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = ValidateMessage.IsRequired)]
        public List<long> RolesId { get; set; }
    }

    public class EditUserVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        [EmailAddress(ErrorMessage = "فرمت درست نیست!")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public IFormFile Picture { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = ValidateMessage.IsRequired)]
        public List<long> RolesId { get; set; }
    }

    public class DeleteUserVM
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
    }

    public class AdminUserVM
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Picture { get; set; }
        public long[] RolesId { get; set; }
        public string RoleName { get; set; }
        public string CreationDate { get; set; }
    }

    public class SearchUserVM
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
    }

    public class ChangePasswordVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string RePassword { get; set; }
    }

    public class LoginVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserForSearchVM
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
    }

    public class ForgetPasswordUserVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Username { get; set; }
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Email { get; set; }
    }
}
