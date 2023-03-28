using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public interface ICommand
    {
        void Execute();
    }

    public class MoveWestCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public MoveWestCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X - 1}:{_marsRover.Y}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover.X = _marsRover.X > 0 && !_marsRover.ObstacleFound ? _marsRover.X -= 1 : _marsRover.X;
        }
    }

    public class MoveNorthCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public MoveNorthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y - 1}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover.Y = _marsRover.Y > 0 && !_marsRover.ObstacleFound ? _marsRover.Y -= 1 : _marsRover.Y;
        }
    }

    public class MoveSouthCommand : ICommand
    {
        private readonly MarsRover _marsRover;

        public MoveSouthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y + 1}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover.Y = _marsRover.Y < 9 && !_marsRover.ObstacleFound ? _marsRover.Y += 1 : _marsRover.Y;
        }
    }

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

    public class MarsRover
    {
        public int X;
        public int Y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        public readonly string[] Obstacles;
        public bool ObstacleFound;
        private readonly MoveWestCommand _moveWestCommand;
        private readonly MoveNorthCommand _moveNorthCommand;
        private readonly MoveSouthCommand _moveSouthCommand;
        private readonly MoveEastCommand _moveEastCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            _direction = direction;
            Obstacles = obstacles;
            _moveWestCommand = new MoveWestCommand(this);
            _moveNorthCommand = new MoveNorthCommand(this);
            _moveSouthCommand = new MoveSouthCommand(this);
            _moveEastCommand = new MoveEastCommand(this);
        }
        
        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{_direction}" : $"O:{X}:{Y}:{_direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    switch (_direction)
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
                    RotateLeft();
                } else if (command == 'R')
                {
                    RotateRight();
                }
            }
        }

        private void RotateRight()
        {
            // get new direction
            var currentDirectionPosition = _availableDirections.IndexOf(_direction);
            if (currentDirectionPosition != 3)
            {
                _direction = _availableDirections[currentDirectionPosition + 1];
            }
            else
            {
                _direction = _availableDirections[0];
            }
        }

        private void RotateLeft()
        {
            // get new direction
            var currentDirectionPosition = _availableDirections.IndexOf(_direction);
            if (currentDirectionPosition != 0)
            {
                _direction = _availableDirections[currentDirectionPosition - 1];
            }
            else
            {
                _direction = _availableDirections[3];
            }
        }
    }
}