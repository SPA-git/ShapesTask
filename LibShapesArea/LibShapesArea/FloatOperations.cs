namespace LibShapesArea;

public static class FloatOperations
{
    private const float ToleranceCoefficient = 0.0001f; // 0.01% difference

    public static bool Equals(double f1, double f2)
    {
        double tolerance = Math.Max(f1, f2) * ToleranceCoefficient;
        return Math.Abs(f1 - f2) <= tolerance;
    }
}