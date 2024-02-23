using Microsoft.EntityFrameworkCore;
using Sigedesp.Data;
using Sigedesp.Models;
using Sigedesp.Repositorios.Interfaces;

namespace Sigedesp.Repositorios
{
    public class TipoDespesaRepositorio : ITipoDespesaRepositorio
    {
        private readonly SigedespDBContex _dbContext;
        public TipoDespesaRepositorio(SigedespDBContex sigedespDBContex) 
        {
            _dbContext = sigedespDBContex;
        }

        public async Task<TipoDespesaModel> BuscarPorId(int id)
        {
           return await _dbContext.TipoDespesa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoDespesaModel>> BuscarTipoDespesa()
        {
           return await _dbContext.TipoDespesa.ToListAsync();
        }

        public async Task<TipoDespesaModel> Adicionar(TipoDespesaModel tipoDespesa)
        {
           await _dbContext.TipoDespesa.AddAsync(tipoDespesa);
           await _dbContext.SaveChangesAsync();

            return tipoDespesa;
        }

        public async Task<TipoDespesaModel> Atualizar(TipoDespesaModel tipoDespesa, int id)
        {
            TipoDespesaModel tipoDespesaPorId = await BuscarPorId(id);

            if(tipoDespesaPorId == null)
            {
                throw new Exception($"Tipo Despesa para o ID: {id} não foi encontrado no banco de dados");
            }

            tipoDespesaPorId.TipoDespesa = tipoDespesa.TipoDespesa;
            tipoDespesaPorId.SolicitaUC = tipoDespesa.SolicitaUC;

            _dbContext.TipoDespesa.Update(tipoDespesaPorId);
            await _dbContext.SaveChangesAsync();

            return tipoDespesaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TipoDespesaModel tipoDespesaPorId = await BuscarPorId(id);

            if (tipoDespesaPorId == null)
            {
                throw new Exception($"Tipo Despesa para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.TipoDespesa.Remove(tipoDespesaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
