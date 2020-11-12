using Xunit;

namespace MartianRobots.XUnitTests
{
    public class FieldTest
    {
        [Fact]
        public void Initialization()
        {
            // Arrange
            var field = new Field(-1, -1);
            var field1 = new Field(5, 5);
            // Act

            //Assert
            Assert.Equal(0, field.MaximumX);
            Assert.Equal(0, field.MaximumY);
            
            Assert.Equal(5, field1.MaximumX);
            Assert.Equal(5, field1.MaximumY);
        }

        [Fact]
        public void CanMove()
        {
            // Arrange
            var field = new Field(3, 3);

            // Act
            var canMove = field.IsMovementAvailable(3, 2, RobotDirections.N);
            // false as this move is limited by field size
            var lostMove = field.IsMovementAvailable(3, 3, RobotDirections.N);
            // must be null based on remembered previous action
            var cantMove = field.IsMovementForbidden(3, 3, RobotDirections.N);

            // Assert
            Assert.True(canMove);
            Assert.False(lostMove);
            Assert.True(cantMove);
        }
    }
}
