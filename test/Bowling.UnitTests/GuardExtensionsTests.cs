using Bowling.App.Extensions;
using Shouldly;
using System;
using Xunit;

namespace Bowling.UnitTests;

public class GuardExtensionsTests
{
    [Fact]
    public void NotNull_Should_Return_Valid_Response()
    {
        object obj = new();
        var result = obj.NotNull();
        result.ShouldNotBeNull();
    }

    [Fact]
    public void NotNull_Should_Throw_On_Null()
    {
        object? obj = null;
        Should.Throw<ArgumentNullException>(new Action(() => obj.NotNull()));
    }

    [Fact]
    public void NotNullOrEmpty_Should_Return_Valid_Response()
    {
        string value = "hello, world";
        var result = value.NotNullOrEmpty();
        result.ShouldBe(value);
    }
}
