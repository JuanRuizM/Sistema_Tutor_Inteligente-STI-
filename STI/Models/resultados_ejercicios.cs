using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace STI.Models
{
    public class resultados_ejercicios
    {
        [Key]
        public int id_resultado_ejercicio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Boolean acierto { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int id_ejercicio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int id_usuario { get; set; }

        public DateTime fecha { get; set; }
    }
}