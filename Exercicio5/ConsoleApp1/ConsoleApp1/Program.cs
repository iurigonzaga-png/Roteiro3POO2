using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace ExerciciosJson
{

    public class Produto
    {
        [JsonProperty(Order = 1)]
        public int Id { get; set; }

        [JsonProperty("product_name", Order = 2)]
        public string Nome { get; set; }

        [JsonProperty("product_price", Order = 3)]
        public double Preco { get; set; }

        [JsonProperty(Order = 4)]
        public int Estoque { get; set; }

        [JsonProperty(Order = 5)]
        public string Fornecedor { get; set; }

        [Newtonsoft.Json.JsonIgnore]
                public string CodigoInterno { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string caminhoArquivo = @"C:\Users\alunolab\Desktop\Roteiro 3 POO2\Exercicio2\produtos.json";

            List<Produto> listaProdutos = new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Nome = "Notebook",
                    Preco = 4500.00,
                    Estoque = 10,
                    Fornecedor = "Alexandre de Moraes Tech",
                    CodigoInterno = "NOTE-ALEX-001"
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Mouse",
                    Preco = 150.00,
                    Estoque = 50,
                    Fornecedor = "Alexandre de Moraes Tech",
                    CodigoInterno = "MOUS-ALEX-002"
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Teclado Mecânico",
                    Preco = 350.00,
                    Estoque = 25,
                    Fornecedor = "Alexandre de Moraes Tech",
                    CodigoInterno = "TECL-ALEX-003"
                },
                new Produto
                {
                    Id = 4,
                    Nome = "Monitor 144Hz",
                    Preco = 1200.00,
                    Estoque = 5,
                    Fornecedor = null,
                    CodigoInterno = "MONI-ALEX-004"
                }
            };

            try
            {
                var configuracoes = new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };

                string jsonGerado = JsonConvert.SerializeObject(listaProdutos, configuracoes);

                File.WriteAllText(caminhoArquivo, jsonGerado);
                Console.WriteLine($"[Sucesso] JSON gerado e gravado em: {caminhoArquivo}\n");

                string jsonLido = File.ReadAllText(caminhoArquivo);
                List<Produto> listaRecuperada = JsonConvert.DeserializeObject<List<Produto>>(jsonLido);

                foreach (var prod in listaRecuperada)
                {
                    Console.WriteLine($"Id:         {prod.Id}");
                    Console.WriteLine($"Nome:       {prod.Nome}");
                    Console.WriteLine($"Preço:      R$ {prod.Preco:F2}");
                    Console.WriteLine($"Estoque:    {prod.Estoque} unidades");
                    Console.WriteLine($"Fornecedor: {prod.Fornecedor ?? "Não informado (campo era null)"}");
                    Console.WriteLine(new string('-', 30));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro no sistema: {ex.Message}");
            }
            Console.WriteLine("\nPressione qualquer tecla para finalizar o roteiro...");
            Console.ReadKey();
        }
    }
}
