using System.ComponentModel.DataAnnotations;

namespace CadastroContato.WEB.Models
{
    public class ViewModel
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo obrigatório")]
        public string? Nome { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string? Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression("^([1-9]{2}) (?:[2-8]|9[0-9])[0-9]{3} [0-9]{4}$", ErrorMessage = "99 99999 9999")]
        [Phone(ErrorMessage = "Celular inválido!")]
        public string? Celular { get; set; }
       

    }
}
