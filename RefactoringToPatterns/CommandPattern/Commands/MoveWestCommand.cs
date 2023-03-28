using System.Linq;

namespace RefactoringToPatterns.CommandPattern.Commands
{
    public class MoveWestCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public MoveWestCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.X = ALimitHasBeenReached() ? _marsRover.X -= 1 : _marsRover.X;
        }

        private bool ALimitHasBeenReached()
        {
            return APlateauEdgeHasBeenReached() && !AnObstacleFound();
        }

        private bool APlateauEdgeHasBeenReached()
        {
            return _marsRover.X > 0;
        }

        private bool AnObstacleFound()
        {
            return _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X - 1}:{_marsRover.Y}");
        }
    }
}