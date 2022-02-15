using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;

namespace Arena_Fighter
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            RollingDie die = new RollingDie(10);
            Players player = new Players("player", 100, 0, die);
            Players beebop = new Players("Beebop", 100, 11, die);
            Players rocksteady = new Players("Rocksteady", 100, 12, die);
            Players crank = new Players("Crank", 110, 13, die);
            Players shredder = new Players("Shredder", 120, 14, die);
            
            List<Players> enemies = new List<Players>() { beebop, rocksteady, crank, shredder };
            Arena arena = new Arena(player, enemies, die);
            Console.WriteLine("-ARENA FIGHTER-" + "\n");

            player.CreatePlayer();
            arena.FightingTier();
        }
    }
}
