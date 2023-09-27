namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceTravel.Models.Obstacles;

public class Obstacle
{
    private int _damagePoints;
    protected Obstacle(int damagePoints)
    {
        _damagePoints = damagePoints;
    }

    public int DamagePoints { get => _damagePoints; }
}