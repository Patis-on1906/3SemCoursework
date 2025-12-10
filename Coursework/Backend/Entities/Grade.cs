namespace Coursework.Backend;

public class Grade 
{
    public int Scores { get; private set; }

    public Grade(int scores)
    {
        ChangeScores(scores);
    }
    
    public void ChangeScores(int newScores)
    {
        if (newScores < 0 || newScores > 100)
            throw new ArgumentOutOfRangeException(nameof(Scores), 
                "Балл должен быть в диапазоне от 0 до 100");
        
        Scores = newScores;
    }

    public int FivePointGrade()
    {
        return Scores switch
        {
            >= 87 => 5,
            >= 73 => 4,
            >= 50 => 3,
            _ => 2
        };
    }
}