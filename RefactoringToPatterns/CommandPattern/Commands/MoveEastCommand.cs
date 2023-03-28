using System.Linq;

namespace RefactoringToPatterns.CommandPattern.Commands
{
    public class MoveEastCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public MoveEastCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X + 1}:{_marsRover.Y}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover.X = _marsRover.X < 9 && !_marsRover.ObstacleFound ? _marsRover.X += 1 : _marsRover.X;
            return;
        }
    }
}