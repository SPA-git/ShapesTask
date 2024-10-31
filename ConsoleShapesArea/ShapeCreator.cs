using LibShapesArea.CalculationOop.Interface;
using LibShapesArea.CalculationOop.Shapes;

namespace ConsoleShapesArea;

internal static class ShapeCreator
{
    internal static IShape CreateShapeFromInput(string shapeName, float[] parameters)
    {
        IShape shape;
        switch (shapeName)
        {
            case "circle":
                {
                    shape = new Circle(parameters[0]);
                    return shape;
                }
            case "triangle":
                {
                    shape = new Triangle(parameters[0], parameters[1], parameters[2]);
                    return shape;
                }
        }
        throw new ArgumentException("Invalid name of shape");
    }

}