using System;
using System.Collections.Generic;
using GameLife.Models;

namespace GameLife.Controllers
{
    class CellsController
    {
        public static int _B;
        public static int _A;
        public static int _X;
        public static int _Y;
        public static int MAX_ITER;
        public bool _thereAnyChanges = true;

        public static List<List<Cell>> Map = new List<List<Cell>>();

        public void ChangeStateCell()
        {
            for (int i = 0; i < Map.Count; i++)
            {
                for (int j = 0; j < Map[i].Count; j++)
                {
                    var currentCell = Map[i][j];

                    if (i + 1 < Map.Count)
                        if (Map[i + 1][j].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (i - 1 >= 0)
                        if (Map[i - 1][j].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (j + 1 < Map[i].Count)
                        if (Map[i][j + 1].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (j - 1 >= 0)
                        if (Map[i][j - 1].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (i + 1 < Map.Count && j + 1 < Map[i].Count)
                        if (Map[i + 1][j + 1].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        if (Map[i - 1][j - 1].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (i + 1 < Map.Count && j - 1 >= 0)
                        if (Map[i + 1][j - 1].isAlive)
                            currentCell.CounterLiveNeighbours++;
                    if (i - 1 >= 0 && j + 1 < Map[i].Count)
                        if (Map[i - 1][j + 1].isAlive)
                            currentCell.CounterLiveNeighbours++;

                    if (currentCell.isAlive)
                    {
                        if (currentCell.CounterLiveNeighbours < _X || currentCell.CounterLiveNeighbours > _Y)
                        {
                            currentCell.ChangeStateNextStep = true;
                        }
                    }
                    else
                    {
                        if (currentCell.CounterLiveNeighbours >= _A && currentCell.CounterLiveNeighbours <= _B)
                        {
                            currentCell.ChangeStateNextStep = true;
                        }
                    }
                    currentCell.CounterLiveNeighbours = 0;
                }
            }
        }

        public void PrintMap()
        {
            foreach (var item in Map)
            {
                foreach (var symbol in item)
                {
                    Console.Write(symbol.isAlive ? '#' : '.');
                }
                Console.WriteLine();
            }
        }

        public void NextState()
        {
            int _counterChangesState = 0;

            foreach (var item in Map)
            {
                foreach (var subitem in item)
                {
                    if (subitem.ChangeStateNextStep)
                    {
                        _counterChangesState++;
                        subitem.isAlive = !subitem.isAlive;
                        subitem.ChangeStateNextStep = false;
                    }
                }
            }

            if (_counterChangesState == 0)
                _thereAnyChanges = false;
        }

        public override string ToString()
        {
            string toString = "";
            foreach (var item in Map)
            {
                foreach (var symbol in item)
                {
                    toString += $"{(symbol.isAlive ? '#' : '*')}";
                }
                toString += "\n";
            }

            return toString;
        }
    }
}
