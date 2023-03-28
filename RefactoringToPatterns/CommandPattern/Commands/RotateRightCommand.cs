namespace RefactoringToPatterns.CommandPattern.Commands
{
    public class RotateRightCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public RotateRightCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            // get new direction
            var currentDirectionPosition = MarsRover.AvailableDirections.IndexOf(_marsRover.Direction);
            if (currentDirectionPosition != 3)
            {
                _marsRover.Direction = MarsRover.AvailableDirections[currentDirectionPosition + 1];
            }
            else
            {
                _marsRover.Direction = MarsRover.AvailableDirections[0];
            }
        }
    }
}