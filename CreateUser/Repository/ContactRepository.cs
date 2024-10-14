using CreateUser.Data;
using CreateUser.Models;

namespace CreateUser.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _contactRepository;
        public ContactRepository(DataContext dataContext) 
        {
            _contactRepository = dataContext;
        }
        public ContactModel GetContactId(int id)
        {
            return _contactRepository.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactModel> GetAll()
        {
           return _contactRepository.Contacts.ToList();
        }
        public ContactModel AddContact(ContactModel contact)
        {
            _contactRepository.Contacts.Add(contact);   
            _contactRepository.SaveChanges();
            return contact;
        }

        public ContactModel ChangeContact(ContactModel contact)
        {
            ContactModel contactDb = GetContactId(contact.Id);

            if (contactDb == null) throw new Exception("Houve um erro na atualização do contato"); 

            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.Cell = contact.Cell;

            _contactRepository.Contacts.Update(contactDb);
            _contactRepository.SaveChanges(); 

            return contactDb; 
        }

        public bool Delete(int Id)
        {
            ContactModel contactDb = GetContactId(Id);

            if (contactDb == null) throw new Exception("Houve um erro na Deleção do contato");
            _contactRepository.Contacts.Remove(contactDb);
            _contactRepository.SaveChanges(); 
            return true;
        }
    }
}
