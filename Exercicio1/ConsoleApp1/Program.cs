using System;
using System.Text.Json;

namespace ExerciciosJson
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Livro livro = new Livro
            {
                Titulo = "Direito Constitucional",
                Autor = "Alexandre de Moraes",
                Ano = 1997
            };
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string jsonLivro = JsonSerializer.Serialize(livro, opcoes);
            Console.WriteLine(jsonLivro);
        }
    }
}
