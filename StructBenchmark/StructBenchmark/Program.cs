using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Utf8Json;

namespace StructBenchmark
{
    public struct JsonMessage
    {
        public JsonMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    [DisassemblyDiagnoser]
    public class JsonBenchmark
    {
        private const string Text = "Hello, World!";

        [Benchmark(Baseline = true)]
        public void Initializer()
        {
            var json = JsonSerializer.SerializeUnsafe(new JsonMessage { Message = Text });
        }

        [Benchmark]
        public void Constructor()
        {
            var json = JsonSerializer.SerializeUnsafe(new JsonMessage(Text));
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<JsonBenchmark>();
        }
    }
}