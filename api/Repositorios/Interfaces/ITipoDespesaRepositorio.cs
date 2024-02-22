using Sigedesp.Models;

namespace Sigedesp.Repositorios.Interfaces
{
    public interface ITipoDespesaRepositorio
    {
        Task<List<TipoDespesaModel>> BuscarTipoDespesa();
        Task<TipoDespesaModel> BuscarPorId(int id);
        Task<TipoDespesaModel> Adicionar(TipoDespesaModel tipoDespesa);
        Task<TipoDespesaModel> Atualizar(TipoDespesaModel tipoDespesa, int id);
        Task<bool> Apagar(int id);
    }
}
