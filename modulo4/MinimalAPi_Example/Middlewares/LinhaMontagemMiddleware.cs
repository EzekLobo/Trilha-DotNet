using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Modulo4.LinhaDeMontagem;
public class AddChassiMiddleware
{
    private readonly RequestDelegate _next;
    public AddChassiMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, LinhaDeMontagemDescricao descricao)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        descricao.AdicionarEtapa("Chassi", "Chassi adicionado");
        await _next(context);
        await context.Response.WriteAsync(descricao.ToString());
    }
}

public class AddMotorMiddleware
{
    private readonly RequestDelegate _next;
    public AddMotorMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, LinhaDeMontagemDescricao descricao)
    {
        descricao.AdicionarEtapa("Motor", "Motor adicionado");
        await _next(context);
    }
}

public class AddPortasMiddleware
{
    private readonly RequestDelegate _next;
    public AddPortasMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, LinhaDeMontagemDescricao descricao)
    {
        descricao.AdicionarEtapa("Portas", "Portas adicionadas");
        await _next(context);
        descricao.AdicionarEtapa("Portas", $"Maçanetas {descricao.Cor} adicionadas");
    }

}

public class AddPinturaMiddleware
{
    private readonly RequestDelegate _next;
    public AddPinturaMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, LinhaDeMontagemDescricao descricao)
    {
        var cores = new string[] { "Preto", "Branco", "Vermelho", "Azul" };
        descricao.Cor = cores[new Random().Next(0, cores.Length)];
        descricao.AdicionarEtapa("Pintura", $"Pintura adicionada na cor {descricao.Cor}");
        await _next(context);
    }
}
public class AddInternoMiddleware
{
    private readonly RequestDelegate _next;
    public AddInternoMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, LinhaDeMontagemDescricao descricao)
    {
        descricao.AdicionarEtapa("Acabamento Interno", $"Acabamento Interno adicionado na cor {descricao.Cor}");
        if (!context.Response.HasStarted)
            await _next(context);
    }
}

public class LinhaDeMontagemDescricao
{
    public List <(string,string)> descricao = new List<(string,string)>();
    public string Cor { get; set; }
    public void AdicionarEtapa(string etapa, string descricao)
    {
        this.descricao.Add((etapa, descricao));
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int i = 1;
        foreach (var item in descricao)
        {
            sb.AppendLine($"Etapa {i++}: {item.Item1} - {item.Item2}<br>");
        }
        return sb.ToString();
    }


    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("X-Timestamp", DateTime.Now.ToString());
                context.Response.Headers.Add("X-Client-IP", context.Connection.RemoteIpAddress.ToString());
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }

    

    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            _logger.LogInformation("Request levou: {ElapsedMilliseconds}ms", elapsedMs);
            
        }
    }

    
}

