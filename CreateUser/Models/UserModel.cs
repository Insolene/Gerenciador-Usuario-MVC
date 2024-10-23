using CreateUser.Enum;
using System.ComponentModel.DataAnnotations;

namespace CreateUser.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do Usuário é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail do Usuário é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail Informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha do Usuário é obrigatório")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Login do Usuário é obrigatório")]
        public string Login {  get; set; }
        public EnumProfile Profile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
