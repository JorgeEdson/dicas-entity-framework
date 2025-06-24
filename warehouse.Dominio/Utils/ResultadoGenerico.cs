
namespace warehouse.Dominio.Utils
{
    public class ResultadoGenerico<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Objeto { get; set; }

        public ResultadoGenerico(bool sucesso, string mensagem, T dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Objeto = dados;
        }
    }
}
