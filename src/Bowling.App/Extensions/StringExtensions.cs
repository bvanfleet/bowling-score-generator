namespace Bowling.App.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Returns the numeric representation for the given value
    /// </summary>
    /// <param name="delivery">The delivery string value to parse</param>
    public static int ParseDelivery(this string? delivery)
    => delivery switch
    {
        null => 0,
        ScoreConstants.Foul => 0,
        ScoreConstants.Open => 0,
        ScoreConstants.Strike => 10,
        ScoreConstants.Spare => 10,
        _ => int.Parse(delivery),
    };
}
