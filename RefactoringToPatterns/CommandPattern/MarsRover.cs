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
        private readonly Dictionary<char, Action> _movementCommands;
        private readonly Dictionary<char, Action> _rotationCommands;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            Direction = direction;
            Obstacles = obstacles;
            _movementCommands = new Dictionary<char, Action>()
            {
                { 'E', new MoveEastCommand(this).Execute},
                { 'S', new MoveSouthCommand(this).Execute},
                { 'W', new MoveWestCommand(this).Execute},
                { 'N', new MoveNorthCommand(this).Execute}
            };
            _rotationCommands = new Dictionary<char, Action>()
            {
                { 'L', new RotateLeftCommand(this).Execute},
                { 'R', new RotateRightCommand(this).Execute},
            };
        }
        
        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{Direction}" : $"O:{X}:{Y}:{Direction}";
        }

        public void Execute(string commands)
        {
            foreach(var command in commands)
            {
                if (command == 'M') _movementCommands[Direction]();
                if (command == 'L' || command == 'R') _rotationCommands[command]();
            }
        }
    }
}