using Bowling.App.Extensions;

namespace Bowling.App;

public class ScoreParser
{
    private Stack<Frame> _frameStack;
    private const int MAX_FRAMES = 10;

    public ScoreParser()
    {
        _frameStack = new(MAX_FRAMES);
    }

    public int[] ParseScores(Frame[] frames)
    {
        Frame[] orderedFrames = frames.OrderByDescending(f => f.Id).ToArray();
        foreach (var frame in orderedFrames)
        {
            frame.TotalScore = frame switch
            {
                { IsStrike: true } => ScoreStrike(frame),
                { IsSpare: true } => ScoreSpare(frame),
                _ => frame.GetFrameScore(),
            };

            _frameStack.Push(frame);
        }

        var totalScore = 0;
        foreach (var frame in _frameStack)
        {
            totalScore += frame.TotalScore;
            frame.TotalScore = totalScore;
        }

        return _frameStack.Select(f => f.TotalScore).ToArray();
    }

    private int ScoreStrike(Frame frame)
    {
        var frame2 = _frameStack.PopOrDefault().NotNull($"Unable to get frame following {frame.Id}");
        if (frame2.IsStrike)
        {
            var frame3 = _frameStack.PopOrDefault().NotNull($"Unable to get frame following {frame2.Id}");
            int frame3Score = frame3.IsStrike
                ?  frame3.GetFrameScore()
                : frame3.Delivery1.ParseDelivery();

            _frameStack.Push(frame3);
            _frameStack.Push(frame2);
            return frame.GetFrameScore() + frame2.GetFrameScore() + frame3Score;
        }

        var frame2Score = frame2.GetFrameScore();
        if (frame2.Id == 10)
        {
            frame2Score = frame2 switch
            {
                { Delivery2: ScoreConstants.Spare } => 10,
                { Delivery1: ScoreConstants.Strike, Delivery2: ScoreConstants.Strike } => 20,
                _ => frame2.Delivery1.ParseDelivery() + frame2.Delivery2.ParseDelivery(),
            };
        }
        
        _frameStack.Push(frame2);
        return frame.GetFrameScore() + frame2Score;   
    }

    private int ScoreSpare(Frame frame)
    {
        var frame2 = _frameStack.PopOrDefault().NotNull($"Unable to get frame following {frame.Id}");
        int frame2Score = frame2.IsStrike
            ? frame2.GetFrameScore()
            : frame2.Delivery1.ParseDelivery();
            
        _frameStack.Push(frame2);
        return frame.GetFrameScore() + frame2Score;
    }
}
