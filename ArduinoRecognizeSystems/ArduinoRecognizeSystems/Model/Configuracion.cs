using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArduinoRecognizeSystems2.Model
{
    class Configuracion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Necesita un Usuario")]
        public string UserID { get; set; }

        [Required]
        public string Item { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int Time { get; set; }

    }
}
