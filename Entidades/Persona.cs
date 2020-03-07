using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersona.Entidades
{
    public class Persona
    {

        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }


        public Persona()
        {
            PersonaId = 0;
            Nombres = string.Empty;


        }

        public Persona(int personaid, string nombres)
        {
            PersonaId = personaid;
            Nombres = nombres;

           

        }

    }
}
