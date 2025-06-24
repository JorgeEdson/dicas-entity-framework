using Microsoft.EntityFrameworkCore;
using warehouse.Dominio.Entidades;
using warehouse.Dominio.Interfaces;
using warehouse.Infraestrutura.Contextos;

namespace warehouse.Infraestrutura.Servicos
{
    public class UnityOfWorkService(WarehouseContext contexto) : IUnityOfWorkService
    {
        private readonly WarehouseContext _contexto = contexto;

        /*
         Dica 1: Use AsNoTracking() para Consultas Somente Leitura
         Quando você não precisa que o Entity Framework rastreie as entidades para futuras 
         atualizações, AsNoTracking() pode melhorar significativamente a performance ao 
         evitar o overhead do rastreamento de mudanças.
         */

        public async Task<List<Produto>> ObterTodosProdutosSomenteLeituraAsync()
        {
            // Buscar todos os produtos para exibir em uma lista (sem intenção de atualizar)
            return await _contexto.Produtos.ToListAsync();
        }

        //public async Task<List<Produto>> ObterTodosProdutosSomenteLeituraAsync()
        //{
        //    // A consulta é mais rápida pois o EF não precisa monitorar as entidades
        //    return await _contexto.Produtos.AsNoTracking().ToListAsync();
        //}

        /*
         Dica 2: Carregamento Eager (Include) vs. Carregamento Lazy (Lazy Loading)
         Evite o carregamento Lazy em loops (problema N+1) e prefira o carregamento Eager 
         com Include para carregar dados relacionados de uma vez.
         */

        public async Task<List<string>> ObterInformacoesItens()
        {
            var listaInformacoes = new List<string>();

            // Iterar sobre itens de estoque e acessar o nome do produto a cada iteração
            var estoqueItens = await _contexto.EstoqueItems
                .AsNoTracking()
                .ToListAsync();
            foreach (var item in estoqueItens)
            {
                // Acessa item.Produto, que dispara uma nova consulta ao banco para cada item (se Lazy Loading estiver habilitado)
                listaInformacoes.Add($"Produto: {item.Produto.Nome}, Quantidade: {item.Quantidade}");
            }
            return listaInformacoes;
        }

        //public async Task<List<string>> ObterInformacoesItens()
        //{            
        //    var listaInformacoes = new List<string>();

        //    // Carrega os produtos relacionados em uma única consulta
        //    var estoqueItens = await _contexto.EstoqueItems
        //        .Include(estoqueItem => estoqueItem.Produto)
        //        .AsNoTracking()
        //        .ToListAsync();
        //    foreach (var item in estoqueItens)
        //    {   
        //        listaInformacoes.Add($"Produto: {item.Produto.Nome}, Quantidade: {item.Quantidade}");
        //    }
        //    return listaInformacoes;
        //}

        /*
         Dica 3: Projeção de Dados com Select
         Se você precisa apenas de um subconjunto das colunas de uma entidade ou de dados 
         de entidades relacionadas, projete os dados para um tipo anônimo ou DTO em vez de 
         carregar a entidade completa. Isso reduz a quantidade de dados transferidos do 
         banco e o mapeamento de objetos. 
         */

        public async Task<List<string>> ObterDadosProdutos()
        {
            var listaDadosProdutos = new List<string>();

            // Carrega a entidade Produto completa, mesmo que só precise do Id e Nome
            var produtos = await _contexto.Produtos
                .AsNoTracking()
                .ToListAsync();

            foreach (var produto in produtos) 
            {
                listaDadosProdutos.Add($"Id: {produto.Id}, Nome: {produto.Nome}");
            }

            return listaDadosProdutos;

        }

        //public async Task<List<string>> ObterDadosProdutos()
        //{
        //    var listaDadosProdutos = new List<string>();

        //    // Seleciona apenas as propriedades necessárias
        //    var produtos = await _contexto.Produtos
        //        .AsNoTracking()
        //        .Select(produto => new {produto.Id, produto.Nome})
        //        .ToListAsync();

        //    foreach (var produto in produtos)
        //    {
        //        listaDadosProdutos.Add($"Id: {produto.Id}, Nome: {produto.Nome}");
        //    }

        //    return listaDadosProdutos;
        //}

        /*
         Dica 4: Paginação Eficiente com Skip e Take
         Ao lidar com grandes volumes de dados, sempre use Skip e Take para paginar as 
         consultas no banco de dados, em vez de carregar todos os registros para a memória 
         e depois paginar.
         */




    }
}
