using System.Threading.Tasks;

namespace DevFreela.Core.Services
{
    public interface IMessageBusService
    {
        Task Publish(string queue, byte[] message);
    }
}