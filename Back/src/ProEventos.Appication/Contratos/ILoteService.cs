using System.Threading.Tasks;
using ProEventos.Appication.Dtos;
using ProEventos.Domain;

namespace ProEventos.Appication.Contratos
{
    public interface ILoteService
    {
         Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] model);
         Task<bool> DeleteLote(int  eventoId, int loteId);


        Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId);
        Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId);
    }
}