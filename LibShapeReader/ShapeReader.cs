namespace LibShapeReader;

public static class ShapeReader
{
    public static ShapeInputResults ReadShapeFromKeyboard(ShapeInputOption[] inputOptions)
    {
        ShapeInputOption inputOption = ReadShapeType(inputOptions);
        float[] parameters = ReadShapeParams(inputOption);
        return new ShapeInputResults(inputOption, parameters);
    }

    private static ShapeInputOption ReadShapeType(ShapeInputOption[] inputOptions)
    {
        var possibleShapeNames = new List<string>(inputOptions.Select(o => o.InputString));
        Console.WriteLine($"---------------------------------------------------------------------------");
        Console.WriteLine($"Enter type of shape. Possible values: {string.Join(',', possibleShapeNames)}");

        do
        {
            string? userInput = Console.ReadLine()?.ToLower();
            ShapeInputOption? matchedOption = Array.Find(
                inputOptions,
                option => userInput == option.InputString.ToLower());
            if (matchedOption is not null)
            {
                return matchedOption;
            }
            Console.WriteLine("Try again");
        }
        while (true);
    }

    private static float[] ReadShapeParams(ShapeInputOption inputOption)
    {
        do
        {
            Console.WriteLine(inputOption.WelcomeMessage);
            string[]? rawValues = Console.ReadLine()?.Split();
            if (TryParseParameters(rawValues, inputOption.ParamsCount, out float[] paramsValues))
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