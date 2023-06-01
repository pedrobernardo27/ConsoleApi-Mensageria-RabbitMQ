namespace Mensageria_RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {                
                new Publicador().Publicar();

                new Receptor().Consumir();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
