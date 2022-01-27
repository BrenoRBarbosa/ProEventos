using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface ILotePersist
    {
        /// <summary>
        /// Método Get que retornará uma lista de lotes por eventoId
        /// </summary>
        /// <param name="eventoId">Código chave da tabela Evento</param>
        /// <returns>uma lista de Lotes</returns>
        Task<Lote[]> GetLotesByEventoIdsAsync(int eventoId);
        /// <summary>
        /// Método Get que retornará apena 1 Lote
        /// </summary>
        /// <param name="eventoId">Código chave da tabela Evento</param>
        /// <param name="id">Código chava da tabela Lote</param>
        /// <returns>Apenas um lote</returns>
        Task<Lote> GetLoteByIdsAsync(int eventoId, int id);
    }
}