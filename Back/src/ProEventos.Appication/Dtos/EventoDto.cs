using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProEventos.Domain;

namespace ProEventos.Appication.Dtos
{
    public class EventoDto
    {
         public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage ="{0} deve ter no mínimo 4 caracteres")]
        [MaxLength(50, ErrorMessage ="{0} deve ter no maximo 50 caracteres")]
        public string Tema { get; set; }

        [Display(Name = "Quantidade de Pessoas")]
        [Range(1, 120000, ErrorMessage ="A {0} deve ser de 1 a 120.000 pessoas")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage ="Formato de imagem inválido")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Phone(ErrorMessage = "Número de {0} inválido")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [Display(Name ="e-mail")]
        [EmailAddress(ErrorMessage ="E necessário ser um {0} válido ")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> PalestrantesEventos { get; set; }
    }
}