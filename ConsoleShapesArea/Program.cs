// See https://aka.ms/new-console-template for more information
using ConsoleShapesArea;
using LibShapesArea.CalculationOop.Interface;
using LibShapesArea.CalculationOop.Shapes;


do
{
    var (ShapeName, Parameters) = ShapeReader.ReadShapeFromKeyboard();

    IShape shape;
    try
    {
        shape = ShapeCreator.CreateShapeFromInput(ShapeName, Parameters);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    Console.WriteLine($"Area: {shape.CalculateArea()}");
    var triangle = shape as Triangle;
    if (triangle is not null)
    {
        Console.WriteLine($"Is right triangle: {triangle.IsRight()}");
    }

}
while (Console.ReadKey(true).Key != ConsoleKey.Escape);