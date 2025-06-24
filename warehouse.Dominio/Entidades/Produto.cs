using warehouse.Dominio.Utils;

namespace warehouse.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        #endregion

        #region Metodos Privados
        #endregion

        #region Construtores
        public Produto(){}
        private Produto(string nome, string descricao, decimal precoUnitario) 
        {
            SetNome(nome);
            SetDescricao(descricao);
            SetPrecoUnitario(precoUnitario);
        }
        #endregion

        #region Metodos Publicos
        public static ResultadoGenerico<Produto> Instanciar(string nome, string descricao, decimal precoUnitario) 
        {
            try
            {
                return new ResultadoGenerico<Produto>(
                  true,
                  "Produto Instanciado com sucesso",
                  new Produto(nome,descricao,precoUnitario)
              );

            }
            catch (Exception ex) 
            {
                return new ResultadoGenerico<Produto>(
                   false,
                   "Falha ao Instanciar um produto: "+ex.Message,
                   null
               );
            }
        
        }

        public void SetNome(string nome) 
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode estar vazio.");

            Nome = nome;
        }

        public void SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descricao do produto não pode estar vazia.");

            Descricao = descricao;
        }

        public void SetPrecoUnitario(decimal preco)
        {
            if (preco <= 0)
                throw new ArgumentException("O Preço do produto nao pode ser 0 ou menos.");

            PrecoUnitario = preco;
        }
        #endregion
    }
}
