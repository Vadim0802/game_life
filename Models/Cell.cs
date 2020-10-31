using GameLife.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLife.Models
{
    class Cell
    {
        public bool isAlive { get; set; } = true;
        public bool ChangeStateNextStep { get; set; } = false;
        public int CounterLiveNeighbours { get; set; }

        public Cell(char symbol)
        {
            switch (symbol)
            {
                case '.':
                    isAlive = false;
                    break;
                case '#':
                    isAlive = true;
                    break;
                default:
                    throw new InvalidGameMapException();
            }
        }
    }
}
