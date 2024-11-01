using LibShapesArea.CalculationOop.Shapes;

namespace LibShapesArea.Tests;

public class CircleTests
{
    [Theory]
    [InlineData(-5)]
    [InlineData(-0.125)]
    public void Constructor_NegativeRadius_ThrowsArgumentException(float negativeRadius)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Circle(negativeRadius));
        Assert.Contains("negative", ex.Message.ToLower());
        Assert.Contains("radius", ex.Message.ToLower());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(6.125)]

    public void Constructor_NonNegativeRadius_ReturnsCircleObject(float nonNegativeRadius)
    {
        // Act
        var circle = new Circle(nonNegativeRadius);

        // Assert
        Assert.NotNull(circle);
        Assert.IsType<Circle>(circle);
        Assert.True(FloatOperations.Equals(nonNegativeRadius, circle.Radius));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(5f, 78.539816339744830961566084581988f)]
    [InlineData(6.125f, 117.85881189482958696170010567585f)]
    public void CalculateArea_NonNegativeRadius_ReturnsCorrectArea(float nonNegativeRadius, float result)
    {
        // Act
        var circle = new Circle(nonNegativeRadius);

        // Act
        var area = circle.CalculateArea();

        // Assert
        Assert.True(FloatOperations.Equals(area, result));
    }
}