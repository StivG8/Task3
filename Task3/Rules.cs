using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Rules
    {
        readonly int Count;
        public Rules(int count) => Count = count;

        public Result Calculate(int com, int player)
        {
            if ((player > com && player - com <= Count / 2) ||
                (player < com && com - player > Count / 2))
            {
                return Result.Victory;
            }

            if (com == player)
            {
                return Result.Draw;
            }            

            return Result.Defeat;
        }
    }
    enum Result
    {
        Victory,
        Defeat,
        Draw
    }
}
