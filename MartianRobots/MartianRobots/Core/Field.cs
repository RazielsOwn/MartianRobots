﻿using System.Collections.Generic;

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
        private HashSet<FieldCoordinate> badCoordinates { get; set; }

        public Field(int maximumX, int maximumY)
        {
            badCoordinates = new HashSet<FieldCoordinate>();
            MaximumX = maximumX < 0 ? 0 : maximumX;
            MaximumY = maximumY < 0 ? 0 : maximumY;
        }

        /// <summary>
        /// Check if moving is available for selected direction
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="direction"></param>
        /// <returns>false - if robot will be lost</returns>
        public bool IsMovementAvailable(int currentX, int currentY, RobotDirections direction)
        {
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
                badCoordinates.Add(new FieldCoordinate(currentX, currentY, direction));
            }

            return result;
        }

        /// <summary>
        /// Check if moving is forbidden based on previous robots data (marked squares)
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool IsMovementForbidden(int currentX, int currentY, RobotDirections direction)
        {
            // check stored bad coordinates data
            if (badCoordinates.Contains(new FieldCoordinate(currentX, currentY, direction)))
            {
                // some robot already lost
                return true;
            }

            return false;
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
            if (obj is not FieldCoordinate other)
            {
                throw new System.Exception($"Obj must be {typeof(FieldCoordinate)} data type");
            }
            return X == other.X && Y == other.Y && Direction == other.Direction;
        }
    }
}
