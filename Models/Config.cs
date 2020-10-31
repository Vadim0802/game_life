using GameLife.Controllers;
using GameLife.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameLife.Models
{
    static class Config
    {
        public static void GetMap(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int lengthLine = lines[0].Length;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = new List<Cell>();

                if (lengthLine != lines[i].Length)
                    throw new InvalidGameMapException();

                for (int j = 0; j < lines[0].Length; j++)
                    line.Add(new Cell(lines[i][j]));

                CellsController.Map.Add(line);
            }
        }

        public static void GetConditions(string path)
        {
            string[] lines = File.ReadAllLines(path);

            if (lines.Length != 5)
                throw new InvalidConfigException();

            foreach (string item in lines)
            {
                string[] paramLine = item
                    .Replace('\t', ' ')
                    .Split('=');

                switch (paramLine[0].Trim(' '))
                {
                    case "A":
                        CellsController._A = Convert.ToInt32(paramLine[1].Trim(' '));
                        break;
                    case "B":
                        CellsController._B = Convert.ToInt32(paramLine[1].Trim(' '));
                        break;
                    case "X":
                        CellsController._X = Convert.ToInt32(paramLine[1].Trim(' '));
                        break;
                    case "Y":
                        CellsController._Y = Convert.ToInt32(paramLine[1].Trim(' '));
                        break;
                    case "MAX_ITER":
                        CellsController.MAX_ITER = Convert.ToInt32(paramLine[1].Trim(' '));
                        break;
                    default:
                        throw new InvalidConfigException();
                }
            }
        }
    }
}
