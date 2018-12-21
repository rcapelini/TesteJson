using System;
using System.IO;
using Newtonsoft.Json;

namespace TesteJson
{

    class Program
    {
        static void Main(string[] args)
        {
            //Obtenho o JSON de alguma fonte, neste exemplo li de um arquivo no disco
            StreamReader leArquivo = new StreamReader(@"C:\Users\rodrigo.capelini\Downloads\Estudos\JSON\Pedidos.json");
            //Utilizo o método ReadToEnd() para que o JSON seja uma string única
            string arquivoJsonEmStringUnica = leArquivo.ReadToEnd();
            //Crio um objeto dinamicamente utilizando o método contido na biblioteca do Newtonsoft
            dynamic objetoDinamicoCoerenteComArquivoJson = JsonConvert.DeserializeObject(arquivoJsonEmStringUnica);
            //Faço uma varredura em todos os N pedidos contidos no exemplo do arquivo JSON
            foreach (var pedido in objetoDinamicoCoerenteComArquivoJson)
            {
                //Exibo na tela os valores únicos dos pedidos como idCliente e idPedido
                Console.WriteLine("{0} {1}", pedido.idCliente, pedido.idPedido);
                //Como em cada pedido há vários itens, faço uma nova varredura no pedido atual da iteração           
                foreach (var item in pedido.items)
                {
                    // e exibo na tela cada item do pedido atual
                    Console.WriteLine("{0} {1} {2}", item.idProduto, item.preco, item.nomeProduto);
                }
            }

        }
    }

}
