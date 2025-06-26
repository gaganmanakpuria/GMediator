using GMediator.Interfaces;
using GMediator.Extensions;
using Microsoft.Extensions.DependencyInjection;
namespace MediatorTest
{
    public class MediatorTests
    {
        [Fact]
        public async Task Should_Invoke_Correct_Handler()
        {
            var services = new ServiceCollection();

            services.AddGMediator();

            var provider = services.BuildServiceProvider();
            var mediator = provider.GetRequiredService<IMediator>();

            var result = await mediator.Send(new Ping { Message = "Hello" });
            Assert.Equal("Handled: Hello", result);
        }
    }
}
