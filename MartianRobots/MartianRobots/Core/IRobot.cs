namespace MartianRobots
{
    public interface IRobot
    {
        RobotDirections CurrentDirection { get; set; }
        int CurrentX { get; set; }
        int CurrentY { get; set; }
        /// <summary>
        /// Method for next robot action in Queue
        /// </summary>
        /// <returns>true - if all is alright, false - if robot lost</returns>
        bool ExecuteActions();
    }
}