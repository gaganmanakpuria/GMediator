using GMediator.Interfaces;
namespace MediatorTest
{
    public class Ping : IRequest<string>
    {
        public string Message { get; set; }
    }

}