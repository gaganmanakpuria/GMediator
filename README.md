
# GMediator

![NuGet](https://img.shields.io/nuget/v/GMediator.svg)  
**GMediator** is a lightweight, dependency-free .NET mediator implementation inspired by MediatR. It helps decouple the request/response flow in your application, promoting clean architecture, testability, and maintainability — without the bloat.

---

## ✨ Features

- 🧩 No external dependencies
- 🔄 Supports `IRequest<TResponse>` and `IRequestHandler<TRequest, TResponse>`
- 🧼 Clean, simple, and fast
- 📦 Easily pluggable into any .NET project using `Microsoft.Extensions.DependencyInjection`
- 🔧 Compatible with .NET Standard, .NET Core, .NET 6/7/8+

---

## 📦 Installation

Install via .NET CLI:
```bash
dotnet add package GMediator

Or manually in your .csproj:
```xml
<PackageReference Include="GMediator" Version="1.0.0" />

🚀 Example: How to Use
✅ Step 1: Define a Request
public class Ping : IRequest<string>
{
    public string Message { get; set; }
}
✅ Step 2: Create a Handler
public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"Handled: {request.Message}");
    }
}
  ✅ Step 3: Register GMediator in DI
var services = new ServiceCollection();
services.AddGMediator();

var provider = services.BuildServiceProvider();
var mediator = provider.GetRequiredService<IMediator>();

✅ Step 4: Send a Request
var response = await mediator.Send(new Ping { Message = "Hello from GMediator!" });
Console.WriteLine(response); // Output: Handled: Hello from GMediator!

##  📚 License

MIT License. Use freely in personal and commercial projects.

