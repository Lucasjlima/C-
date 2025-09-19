using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tranquilooo!!!");
            Console.ReadLine();

            List<String> frutas = new List<String> { "Banana", "Maça", "Manga" };
            foreach (var fruta in frutas) {
                Console.WriteLine(fruta);
                Console.ReadLine();
            }

            List<Pessoa> pessoas = new List<Pessoa>();

            Pessoa pessoa1 = new Pessoa("Lucas", 19, "Masculino");
            Pessoa pessoa2 = new Pessoa("Maria", 20, "Feminino");
            Pessoa pessoa3 = new Pessoa("João", 17, "Masculino");
            pessoas.Add(pessoa1);
            pessoas.Add(pessoa2);
            pessoas.Add(pessoa3);

            foreach (var pessoa in pessoas) {
                Console.WriteLine(pessoa.ToString());
                Console.ReadLine();
            }

            foreach (var pessoa in pessoas) {

                if (pessoa.Idade >= 18) { 
                    Console.WriteLine($"{pessoa.Nome} é maior de idade.");
                } else {
                    Console.WriteLine($"{pessoa.Nome} é menor de idade.");
                }

            }

            

            



            
        }
    }

    internal class Pessoa
    {
        private string nome;
        private int idade;
        private string sexo;

        public Pessoa(string nome, int idade, string sexo) {
            this.nome = nome;
            this.idade = idade;
            this.sexo = sexo;
        }

        public string Nome {
            get { return nome; }
            set { nome = value; }
        }
        public int Idade {
            get { return idade; }
            set { idade = value; }
        }
        public string Sexo {
            get { return sexo; }
            set { sexo = value; }
        }
        public override string ToString()
        {
            return $"Nome: {nome}, Idade: {idade}, Sexo: {sexo}";
        }


    }
}
