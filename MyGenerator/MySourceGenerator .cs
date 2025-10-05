using Microsoft.CodeAnalysis;

namespace MyGenerator
{
    [Generator]
    public class MySourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            // Register for syntax notifications (optional)
            // context.RegisterForSyntaxNotifications(() => new MySyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // Generate source code here
            context.AddSource("GeneratedClass.g.cs",
                @"
                namespace MyGeneratedNamespace
                {
                    public static partial class GeneratedClass
                    {
                        public static void SayHello()
                        {
                            System.Console.WriteLine(""Hello from generated code!"");
                        }
                    }
                }");
        }
    }
}