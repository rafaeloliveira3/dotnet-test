using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoExemplo.Models {
    public class Noticia {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [Required]
        public string Cabecalho {get; set;}
        public string ImagemURL {get; set;}
        [Required]
        public string Texto {get; set;}
    }
}