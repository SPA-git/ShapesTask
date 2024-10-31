using LibShapesArea.CalculationOop.Interface;

namespace LibShapesArea.CalculationOop.Shapes;

public class Triangle : IShape
{
    public float A { get; }
    public float B { get; }
    public float C { get; }

    public Triangle(float a, float b, float c)
    {
        if (a < 0 || b < 0 || c < 0)
        {
            throw new ArgumentException("Negative sides of triangle are not valid");
        }
        if (!CanExist(a, b, c))
        {
            throw new ArgumentException("Triangle with current sizes can not exist");
        }

        A = a;
        B = b;
        C = c;
    }

    public double CalculateArea()
    {
        double semiPerimeter = (A + B + C) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
    }

    public bool IsRight()
    {
        if (A > B && A > C && IsTrueHypotenuse(A, B, C))
        {
            return true;
        }

        if (B > A && B > C && IsTrueHypotenuse(B, A, C))
        {
            return true;
        }

        if (C > A && C > B && IsTrueHypotenuse(C, A, B))
        {
            return true;
        }
        return false;
    }

    private static bool CanExist(float a, float b, float c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    private static bool IsTrueHypotenuse(float hypotenuse, float leg1, float leg2)
    {
        float difference = hypotenuse * hypotenuse * 0.0001f;
        return hypotenuse * hypotenuse - leg1 * leg1 - leg2 * leg2 < difference;
    }
}