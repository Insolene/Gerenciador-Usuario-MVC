using CreateUser.Models;

namespace CreateUser.Repository
{
    public interface IUserRepository
    {
        UserModel GetUserId(int id);    
        List<UserModel> GetAll();
        UserModel AddUser(UserModel user);
        UserModel ChangeUser(UserModel user);
        bool Delete(int Id);
    }
}
