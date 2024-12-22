using System;
using System.Collections.Generic;
using System.Linq;
class Player
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Score { get; private set; }

    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }

    public void UpdateScore(int newScore)
    {
        Score = newScore;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Position: {Position}, Score: {Score}";
    }
}


