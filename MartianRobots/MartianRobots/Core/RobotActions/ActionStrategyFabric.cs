using MartianRobots.RobotActions;

namespace MartianRobots.Core.RobotActions
{
    public static class ActionStrategyFabric
    {
        public static IActionStrategy GetAction(char nextAction)
        {
            switch (nextAction)
            {
                // turn left
                case 'L':
                    return new TurnLeftAction();
                // turn right
                case 'R':
                    return new TurnRightAction();
                // move forward
                case 'F':
                    return new ForwardAction();
            }
            return null;
        }
    }
}
