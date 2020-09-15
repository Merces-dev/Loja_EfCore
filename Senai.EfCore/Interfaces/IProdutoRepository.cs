using Senai.EfCore.Domains;
using System;
using System.Collections.Generic;

namespace Senai.EfCore.Interfaces
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Lista de todos os produtos</returns>
        List<Produto> Listar();

        /// <summary>
        /// Procura um produto através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um produto através do id</returns>
        Produto BuscarPorId(Guid id);

        /// <summary>
        /// Procura um produto através do nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>um produto através do nome</returns>
        List<Produto> BuscarPorNome(string nome);

        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="produto"></param>
        void Adicionar(Produto produto);

        /// <summary>
        /// Edita os dados de um produto
        /// </summary>
        /// <param name="produto"></param>
        void Editar(Produto produto);

        /// <summary>
        /// Apaga um produto
        /// </summary>
        /// <param name="id"></param>
        void Remover(Guid id);
    }
}