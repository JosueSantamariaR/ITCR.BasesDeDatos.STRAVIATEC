using System.Threading.Tasks;

namespace StraviaTecMobile.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>();
    }
}