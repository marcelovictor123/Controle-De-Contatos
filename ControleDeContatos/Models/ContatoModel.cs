using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Digite o E-mail")]
        [EmailAddress(ErrorMessage ="E-mail invalido")]
        public string Email { get; set;}
        [Required(ErrorMessage ="Digite o celular")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string Celular { get; set; }
    }
}
