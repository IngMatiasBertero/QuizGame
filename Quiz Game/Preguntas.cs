using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class Preguntas
    {

        public int id { get; set; } //identificador de cada pregunta
        public string Pregunta { get; set; }

        public List<Opciones> opcion { get; set; }


    }
}
