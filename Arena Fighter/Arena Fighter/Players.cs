using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Arena_Fighter
{
    class Players
    {
        private string playerName;
        private int playerHealth;
        private int playerStrenght;
        private RollingDie playerDie;

        public Players(string playerName, int playerHealth, int playerStrenght, RollingDie playerDie)
        {
            this.playerName = playerName;
            this.playerHealth = playerHealth;
            this.playerStrenght = playerStrenght;
            this.playerDie = playerDie;
        }

        public override string ToString()
        {
            return playerName;
        }

        public bool PlayerAlive()
        {
            return (playerHealth > 0);
        }

        public void PlayerAttack(Players player)
        {
            Console.Write("\n" + "Press any key to Roll Die" + "\n");
            Console.ReadKey();
            int playerHit = playerStrenght + playerDie.Roll();



            Console.WriteLine(playerName + " hit with " + playerHit + " Damage");
            player.PlayerTakeDamage(playerHit);
        }

        public void PlayerTakeDamage(int playerHit)
        {
            int playerDamageTaken = playerHit;
            if (playerDamageTaken > 0)
            {
                playerHealth -= playerDamageTaken;
                if (playerHealth <= 0)
                {
                    playerHealth = 0;
                    /*Logger();*/
                    Console.WriteLine(playerName + " is defeated");
                }
                else
                {
                    Console.WriteLine("\n" + playerName + " HP: " + playerHealth);
                }
            }
        }
        public void PlayerAddStats()
        {
            playerHealth += 75;
            playerStrenght += 3;
        }

        public void CreatePlayer()
        {
            Console.WriteLine("Choose Fighter Name: ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome " + playerName + "!" + "\n");

            Console.WriteLine("Rolling strenght.." + "\n");
            Thread.Sleep(2000);

            var random = new Random();
            playerStrenght = random.Next(10, 20);
            Console.WriteLine("\n" + "-Your Fighter-" + "\n" + playerName + ", " + "Strenght: " + " " + playerStrenght);
            Console.WriteLine("Press any key to enter battle");
            Console.ReadKey();
        }
        /*public void Logger()
        {
            FileStream filestream = new FileStream("out.txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = false;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
        }*/
    }
}
