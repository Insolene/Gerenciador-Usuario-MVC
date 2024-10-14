using CreateUser.Data;
using CreateUser.Models;
using CreateUser.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CreateUser.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContatoController(IContactRepository dataContext) 
        {
            _contactRepository = dataContext; 
        }
        public IActionResult Index()
        {
         List<ContactModel> contacts = _contactRepository.GetAll();
            return View(contacts);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
          ContactModel contact = _contactRepository.GetContactId(id);
            return View(contact);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.GetContactId(id);
            return View(contact);
          
        }
        public IActionResult Delete(int id)
        {
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.AddContact(contact);
                return RedirectToAction("Index");
            }
            return View("Add", contact);
        }

        [HttpPost]
        public IActionResult Change(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.ChangeContact(contact);
                return RedirectToAction("Index");
            }
            return View("Edit", contact);   
        }
    }
}
