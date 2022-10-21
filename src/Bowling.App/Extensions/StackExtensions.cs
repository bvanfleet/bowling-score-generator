namespace Bowling.App.Extensions;

public static class StackExtensions
{
    /// <summary>
    /// Pops and returns a result if the stack is not empty; otherwise, the default value is returned.
    /// </summary>
    /// <param name="stack">The stack to pop from</param>
    public static TResult? PopOrDefault<TResult>(this Stack<TResult> stack)
    {
        if (stack.TryPop(out var result))
        {
            return result;
        }

        return default;
    }
}
