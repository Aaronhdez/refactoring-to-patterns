namespace RefactoringToPatterns.CommandPattern.Commands
{
    public class RotateLeftCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public RotateLeftCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            var currentDirectionPosition = MarsRover.AvailableDirections.IndexOf(_marsRover.Direction);
            UpdateDirection(currentDirectionPosition);
        }

        private void UpdateDirection(int currentDirectionPosition)
        {
            _marsRover.Direction = currentDirectionPosition != 0
                ? MarsRover.AvailableDirections[currentDirectionPosition - 1]
                : MarsRover.AvailableDirections[3];
        }
    }
}