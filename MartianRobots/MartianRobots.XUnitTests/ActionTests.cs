using MartianRobots.Core.RobotActions;
using Moq;
using Xunit;

namespace MartianRobots.XUnitTests
{
    public class ActionTests
    {
        [Fact]
        public void Initialization()
        {
            // Arrange
            var nullAction = ActionStrategyFabric.GetAction('_');
            var forwardAction = ActionStrategyFabric.GetAction('F');
            var turnLeftAction = ActionStrategyFabric.GetAction('L');
            var turnRightAction = ActionStrategyFabric.GetAction('R');
            // Act

            // Assert
            Assert.Null(nullAction);
            Assert.IsType<ForwardAction>(forwardAction);
            Assert.IsType<TurnLeftAction>(turnLeftAction);
            Assert.IsType<TurnRightAction>(turnRightAction);
        }

        [Fact]
        public void ForwardAction()
        {
            // Arrange
            var fieldMock = new Mock<IField>();
            fieldMock.Setup(f => f.CanMoveToDirection(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<RobotDirections>())).Returns(true);

            var robot = new Robot(fieldMock.Object, 0, 0, "N", "");
            var robot1 = new Robot(fieldMock.Object, 0, 0, "E", "");
            var forwardAction = ActionStrategyFabric.GetAction('F');
            // Act
            forwardAction.DoAction(fieldMock.Object, robot);
            forwardAction.DoAction(fieldMock.Object, robot1);
            // Assert
            // first robot moves North(Y axis)
            Assert.Equal(0, robot.CurrentX);
            Assert.Equal(1, robot.CurrentY);
            // first robot moves North(X axis)
            Assert.Equal(1, robot1.CurrentX);
            Assert.Equal(0, robot1.CurrentY);
        }

        [Fact]
        public void TurnRightAction()
        {
            // Arrange
            var fieldMock = new Mock<IField>();
            var robot = new Robot(fieldMock.Object, 0, 0, "N", "");
            var turnRightAction = ActionStrategyFabric.GetAction('R');

            // Act
            turnRightAction.DoAction(fieldMock.Object, robot);

            // Assert            
            Assert.Equal(RobotDirections.E, robot.CurrentDirection);
        }

        [Fact]
        public void TurnLeftAction()
        {
            // Arrange
            var fieldMock = new Mock<IField>();
            var robot = new Robot(fieldMock.Object, 0, 0, "N", "");
            var turnRightAction = ActionStrategyFabric.GetAction('L');

            // Act
            turnRightAction.DoAction(fieldMock.Object, robot);

            // Assert            
            Assert.Equal(RobotDirections.W, robot.CurrentDirection);
        }
    }
}
