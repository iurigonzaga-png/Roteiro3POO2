using System;
using System.IO;
using System.Text.Json;

namespace ExerciciosJson
{

    public class Aluno
    {
        public string Nome { get; set; }
        public string Curso { get; set; }
        public int Idade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string caminhoArquivo = @"C:\Users\alunolab\Desktop\Roteiro 3 POO2\Exercicio2\aluno.json";
            

            try
            {
                string jsonLido = File.ReadAllText(caminhoArquivo);

                Aluno aluno = JsonSerializer.Deserialize<Aluno>(jsonLido);

                Console.WriteLine("Dados do Aluno lidos com sucesso:");
                Console.WriteLine($"Nome:  {aluno.Nome}");
                Console.WriteLine($"Curso: {aluno.Curso}");
                Console.WriteLine($"Idade: {aluno.Idade} anos");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Erro: O arquivo '{caminhoArquivo}' não foi encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}

