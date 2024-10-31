namespace ConsoleShapesArea;

internal record ShapeInput(string WelcomeMessage, ushort ParamsCount);

internal static class ShapeReader
{
    private static readonly Dictionary<string, ShapeInput> ShapeNameAndParameters = new Dictionary<string, ShapeInput>
    {
        { "circle", new ("Input radius:", 1) },
        { "triangle", new ("Input 3 sides separated by space:", 3) },
    };

    internal static (string ShapeName, float[] Parameters) ReadShapeFromKeyboard()
    {
        var shapeName = ReadShapeType();
        var parameters = ReadShapeParams(shapeName);
        return (shapeName, parameters);
    }

    private static string ReadShapeType()
    {
        var possibleShapeNames = new List<string>(ShapeNameAndParameters.Keys);
        Console.WriteLine($"Enter type of shape. Possible values: {string.Join(',', possibleShapeNames)}");

        string? shapeName;
        do
        {
            shapeName = Console.ReadLine()?.ToLower();
            if (shapeName is not null && possibleShapeNames.Contains(shapeName))
            {
                return shapeName;
            }
            Console.WriteLine("Try again");
        }
        while (true);
    }

    private static float[] ReadShapeParams(string shapeName)
    {
        var shapeParams = ShapeNameAndParameters[shapeName];

        do
        {
            Console.WriteLine(shapeParams.WelcomeMessage);
            var rawValues = Console.ReadLine()?.Split();
            if (TryParseParameters(rawValues, shapeParams.ParamsCount, out var paramsValues))
            {
                return paramsValues;
            }
            Console.WriteLine("Try again");
        }
        while (true);
    }

    private static bool TryParseParameters(string[]? rawValues, ushort paramsCount, out float[] paramsValues)
    {
        paramsValues = new float[paramsCount];
        if (rawValues is null || rawValues.Length < paramsCount)
        {
            return false;
        }

        for (var i = 0; i < paramsCount; i++)
        {
            if (!float.TryParse(rawValues[i], out var parsedValue))
            {
                Array.Fill(paramsValues, 0);
                return false;
            }
            paramsValues[i] = parsedValue;
        }
        return true;
    }
}