using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaVotacao
{
    public class CadastroCandidato
    {
        public static void Cadastrar()
        {
            string nome;
            int numero;
            string partido;

            for (int i = 0; i < i + 1; i++)
            {
                Console.Clear();
                Console.WriteLine("Você está iniciando o cadastramento de candidatos para a eleição de 2022 \nPressione Enter para continuar . . .");
                Console.ReadLine();

                Console.WriteLine("Digite o nome do candidato:");
                nome = Console.ReadLine();
                if (Validacao(nome))
                {
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    Console.WriteLine("Digite o número do candidato:");
                    numero = Int32.Parse(Console.ReadLine());
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Somente pode ser usado números no número do candidato!");
                    Console.WriteLine("Pressione Enter para recomeçar o cadastro. . .");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Digite o partido do candidato:");
                partido = Console.ReadLine();
                if (Validacao(partido))
                {
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    Votacao votacao = new Votacao();
                    Candidato candidato = new Candidato(nome, numero, partido);
                    votacao.Adicionar(candidato);

                }
                catch (ArgumentException)
                {
                    Console.Clear();
                    Console.WriteLine($"Erro: candidato número {numero} já cadastrado!");
                    Console.ReadLine();
                    continue;
                }


                Console.WriteLine("Cadastro finalizado, deseja continuar cadastrando? Se sim, pressione Enter, se não, digite N.");
                var final = Console.ReadLine().ToUpper();

                if (final == "N")
                {                
                    Console.Clear();
                    break;                    
                }

            }
        }

        public static bool Validacao(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Campo não pode estar vazio!");
                return true;
            }

            try
            { 
                if (Regex.IsMatch(str, @"^[0-9]+$"))
                {
                    Console.WriteLine("Campo não pode ser um número!");
                    return true;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Campo não pode ser um número!");
                return true;
            }
            
            if (Regex.IsMatch(str, @"^(?=.*[@!#$%^&*()_/\\])"))
            {
                Console.WriteLine("Campo não pode conter um caractere especial!");
                return true;
            }

            return false;
        }
    }
}
