using System.Text;

namespace Semaforo.UI.TipoTexto;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ConcatenacaoBenchmark
{
    private const string ConstanteA = "Não", ConstanteB = "alimente", ConstanteC = "os", ConstanteD = "animais";
    private const string ConstanteSeparador = "-";
    private const string ConstanteHashTag = "#";
    private readonly string _hashTagTemplateFormat = 
        $"{ConstanteHashTag}{{0}}" +
        $"{ConstanteSeparador}{{1}}" +
        $"{ConstanteSeparador}{{2}}" +
        $"{ConstanteSeparador}{{3}}";
    
    private string ValorA = ConstanteA, ValorB = ConstanteB, ValorC = ConstanteC, ValorD = ConstanteD;
    private string Separador = ConstanteSeparador;
    private string HashTag = ConstanteHashTag;

    
    [Benchmark(Baseline = true)]
    public bool ComOperadorConstante()
    {
        var resultado = ConstanteHashTag + ConstanteA + ConstanteSeparador + ConstanteB + ConstanteSeparador + ConstanteC + ConstanteSeparador + ConstanteD;
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    public bool ComOperador()
    {
        var resultado = HashTag + ValorA + Separador + ValorB + Separador + ValorC + Separador + ValorD;
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComStringFormatConstante()
    {
        var resultado = string.Format(_hashTagTemplateFormat, ConstanteA, ConstanteB, ConstanteC, ConstanteD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComStringFormat()
    {
        var resultado = string.Format(_hashTagTemplateFormat, ValorA, ValorB, ValorC, ValorD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComConcatConstante()
    {
        var resultado = string.Concat(ConstanteHashTag, ConstanteA, ConstanteSeparador, ConstanteB, ConstanteSeparador, ConstanteC, ConstanteSeparador, ConstanteD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComConcat()
    {
        var resultado = string.Concat(HashTag, ValorA, Separador, ValorB, Separador, ValorC, Separador, ValorD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComJoinConstante()
    {
        var resultado = ConstanteHashTag + string.Join(ConstanteSeparador, ConstanteA, ConstanteB, ConstanteC, ConstanteD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComJoin()
    {
        var resultado = HashTag + string.Join(Separador, ValorA, ValorB, ValorC, ValorD);
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComStringBuilderConstante()
    {
        var resultado = new StringBuilder();
        resultado.Append(ConstanteHashTag);
        resultado.Append(ConstanteA);
        resultado.Append(ConstanteSeparador);
        resultado.Append(ConstanteB);
        resultado.Append(ConstanteSeparador);
        resultado.Append(ConstanteC);
        resultado.Append(ConstanteSeparador);
        resultado.Append(ConstanteD);
        
        return string.IsNullOrWhiteSpace(resultado.ToString());
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
    public bool ComStringBuilderFormatConstante()
    {
        var resultado = new StringBuilder();
        resultado.AppendFormat(_hashTagTemplateFormat, ConstanteA, ConstanteB, ConstanteC, ConstanteD);
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
    public bool ComStringBuilderJoinConstante()
    {
        var resultado = new StringBuilder();
        resultado.Append(ConstanteHashTag); 
        resultado.AppendJoin(ConstanteSeparador, ConstanteA, ConstanteB, ConstanteC, ConstanteD);
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
    public bool ComInterpolacaoConstante()
    {
        var resultado = $"{ConstanteHashTag}{ConstanteA}{ConstanteSeparador}{ConstanteB}{ConstanteSeparador}{ConstanteC}{ConstanteSeparador}{ConstanteD}";
        return string.IsNullOrWhiteSpace(resultado);
    }
    
    [Benchmark]
    public bool ComInterpolacao()
    {
        var resultado = $"{HashTag}{ValorA}{Separador}{ValorB}{Separador}{ValorC}{Separador}{ValorD}";
        return string.IsNullOrWhiteSpace(resultado);
    }
}