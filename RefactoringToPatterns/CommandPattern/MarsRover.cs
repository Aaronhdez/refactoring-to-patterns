using RefactoringToPatterns.CommandPattern.Commands;

namespace RefactoringToPatterns.CommandPattern
{
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