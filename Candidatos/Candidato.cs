using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacao
{
    internal class Candidato
    {
        public string Nome { get; set; }
        public int Numero { get; private set; }
        public string Partido { get; set; }
        public bool Nulo { get; set; }

        public Candidato(string nulo)
        {
            Nulo = true;

        }

        public Candidato(string nome, int numero, string partido)
        {
            Nome = nome;
            Numero = numero;
            Partido = partido;
        }
        
        public override string ToString()
        {
            if (Nulo == true)
            {
                return $"Voto nulo";
            }
            return $"Nome: {Nome}, Número: {Numero}, Partido: {Partido}";
        }


    }
}

