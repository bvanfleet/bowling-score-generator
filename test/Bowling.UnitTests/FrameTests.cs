using Bowling.App;
using Shouldly;
using Xunit;

namespace Bowling.UnitTests;

public class FrameTests
{
    [Theory]
    [InlineData("F", "-", 0)]
    [InlineData("2", "7", 9)]
    [InlineData(null, "X", 10)]
    [InlineData(null, "/", 10)]
    [InlineData("5", "/", 10)]
    public void Frame_Should_Parse_Valid_Scores(string? delivery1, string? delivery2, int expectedTotal)
    {
        Frame frame = new() { Delivery1 = delivery1, Delivery2 = delivery2 };
        frame.GetFrameScore().ShouldBe(expectedTotal);
    }

    [Theory]
    [InlineData("2", "3", null, 5)]
    [InlineData("4", "/", "7", 17)]
    [InlineData("X", "X", "-", 20)]
    [InlineData("X", "-", "/", 20)]
    [InlineData("4", "/", "X", 20)]
    [InlineData("X", "X", "X", 30)]
    public void Tenth_Frame_Should_Parse_Valid_Scores(string? delivery1, string? delivery2, string? delivery3, int expectedTotal)
    {
        Frame frame = new() { Id = 10, Delivery1 = delivery1, Delivery2 = delivery2, Delivery3 = delivery3 };
        frame.GetFrameScore().ShouldBe(expectedTotal);
    }
}
