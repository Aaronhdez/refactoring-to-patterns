using RefactoringToPatterns.CommandPattern.Commands;

namespace RefactoringToPatterns.CommandPattern
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

    public class RotateLeftCommand : ICommand
    {
        private MarsRover _marsRover;

        public RotateLeftCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            // get new direction
            var currentDirectionPosition = MarsRover.AvailableDirections.IndexOf(_marsRover.Direction);
            if (currentDirectionPosition != 0)
            {
                _marsRover.Direction = MarsRover.AvailableDirections[currentDirectionPosition - 1];
            }
            else
            {
                _marsRover.Direction = MarsRover.AvailableDirections[3];
            }
        }
    }

    public class MarsRover
    {
        public int X;
        public int Y;
        public char Direction;
        public const string AvailableDirections = "NESW";
        public readonly string[] Obstacles;
        public bool ObstacleFound;
        private readonly MoveWestCommand _moveWestCommand;
        private readonly MoveNorthCommand _moveNorthCommand;
        private readonly MoveSouthCommand _moveSouthCommand;
        private readonly MoveEastCommand _moveEastCommand;
        private readonly RotateRightCommand _rotateRightCommand;
        private readonly RotateLeftCommand _rotateLeftCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            Direction = direction;
            Obstacles = obstacles;
            _moveWestCommand = new MoveWestCommand(this);
            _moveNorthCommand = new MoveNorthCommand(this);
            _moveSouthCommand = new MoveSouthCommand(this);
            _moveEastCommand = new MoveEastCommand(this);
            _rotateRightCommand = new RotateRightCommand(this);
            _rotateLeftCommand = new RotateLeftCommand(this);
        }
        
        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{Direction}" : $"O:{X}:{Y}:{Direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    switch (Direction)
                    {
                        case 'E':
                            _moveEastCommand.Execute();
                            break;
                        case 'S':
                            _moveSouthCommand.Execute();
                            break;
                        case 'W':
                            _moveWestCommand.Execute();
                            break;
                        case 'N':
                            _moveNorthCommand.Execute();
                            break;
                    }
                }
                else if(command == 'L')
                {
                    _rotateLeftCommand.Execute();
                } else if (command == 'R')
                {
                    _rotateRightCommand.Execute();
                }
            }
        }
    }
}