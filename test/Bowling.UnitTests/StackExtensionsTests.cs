using Bowling.App.Extensions;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Bowling.UnitTests;

public class StackExtensionsTests
{
    [Fact]
    public void PopOrDefault_Should_Return_Valid_Value_For_NonEmpty_Stack()
    {
        const string expectedValue = "hello";
        var stack = new Stack<string>();
        stack.Push(expectedValue);

        var value = stack.PopOrDefault();
        value.ShouldBe(expectedValue);
    }

    [Fact]
    public void PopOrDefault_Should_Return_Null_For_Empty_Stack()
    {
        var stack = new Stack<string>();

        var value = stack.PopOrDefault();
        value.ShouldBeNull();
    }
}
