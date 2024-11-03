// See https://aka.ms/new-console-template for more information
using ConsoleShapesArea.Services;
using LibShapeReader;
using LibShapesArea.CalculationOop.Interface;
using LibShapesArea.CalculationOop.Shapes;

namespace ConsoleShapesArea;

internal static class Program
{
    private static void Main(string[] args)
    {
        do
        {
            var (ChosenInputOption, Parameters) = ShapeReader.ReadShapeFromKeyboard(ShapesInputConverter.InputOptions);

            IShape shape;
            try
            {
                shape = ShapesInputConverter.ConvertToModel(ChosenInputOption, Parameters);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }

            CalculateAndPrintParams(shape);
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private static void CalculateAndPrintParams(IShape shape)
    {
        Console.WriteLine($"Area: {shape.CalculateArea()}");
        var triangle = shape as Triangle;
        if (triangle is not null)
        {
            Console.WriteLine($"Is right triangle: {triangle.IsRight()}");
        }
    }
}