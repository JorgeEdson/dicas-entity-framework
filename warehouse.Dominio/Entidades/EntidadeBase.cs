using warehouse.Dominio.Utils;

namespace warehouse.Dominio.Entidades
{
    public class EntidadeBase
    {
        #region Propriedades
        public long Id { get; private set; }
        #endregion

        #region Construtores
        protected EntidadeBase()
        {
            Id = GeradorIdUtil.ProximoId();
        }
        #endregion

        #region Metodos publicos
        public void SetId(long id)
        {
            Id = id;
        }
        #endregion
    }
}
