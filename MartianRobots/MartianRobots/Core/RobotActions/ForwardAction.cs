using MartianRobots.RobotActions;

namespace MartianRobots.Core.RobotActions
{
    public class ForwardAction : IActionStrategy
    {
        public bool DoAction(IField currentField, IRobot currentRobot)
        {
            var canMove = currentField.CanMoveToDirection(currentRobot.CurrentX, currentRobot.CurrentY, currentRobot.CurrentDirection);
            if (canMove == null)
            {
                // direction forbidden so skip action
                return true;
            }

            if (!canMove.Value)
            {
                // robot will be lost so just stop further execution
                return false;
            }


            switch (currentRobot.CurrentDirection)
            {
                case RobotDirections.N:
                    currentRobot.CurrentY++;
                    break;
                case RobotDirections.S:
                    currentRobot.CurrentY--;
                    break;
                case RobotDirections.W:
                    currentRobot.CurrentX--;
                    break;
                case RobotDirections.E:
                    currentRobot.CurrentX++;
                    break;
            }

            return true;
        }
    }
}
