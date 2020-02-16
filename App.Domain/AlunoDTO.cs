using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
    public class AlunoDTO
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é de Preenchimento Obrigatório")]
        [StringLength(50, ErrorMessage = "Nome tem no mínimo 2 caracteres e no máximo 50", MinimumLength = 2)]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        [RegularExpression(@"[0-9]{4}\-[0-9]{2}", ErrorMessage = "A data está fora do formato AAAA-MM")]
        public string Data { get; set; }

        [Required(ErrorMessage = "O RA é de Preenchimento Obrigatório")]
        [Range(1,99, ErrorMessage = "O Intervalo para cadastro de RA é entre 1 a 99")]
        public int? RA { get; set; }
    }
}