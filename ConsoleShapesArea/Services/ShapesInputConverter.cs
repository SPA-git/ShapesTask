using LibShapeReader;
using LibShapesArea.CalculationOop.Interface;
using LibShapesArea.CalculationOop.Shapes;

namespace ConsoleShapesArea.Services;

public static class ShapesInputConverter
{
    public static readonly ShapeInputOption[] InputOptions = {
        new (ShapeType.Circle, "circle", "Input radius:", 1),
        new (ShapeType.Circle, "round", "Input radius:", 1),
        new (ShapeType.Triangle, "triangle", "Input 3 sides separated by space:", 3),
    };

    internal static IShape ConvertToModel(ShapeInputOption inputOption, float[] parameters)
    {
        switch (inputOption.OptionName)
        {
            case ShapeType.Circle:
                {
                    return new Circle(parameters[0]);
                }
            case ShapeType.Triangle:
                {
                    return new Triangle(parameters[0], parameters[1], parameters[2]);
                }
        }
        throw new InvalidOperationException("Not implemented type of shape");
    }

}