namespace MartianRobots.RobotActions
{
    public interface IActionStrategy
    {
        public bool DoAction(IField currentField, IRobot currentRobot);
    }
}
