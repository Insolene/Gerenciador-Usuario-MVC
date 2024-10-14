using CreateUser.Models;

namespace CreateUser.Repository
{
    public interface IContactRepository
    {
        ContactModel GetContactId(int id);    
        List<ContactModel> GetAll();
        ContactModel AddContact(ContactModel contact);
        ContactModel ChangeContact(ContactModel contact);
        bool Delete(int Id);
    }
}
