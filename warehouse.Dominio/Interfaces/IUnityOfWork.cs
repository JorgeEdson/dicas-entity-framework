using warehouse.Dominio.Entidades;

namespace warehouse.Dominio.Interfaces
{
    public interface IUnityOfWorkService
    {
        Task<List<Produto>> ObterTodosProdutosSomenteLeituraAsync();

        Task<List<string>> ObterInformacoesItens();

        Task<List<string>> ObterDadosProdutos();
    }
}
