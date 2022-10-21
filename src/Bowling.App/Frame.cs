using Bowling.App.Extensions;

namespace Bowling.App;

public class Frame
{
    public int Id { get; set; }

    public string? Delivery1 { get; set; }
    public string? Delivery2 { get; set; }
    public string? Delivery3 { get; set; }
    
    public bool IsStrike => Id != 10 && Delivery2 == ScoreConstants.Strike;
    public bool IsSpare => Id != 10 && Delivery2 == ScoreConstants.Spare;

    public int TotalScore { get; set; }

    public int GetFrameScore()
    {
        var delivery1 = Delivery1.ParseDelivery();
        var delivery2 = Delivery2.ParseDelivery();
        var delivery3 = Delivery3.ParseDelivery();

        // Handle 10th frame scoring with three deliveries
        if (Id == 10) return this switch
        {
            { Delivery1: ScoreConstants.Strike, Delivery2: ScoreConstants.Strike } => delivery1 + delivery2 + delivery3,
            { Delivery1: ScoreConstants.Strike, Delivery3: ScoreConstants.Spare } => delivery1 + delivery3,
            { Delivery1: ScoreConstants.Strike } => delivery1 + delivery2 + delivery3,
            { Delivery2: ScoreConstants.Spare } => delivery2 + delivery3,
            _ => delivery1 + delivery2
        };

        if (Delivery2 == ScoreConstants.Strike || Delivery2 == ScoreConstants.Spare) return Delivery2.ParseDelivery();

        return Delivery1.ParseDelivery() + Delivery2.ParseDelivery();
    }

    public override string ToString()
    => Id == 10
        ? $"{Delivery1 ?? " "} |{Delivery2 ?? ScoreConstants.Open}| |{Delivery3 ?? ScoreConstants.Open}|\t"
        : $"{Delivery1 ?? " "} |{Delivery2 ?? ScoreConstants.Open}|\t";
}
