using System;
using System.Collections.Generic;

namespace MartianRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(5, 3);

            var robots = new List<Robot>
            {
                new Robot(field, 1, 1, "E", "RFRFRFRF"),
                new Robot(field, 3, 2, "N", "FRRFLLFFRRFLL"),
                new Robot(field, 0, 3, "W", "LLFFFLFLFL")
            };

            foreach (var robot in robots)
            {
                var movementSuccess = robot.ExecuteActions();
                if (movementSuccess)
                {
                    Console.WriteLine($"{robot.CurrentX} {robot.CurrentY} {robot.CurrentDirection}");
                }
                else
                {
                    // robot lost
                    Console.WriteLine($"{robot.CurrentX} {robot.CurrentY} {robot.CurrentDirection} LOST");
                }
            }
        }
    }
}
