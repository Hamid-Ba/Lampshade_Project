using System.Collections.Generic;
using Framework.Application;

namespace AccountManagement.Application.Contract.UserAgg
{
    public interface IUserApplication
    {
        OperationResult Create(CreateUserVM command);
        OperationResult Edit(EditUserVM command);
        OperationResult Delete(DeleteUserVM command);
        OperationResult Login(LoginVM command, bool keepMe);
        void Logout();
        OperationResult ChangePassword(ChangePasswordVM command);
        EditUserVM GetDetailForEdit(long id);
        DeleteUserVM GetDetailForDelete(long id);
        IEnumerable<AdminUserVM> GetAllForAdmin(SearchUserVM search);
        IEnumerable<UserForSearchVM> GetAllForSearch();
        bool IsUserHasPermissions(long permissionId, string userName);
        bool IsColleague(string userName);
        long GetUserIdBy(string userName);
        OperationResult CanChangePassword(ForgetPasswordUserVM command);
    }
}
