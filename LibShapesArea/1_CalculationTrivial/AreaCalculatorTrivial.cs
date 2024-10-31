namespace LibShapesArea.CalculationTrivial;

public static class AreaCalculatorTrivial
{
    public static double CalculateCircle(float radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Negative value of radius is not valid");
        }
        return Math.PI * radius * radius;
    }

    public static double CalculateTriangle(float a, float b, float c)
    {
        if (a < 0 || b < 0 || c < 0)
        {
            throw new ArgumentException("Negative sides of triangle are not valid");
        }
        if (!CanTriangleExist(a, b, c))
        {
            throw new ArgumentException("Triangle with current sizes can not exist");
        }

        double semiPerimeter = (a + b + c) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }

    public static bool IsTriangleRight(float a, float b, float c)
    {
        if (!CanTriangleExist(a, b, c))
        {
            throw new ArgumentException("Triangle with current sizes can not exist");
        }

        if (a > b && a > c && IsTrueHypotenuse(a, b, c))
        {
            return true;
        }

        if (b > a && b > c && IsTrueHypotenuse(b, a, c))
        {
            return true;
        }

        if (c > a && c > b && IsTrueHypotenuse(c, a, b))
        {
            return true;
        }
        return false;
    }

    private static bool CanTriangleExist(float a, float b, float c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    private static bool IsTrueHypotenuse(float hypotenuse, float leg1, float leg2)
    {
        float difference = hypotenuse * hypotenuse * 0.0001f;
        return hypotenuse * hypotenuse - leg1 * leg1 - leg2 * leg2 < difference;
    }
}
