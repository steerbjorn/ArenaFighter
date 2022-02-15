using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Arena_Fighter
{
    class Arena
    {
        private List<Players> enemies;
        private RollingDie die;
        private Players player;

        public Arena(Players player, List<Players> enemies, RollingDie die)
        {
            this.player = player;
            this.enemies = enemies;
            this.die = die;
        }



        public void FightingTier()
        {
            int playerScore = 0;
            var aliveEnemies = enemies;
            var Random = new Random();
            while (aliveEnemies.Count > 0 && player.PlayerAlive())
            {
                var randomEnemy = Random.Next(aliveEnemies.Count);
                var enemy = aliveEnemies.ElementAt(randomEnemy);
                aliveEnemies.RemoveAt(randomEnemy);

                Console.WriteLine(enemy + " APPEARS, FIGHT!" + "\n");
                while (player.PlayerAlive() && enemy.PlayerAlive())
                {
                    player.PlayerAttack(enemy);
                    Thread.Sleep(300);
                    if (enemy.PlayerAlive())
                    {
                        enemy.PlayerAttack(player);
                        Thread.Sleep(300);
                    }
                }
                if (!enemy.PlayerAlive() && player.PlayerAlive())
                {
                    aliveEnemies.Remove(enemy);
                    player.PlayerAddStats();
                    Console.WriteLine("You defeated " + enemy);
                    Console.WriteLine("You gained 75HP and 3STR");
                    playerScore += 100;
                }
                if (enemy.PlayerAlive() && !player.PlayerAlive())
                {
                    Console.WriteLine("Game Over, your total score is: " + playerScore);
                    Environment.Exit(0);
                }
            }
        }
    }
}
