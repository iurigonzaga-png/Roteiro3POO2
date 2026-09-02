using System;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string jsonConfig = @"{
            'Servidor': '192.168.0.1',
            'Porta': 1433,
            'Usuario': 'admin'
        }";

        JObject config = JObject.Parse(jsonConfig);

        config["Porta"] = 8080;

        string jsonModificado = config.ToString();

        Console.WriteLine(jsonModificado);
    }
}
