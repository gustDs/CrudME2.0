using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudME2.Models.Entidades
{
    //classe model responsável por mapear as tabelas do banco
    [Table("Usuario")]
    public class Usuario
    {
        //displayname = nome que será apresentado na View
        [Key]
        [Display(Description = "Código")]
        public int Id { get; set; }
        


        [Required(ErrorMessage ="Nome obrigatório!")] //caso o usuário não preencha o campo, essa mensagem será apresentada
        [Column(TypeName = "varchar(200)")] //tipo e tamanho da coluna do banco
        [DisplayName("Nome")] //nome que será apresentado na view
        [Display(Description = "Nome do Usuário")] //descrição do campo
        public string NomeUsuario { get; set; }


        [Required(ErrorMessage = "Idade obrigatória!")]
        [Display(Description = "Idade do Usuário")]
        
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Idade")]
        [Range(18, 100, ErrorMessage ="Idade deve ser no mínimo 18 e no máximo 100")] //validar input de dados utilizando range
        public int Idade { get; set; }


        [Required(ErrorMessage = "CPF obrigatório!")]
        [Column(TypeName = "varchar(20)")]
        [DisplayName("CPF")]
        [Display(Description = "CPF do Usuário")]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "Email obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(200)")]
        [DisplayName("Email")]
        [Display(Description = "Email do Usuário")]
        public string Email { get; set; }


        [Required]
        [Column(TypeName = "varchar(200)")]
        [DisplayName("Genero")]
        [Display(Description = "Genero do Usuário")]
        public int Genero { get; set; }



        [Required]
        [Display(Description = "Tipo de Usuário")]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Tipo")]
        public int Tipo { get; set; }


    }
}
