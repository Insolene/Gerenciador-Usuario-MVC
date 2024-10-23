using CreateUser.Models;
using CreateUser.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CreateUser.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository dataContext)
        {
            _userRepository = dataContext;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            UserModel users = _userRepository.GetUserId(id);
            return View(users);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            UserModel users = _userRepository.GetUserId(id);
            return View(users);

        }
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddUser(user);
                return RedirectToAction("Index");
            }
            return View("Add", user);
        }

        [HttpPost]
        public IActionResult Change(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.ChangeUser(user);
                return RedirectToAction("Index");
            }
            return View("Edit", user);
        }
    }
}
