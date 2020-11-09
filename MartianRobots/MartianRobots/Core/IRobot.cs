namespace MartianRobots
{
    public interface IRobot
    {
        RobotDirections CurrentDirection { get; set; }
        int CurrentX { get; set; }
        int CurrentY { get; set; }

        bool NextAction();
    }
}