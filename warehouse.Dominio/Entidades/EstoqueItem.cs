using warehouse.Dominio.Utils;

namespace warehouse.Dominio.Entidades
{
    public class EstoqueItem : EntidadeBase
    {
        #region Propriedades
        public long IdProduto { get; private set; }
        public Produto Produto { get; private set; }

        public long IdAlmoxarifado { get; private set; }
        public Almoxarifado Almoxarifado { get; private set; }

        public int Quantidade { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        #endregion

        #region Metodos Privados
        #endregion

        #region Construtores
        public EstoqueItem(){}
        private EstoqueItem(Produto produto, Almoxarifado almoxarifado) 
        {
            VincularProduto(produto);
            VincularAlmoxarifado(almoxarifado);
        }
        #endregion

        #region Metodos Publicos
        public static ResultadoGenerico<EstoqueItem> Instanciar(Produto produto, Almoxarifado almoxarifado)
        {
            try
            {
                return new ResultadoGenerico<EstoqueItem>(
                  true,
                  "EstoqueItem Instanciado com sucesso",
                  new EstoqueItem(produto,almoxarifado)
              );

            }
            catch (Exception ex)
            {
                return new ResultadoGenerico<EstoqueItem>(
                   false,
                   "Falha ao Instanciar um EstoqueItem: " + ex.Message,
                   null
               );
            }
        }

        public void VincularProduto(Produto produto) 
        {
            if (produto is null || produto.Id <= 0)
                throw new ArgumentException("Produto invalido.");

            IdProduto = produto.Id;
        }

        public void VincularAlmoxarifado(Almoxarifado almoxarifado)
        {
            if (almoxarifado is null || almoxarifado.Id <= 0)
                throw new ArgumentException("Almoxarifado invalido.");

            IdAlmoxarifado = almoxarifado.Id;
        }
        #endregion

    }
}
