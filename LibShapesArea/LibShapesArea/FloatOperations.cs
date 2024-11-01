namespace LibShapesArea;

public static class FloatOperations
{
    private const float ToleranceCoefficient = 0.0001f;

    public static bool Equals(double f1, double f2)
    {
        var tolerance = Math.Max(f1, f2) * ToleranceCoefficient;
        return Math.Abs(f1 - f2) <= tolerance;
    }
}