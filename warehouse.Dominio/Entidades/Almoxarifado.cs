using warehouse.Dominio.Utils;

namespace warehouse.Dominio.Entidades
{
    public class Almoxarifado : EntidadeBase
    {
        #region Propriedades        
        public string Nome { get; private set; }
        public string Localizacao { get; private set; }

        public ICollection<EstoqueItem> EstoqueItems { get; private set; }
        #endregion

        #region Metodos Privados
        #endregion

        #region Construtores
        public Almoxarifado()
        {
                
        }
        private Almoxarifado(string nome, string localizacao)
        {
            SetNome(nome);
            SetLocalizacao(localizacao);
            EstoqueItems = new List<EstoqueItem>();
        }
        #endregion

        #region Metodos Publicos
        public static ResultadoGenerico<Almoxarifado> Instanciar(string nome, string localizacao)
        {
            try
            {
                return new ResultadoGenerico<Almoxarifado>(
                  true,
                  "Produto Instanciado com sucesso",
                  new Almoxarifado(nome, localizacao)
                );

            }
            catch (Exception ex)
            {
                return new ResultadoGenerico<Almoxarifado>(
                   false,
                   "Falha ao Instanciar um Almoxarifado: " + ex.Message,
                   null
                );
            }

        }


        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do almoxarifado não pode estar vazio.");

            Nome = nome;
        }

        public void SetLocalizacao(string localizacao)
        {
            if (string.IsNullOrWhiteSpace(localizacao))
                throw new ArgumentException("Localização do Almoxarifado não pode estar vazio.");

            Localizacao = localizacao;
        }
        #endregion
    }
}
