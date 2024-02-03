
using MED.Application.ViewModel;

namespace Teste.Application.Service
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoViewModel>> ObterTodos();
        Task<ContatoViewModel> RetornaPorId(int id);
        Task<ContatoViewModel> Incluir(ContatoViewModel obj);
        Task<ContatoViewModel> Alterar(ContatoViewModel obj);
        Task<ContatoViewModel> Excluir(int id);
    }

}
