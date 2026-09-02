using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ExerciciosJson
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Proprietario { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
           string caminhoArquivo = @"C:\Users\alunolab\Desktop\Roteiro 3 POO2\Exercicio3\carros.json";

            List<Carro> frota = new List<Carro>
            {
                new Carro { Marca = "Toyota", Modelo = "Corolla", Ano = 2022, Proprietario = "Alexandre de Moraes" },
                new Carro { Marca = "Ford", Modelo = "Mustang", Ano = 1969, Proprietario = "Alexandre de Moraes" },
                new Carro { Marca = "Honda", Modelo = "Civic", Ano = 2024, Proprietario = "Alexandre de Moraes" }
            };

            try
            {
                var opcoes = new JsonSerializerOptions { WriteIndented = true };

                string jsonGerado = JsonSerializer.Serialize(frota, opcoes);

                File.WriteAllText(caminhoArquivo, jsonGerado);
                Console.WriteLine($"[Sucesso] Lista gravada em: {caminhoArquivo}\n");

                string jsonLido = File.ReadAllText(caminhoArquivo);       
                List<Carro> frotaRecuperada = JsonSerializer.Deserialize<List<Carro>>(jsonLido);
                Console.WriteLine("Dados lidos e recuperados do arquivo JSON:");
                foreach (var carro in frotaRecuperada)
                {
                    Console.WriteLine($"- {carro.Marca} {carro.Modelo} ({carro.Ano}) | Dono: {carro.Proprietario}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
