﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Text;

[Generator]
public class HelloWorldGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        if (!Debugger.IsAttached) Debugger.Launch();
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // Generate code during compilation
        var source = @"
            namespace GeneratedCode
            {
                public static class HelloWorld
                {
                    public static void SayHello() => System.Console.WriteLine(""Hello, World!"");
                }
            }";

        // Add the generated source to the compilation
        context.AddSource("HelloWorldGenerator", SourceText.From(source, Encoding.UTF8));
    }
}