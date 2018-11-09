using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace STI.Models
{
    public class ejercicios
    {
        [Key]
        public int id_ejercicio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ingrese un nombre de minimo 3 carateres a 50 como maximo")]
        public String nombre_ejercicio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int puntaje { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int id_temas { get; set; }
    }
}