using CreateUser.Data;
using CreateUser.Models;

namespace CreateUser.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _userRepository
            ;
        public UserRepository(DataContext dataContext) 
        {
            _userRepository = dataContext;
        }
       

        public UserModel GetUserId(int id)
        {
            return _userRepository.Users.FirstOrDefault(x => x.Id == id);
        }

        List<UserModel> IUserRepository.GetAll()
        {
            return _userRepository.Users.ToList();
        }

        public UserModel AddUser(UserModel user)
        {
            _userRepository.Users.Add(user);
            _userRepository.SaveChanges();
            return user;
        }

        public UserModel ChangeUser(UserModel user)
        {
            UserModel userDb = GetUserId(user.Id);

            if (userDb == null) throw new Exception("Houve um erro na atualização do contato");

            userDb.Name = user.Name;
            userDb.Email = user.Email;
            userDb.Login = user.Login;

            _userRepository.Users.Update(userDb);
            _userRepository.SaveChanges();

            return userDb;
        }
        public bool Delete(int Id)
        {
            UserModel contactDb = GetUserId(Id);

            if (contactDb == null) throw new Exception("Houve um erro na Deleção do contato");
            _userRepository.Users.Remove(contactDb);
            _userRepository.SaveChanges();
            return true;
        }
    }

    
}
