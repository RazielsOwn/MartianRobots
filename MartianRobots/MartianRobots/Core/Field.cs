using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MartianRobots
{
    /// <summary>
    /// Field for martian robots movement
    /// </summary>
    public class Field : IField
    {
        /// <summary>
        /// Maximum X coordinate
        /// </summary>
        public int MaximumX { get; set; }
        /// <summary>
        /// Maximum Y coordinate
        /// </summary>
        public int MaximumY { get; set; }
        /// <summary>
        /// Bad coordinates with direction storage
        /// </summary>
        public HashSet<FieldCoordinate> BadCoordinates { get; set; }

        public Field(int maximumX, int maximumY)
        {
            MaximumX = maximumX;
            MaximumY = maximumY;
            BadCoordinates = new HashSet<FieldCoordinate>();
        }

        /// <summary>
        /// Check if moving is available for selected direction
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="direction"></param>
        /// <returns>false - if robot will be lost, null - if this direction is forbidden based on previous robots data (marked squares) </returns>
        public bool? CanMoveToDirection(int currentX, int currentY, RobotDirections direction)
        {
            // check stored bad coordinates data
            if (BadCoordinates.Contains(new FieldCoordinate(currentX, currentY, direction)))
            {
                // some robot already lost
                return null;
            }

            var result = false;
            // check further path
            switch (direction)
            {
                case RobotDirections.N:
                    result = currentY < MaximumY;
                    break;
                case RobotDirections.S:
                    result = currentY > 0;
                    break;
                case RobotDirections.W:
                    result = currentX > 0;
                    break;
                case RobotDirections.E:
                    result = currentX < MaximumX;
                    break;
            }

            // save bad coordinate
            if (result == false)
            {
                BadCoordinates.Add(new FieldCoordinate(currentX, currentY, direction));
            }

            return result;
        }
    }

    /// <summary>
    /// Class for bad coordinate hashtable
    /// </summary>
    public class FieldCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RobotDirections Direction { get; set; }

        public FieldCoordinate(int x, int y, RobotDirections direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        // override hash function to quick search by 3 parameters (x and y is less or equal than 50 by initial problem)
        public override int GetHashCode()
        {
            return (int)Direction + 10 * X + 1000 * Y;
        }

        // override equality
        public override bool Equals(object obj)
        {
            FieldCoordinate other = obj as FieldCoordinate;
            return X == other.X && Y == other.Y && Direction == other.Direction;
        }
    }
}
