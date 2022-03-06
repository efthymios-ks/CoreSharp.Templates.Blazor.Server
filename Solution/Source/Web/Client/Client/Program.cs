using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client
{
    public static class Program
    {
        //Methods
        public static async Task Main(string[] args)
        {
            await DebugWasmAsync();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            Startup.Configure(builder);

            var wasm = builder.Build();
            await wasm.RunAsync();
        }

        private async static Task DebugWasmAsync()
            =>
#if DEBUG
            await Task.Delay(5000);
#else
            await Task.CompletedTask;
#endif 
    }
}
