using System.Text;

namespace Semaforo.UI.TipoTexto;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ConcatenacaoBenchmark
{
    private const string ValorA = "Não", ValorB = "alimente", ValorC = "os", ValorD = "animais";
    private const string Separador = "-";
    private const string HashTag = "#";
    private readonly string _hashTagTemplateFormat = $"{{HashTag}}{0}{{Separador}}{1}{{Separador}}{2}{{Separador}}{3}";
    
    [Benchmark(Baseline = true)]
    public bool ComOperador()
    {
        var resultado = HashTag + ValorA + Separador + ValorB + Separador + ValorC + Separador + ValorD;
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComStringFormat()
    {
        var resultado = string.Format(_hashTagTemplateFormat, ValorA, ValorB, ValorC, ValorD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComConcat()
    {
        var resultado = string.Concat(HashTag, ValorA, Separador, ValorB, Separador, ValorC, Separador, ValorD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComJoin()
    {
        var resultado = HashTag + string.Join(Separador, ValorA, ValorB, ValorC, ValorD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComStringBuilder()
    {
        var resultado = new StringBuilder();
        resultado.Append(HashTag);
        resultado.Append(ValorA);
        resultado.Append(Separador);
        resultado.Append(ValorB);
        resultado.Append(Separador);
        resultado.Append(ValorC);
        resultado.Append(Separador);
        resultado.Append(ValorD);
        
        return string.IsNullOrWhiteSpace(resultado.ToString());
    }
    
    [Benchmark]
    public bool ComStringBuilderFormat()
    {
        var resultado = new StringBuilder();
        resultado.AppendFormat(_hashTagTemplateFormat, ValorA, ValorB, ValorC, ValorD);
        return string.IsNullOrWhiteSpace(resultado.ToString());
    }
    
    [Benchmark]
    public bool ComStringBuilderJoin()
    {
        var resultado = new StringBuilder();
        resultado.Append(HashTag); 
        resultado.AppendJoin(Separador, ValorA, ValorB, ValorC, ValorD);
        return string.IsNullOrWhiteSpace(resultado.ToString());
    }
    
    [Benchmark]
    public bool ComInterpolacao()
    {
        var resultado = $"{HashTag}{ValorA}{Separador}{ValorB}{Separador}{ValorC}{Separador}{ValorD}";
        return string.IsNullOrWhiteSpace(resultado);
    }
}