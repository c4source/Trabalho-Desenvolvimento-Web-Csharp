
using System.ComponentModel.DataAnnotations; //Attributes do C#

/*
 
Data Annotations: São ATTRIBUTES colocados nas propriedades do MODEL 
                  Fornece METADADADOS e regras de validação 
                  Como Obrigatoriedades e tamanho máximo

                         ----------------                   

                  ASP.NET pode usar essas informaçoes durante a validacao
                  do MODEL


 */

namespace Agendamento.Models
{
    public class Paciente
    {
        public int Id { get; set; } //Id p pesistencia do banco - cada paciente precisa de uma identificacao

        [Required] //Nome obrigatorio
        [MaxLength(100)] // maximo cem caracter
        public string? Nome { get; set; }

        [Required] //Cpf obrigatorio
        [MaxLength(14)] // Maximo de 14 caracteres (formato do CPF)
        public string? Cpf { get; set; }

        [Required] //Telefone obrigatorio
        [MaxLength(20)] //Maximo de 20 caracteres do telefone
        public string? Telefone { get; set; }

        [Required] //Telefone obrigatorio
        [MaxLength(200)] // Maximo de 200 caracteres para o endereço
        public string? Endereco { get; set; }

        [Required] //Endereço Obrigatorio 
        [Display(Name = "Data de nascimento")] // Interface que mostra para o usuario a propriedade como "Data de Nascimento"
        //Vai ser ultil no HTML, o razor consegue mostrar: "Data de nascimento"
        [DataType(DataType.Date)] //Indica que o data deve ser tratado como data. Na view, ajudara a representar o campo adequado
        public DateTime? DataNascimento { get; set; }





    }
}
