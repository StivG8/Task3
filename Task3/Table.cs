using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Table
    {
        readonly string[] Moves;
        public Table(string[] moves)
        {
            Moves = moves;
        }

        public void Print()
        {
            var tab = new ConsoleTable(Moves.Prepend("PC \\ User").ToArray());

            for (int i = 0; i < Moves.Length; i++)
            {
                string[] row = new string[Moves.Length + 1];
                row[0] = Moves[i];

                for (int j = 0; j < Moves.Length; j++)
                {
                    row[j + 1] = Enum.GetName(typeof(Result), new Rules(Moves.Length).Calculate(i, j))!;
                }

                tab.AddRow(row.ToArray());
            }

            tab.Write(Format.Alternative);
            Console.WriteLine("\n\n");
        }
    }
}
