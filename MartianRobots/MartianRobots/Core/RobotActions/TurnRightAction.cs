﻿using MartianRobots.RobotActions;

namespace MartianRobots.Core.RobotActions
{
    public class TurnRightAction : IActionStrategy
    {
        public bool DoAction(IField currentField, IRobot currentRobot)
        {
            currentRobot.CurrentDirection = currentRobot.CurrentDirection.Next();
            return true;
        }
    }
}