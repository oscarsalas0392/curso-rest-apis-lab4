// Program

using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;

WebHost.CreateDefaultBuilder().Configure(app =>
{
    app.UseRouting();
    app.UseEndpoints(e =>
    {
        e.MapGet("/", c => c.Response.WriteAsync("Hello world!"));
        
        e.MapGet("hello", context =>
            context.Response.WriteAsJsonAsync(new { Message = "Hello, visitor"})
        );
        
        e.MapGet("hello/{name}", context => {

            context.Response.WriteAsync($"Hello, {context.Request.RouteValues["name"]}");

            return System.Threading.Tasks.Task.CompletedTask;
        });

        e.MapPost("hello", async context => {

            var value = new StringValues(context.Request.Host.Host);

            context.Response.Headers.Add("Host-name", value);

            using var reader = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8);
            var content = await reader.ReadToEndAsync();

            System.Console.WriteLine(content);

            context.Response.StatusCode = 200;
        });
    });
}).Build().Run();