using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArduinoRecognizeSystems2.Model
{
    class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Necesita un Usuario")]
        [MinLength(3), MaxLength(30)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Necesita una contraseña")]
        [MinLength(4), MaxLength(20)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Necesita un Nombre")]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }
    }
}
