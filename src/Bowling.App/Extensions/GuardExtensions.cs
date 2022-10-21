namespace Bowling.App.Extensions;

public static class GuardExtensions
{
    /// <summary>
    /// Raises an exception if a given value is null
    /// </summary>
    /// <param name="value">Value to null check</param>
    /// <exception cref="System.ArgumentNullException">Thrown if value is null</exception>
    public static T NotNull<T>(this T? value)
    {
        if (value is null) throw new ArgumentNullException();
        return value;
    }

    /// <summary>
    /// Raises an exception if a given value is null
    /// </summary>
    /// <param name="value">Value to null check</param>
    /// <exception cref="System.ArgumentNullException">Thrown if value is null or empty</exception>
    public static string NotNullOrEmpty(this string? value)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException();
        return value;
    }
}
