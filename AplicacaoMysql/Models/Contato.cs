using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoMysql.Models
{

    [Table("Contato")]
    public class Contato
    {

        //chamando coluna auto increment

        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }


        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }


        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }


        [Display(Name = "Tel")]
        [Column("Tel")]
        public string Tel { get; set; }


        [Display(Name = "Msg")]
        [Column("Msg")]
        public string Msg { get; set; }


    }
}
