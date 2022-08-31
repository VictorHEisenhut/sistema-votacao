using SistemaVotacao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacao
{
    internal class Votacao
    {
        public static IDictionary<int, Candidato> dicionarioCandidatos = new Dictionary<int, Candidato>()
        {
            {0, new Candidato("NULO")}
        };
        static IDictionary<int, int> dicionarioVotos = new Dictionary<int, int>();
        ISet<Candidato> candidatos = new HashSet<Candidato>();
        public IList<Candidato> Candidatos
        {
            get
            {
                return new ReadOnlyCollection<Candidato>(candidatos.ToList());
            }
        }

        public string Nome { get; set; }
        public int Numero { get; private set; }
        public string Partido { get; set; }

        internal void Adicionar(Candidato candidato)
        {
            candidatos.Add(candidato);
            dicionarioCandidatos.Add(candidato.Numero, candidato);
            Console.Beep(1000, 100);
        }

        internal Candidato ProcuraCandidato(int numero)
        {
            dicionarioCandidatos.TryGetValue(numero, out var candidato);
            return candidato;
        }

        internal void Votar()
        {
            CadastroCandidato.Cadastrar();

            Console.WriteLine("Pressione Enter para inicar votação. . .");
            Console.ReadLine();

            Console.WriteLine("Iniciando Votação!");
            Console.Clear();

            try
            {
                Console.WriteLine("Quantas pessoas irão votar?");
                var nPessoas = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                for (int pessoas = 1; pessoas < nPessoas + 1; pessoas++)
                {
                    Console.WriteLine("Candidatos inscritos: \n");
                    foreach (var candidato in dicionarioCandidatos)
                    {
                        Console.WriteLine($"[{candidato.Key}, {candidato.Value}]");
                    }
                    Console.WriteLine();

                    Console.WriteLine($"Olá pessoa nº {pessoas}!");

                    Console.WriteLine("Digite o número do candidato em que você irá votar:");
                    int numeroVotado = Convert.ToInt32(Console.ReadLine());

                    if (numeroVotado == 0)
                    {
                        dicionarioVotos[numeroVotado] = Int32.MinValue;
                    }

                    if (!dicionarioVotos.ContainsKey(numeroVotado))
                    {
                        dicionarioVotos[numeroVotado] = 1;
                    }
                    else
                    {
                        dicionarioVotos[numeroVotado]++;
                    }

                    Console.WriteLine(dicionarioCandidatos[numeroVotado]);
                    Console.WriteLine();
                    Console.WriteLine("Pressione Enter para continuar votando. . .");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Número inválido");
                Console.ReadLine();
            }

            ResultadoVotacao();

        }

        internal void ResultadoVotacao()
        {
            try
            {
                var maisVotado = dicionarioVotos.Aggregate((x, y) => x.Value > y.Value ? x : y);
                var maisVotados = dicionarioVotos.Where(x => x.Value == maisVotado.Value).ToArray();

                Console.WriteLine("Candidato(s) vencedor(es):");

                foreach (var vencedor in maisVotados)
                {
                    Console.WriteLine($"[{dicionarioCandidatos[vencedor.Key]}]");
                    Console.WriteLine($"Quantidade de votos: {vencedor.Value}\n") ;
                }
            }
            catch (Exception)
            {

            }

        }
    }
}



