using System;
using System.Collections.Generic;
using RefactoringToPatterns.CommandPattern.Commands;

namespace RefactoringToPatterns.CommandPattern
{
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
            foreach(var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        MoveTowards(Direction);
                        break;
                    case 'L':
                        _rotateLeftCommand.Execute();
                        break;
                    case 'R':
                        _rotateRightCommand.Execute();
                        break;
                }
            }
        }

        private void MoveTowards(char direction)
        {
            var movementCommands = new Dictionary<char, Action>()
            {
                { 'E', new MoveEastCommand(this).Execute},
                { 'S', new MoveSouthCommand(this).Execute},
                { 'W', new MoveWestCommand(this).Execute},
                { 'N', new MoveNorthCommand(this).Execute}
            };
            movementCommands[direction]();
        }
    }
}