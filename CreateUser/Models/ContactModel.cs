using System.ComponentModel.DataAnnotations;

namespace CreateUser.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do contato é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail do contato é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail Informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Celular do contato é obrigatório")]
        [Phone(ErrorMessage ="Celular informado não é valido")]
        public string Cell { get; set; }
    }
}
