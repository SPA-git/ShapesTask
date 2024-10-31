using LibShapesArea.CalculationOop.Interface;

namespace LibShapesArea.CalculationOop.Shapes;

public class Circle : IShape
{
    public float Radius { get; }

    public Circle(float radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Negative value of radius is not valid");
        }
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}