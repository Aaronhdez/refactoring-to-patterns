using System.Linq;

namespace RefactoringToPatterns.CommandPattern.Commands
{
    public class MoveSouthCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public MoveSouthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.Y = ALimitHasBeenReached() ? _marsRover.Y += 1 : _marsRover.Y;
        }

        private bool ALimitHasBeenReached()
        {
            return APlateauEdgeHasBeenReached() && !AnObstacleFound();
        }

        private bool APlateauEdgeHasBeenReached()
        {
            return _marsRover.Y < 9;
        }

        private bool AnObstacleFound()
        {
            return _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y + 1}");
        }
    }
}