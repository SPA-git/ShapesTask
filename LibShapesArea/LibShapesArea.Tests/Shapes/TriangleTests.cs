using LibShapesArea.CalculationOop.Shapes;

namespace LibShapesArea.Tests.Shapes;

public class TriangleTests
{
    [Theory]
    [InlineData(-1, -2, -3)]
    [InlineData(-8, 4, 12)]
    [InlineData(12, -10, 0)]
    [InlineData(12, 10, -6)]
    public void Constructor_NegativeSideAtLeastOne_ThrowsArgumentException(float a, float b, float c)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        Assert.Contains("negative", ex.Message.ToLower());
        Assert.Contains("sides", ex.Message.ToLower());
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 12, 12)]
    [InlineData(35, 10, 10)]
    public void Constructor_IncorrectSidesValues_ThrowsArgumentException(float a, float b, float c)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        Assert.Contains("can not exist", ex.Message.ToLower());
    }

    [Theory]
    [InlineData(5, 5, 5)]
    [InlineData(0.001, 0.0025, 0.003)]
    [InlineData(35, 26, 27)]
    public void Constructor_CorrectSideValues_ReturnsTriangleObject(float a, float b, float c)
    {
        // Act
        var triangle = new Triangle(a, b, c);

        // Assert
        Assert.NotNull(triangle);
        Assert.IsType<Triangle>(triangle);
        Assert.True(FloatOperations.Equals(a, triangle.A));
        Assert.True(FloatOperations.Equals(b, triangle.B));
        Assert.True(FloatOperations.Equals(c, triangle.C));
    }

    [Theory]
    [InlineData(5, 5, 5, 10.825317547305f)]
    [InlineData(0.001, 0.0025, 0.003, 1.1709371246997e-6f)]
    [InlineData(35, 26, 27, 348.10343290465f)]
    public void CalculateArea_CorrectSideValues_ReturnsCorrectArea(float a, float b, float c, double result)
    {
        // Act
        var triangle = new Triangle(a, b, c);

        // Act
        var area = triangle.CalculateArea();

        // Assert
        Assert.True(FloatOperations.Equals(area, result));
    }

    [Theory]
    [InlineData(3, 4, 5.001)]
    [InlineData(0.001, 0.0025, 0.003)]
    [InlineData(35, 26, 27)]
    public void IsRight_SidesDoNotSatisfyRightTriangle_ReturnsFalse(float a, float b, float c)
    {
        // Act
        var triangle = new Triangle(a, b, c);

        // Act, Assert
        Assert.False(triangle.IsRight());
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(3, 4, 5.0001)]
    [InlineData(0.001, 0.0025, 0.00269258)]
    [InlineData(35, 28, 21)]
    public void IsRight_SidesSatisfyRightTriangle_ReturnsTrue(float a, float b, float c)
    {
        // Act
        var triangle = new Triangle(a, b, c);

        // Act, Assert
        Assert.True(triangle.IsRight());
    }
}