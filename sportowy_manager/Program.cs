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
interface IPlayerType
{
    string GetPlayerType();
}

class Defender : Player, IPlayerType
{
    public Defender(string name, int score) : base(name, "Defender", score) { }

    public string GetPlayerType() => "Defender";
}

class Striker : Player, IPlayerType
{
    public Striker(string name, int score) : base(name, "Striker", score) { }

    public string GetPlayerType() => "Striker";
}
class Team
{
    private List<Player> players = new List<Player>();
    public List<Player> Players => players; 
    public void AddPlayer(Player player)
    {
        players.Add(player);
        Console.WriteLine($"Player {player.Name} added.");
    }
    public void RemovePlayer(string name)
    {
        var player = players.FirstOrDefault(p => p.Name == name);
        if (player != null)
        {
            players.Remove(player);
            Console.WriteLine($"Player {name} removed.");
        }
        else
        {
            Console.WriteLine($"Player {name} not found.");
        }
    }
    public void DisplayTeam()
    {
        Console.WriteLine("Team Roster:");
        foreach (var player in players)
        {
            Console.WriteLine(player);
        }
    }
    public void DisplayTeamStats()
    {
        Console.WriteLine("Team Statistics:");
        Console.WriteLine($"Total Players: {players.Count}");
        Console.WriteLine($"Average Score: {CalculateAverageScore()}");
    }
    public double CalculateAverageScore()
    {
        return players.Any() ? players.Average(p => p.Score) : 0;
    }
    public void FindPlayersByPosition(string position)
    {
        var matchingPlayers = players.Where(p => p.Position.Equals(position, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"Players in position {position}:");
        foreach (var player in matchingPlayers)
        {
            Console.WriteLine(player);
        }
    }
    public void FilterPlayers(Func<Player, bool> criteria)
    {
        var filteredPlayers = players.Where(criteria);

        Console.WriteLine("Filtered Players:");
        foreach (var player in filteredPlayers)
        {
            Console.WriteLine(player);
        }
    }
}


