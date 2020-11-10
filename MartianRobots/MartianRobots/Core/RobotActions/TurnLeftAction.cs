using MartianRobots.RobotActions;

namespace MartianRobots.Core.RobotActions
{
    public class TurnLeftAction : IActionStrategy
    {
        public bool DoAction(IField currentField, IRobot currentRobot)
        {
            currentRobot.CurrentDirection = currentRobot.CurrentDirection.Previous();
            return true;
        }
    }
}