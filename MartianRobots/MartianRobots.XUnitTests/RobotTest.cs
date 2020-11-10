using Xunit;

namespace MartianRobots.XUnitTests
{
    public class RobotTest
    {
        [Fact]
        public void Initialization()
        {
            // Arrange
            var field = new Field(3, 3);
            var robot = new Robot(field, -1, -1, "", "");
            var robot1 = new Robot(field, 2, 2, "S", "");
            // Act

            // Assert
            Assert.Equal(0, robot.CurrentX);
            Assert.Equal(0, robot.CurrentY);
            Assert.Equal(RobotDirections.N, robot.CurrentDirection);

            Assert.Equal(2, robot1.CurrentX);
            Assert.Equal(2, robot1.CurrentY);
            Assert.Equal(RobotDirections.S, robot1.CurrentDirection);
        }
    }
}
