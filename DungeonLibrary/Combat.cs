using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //one-sided attack
        public static void DoAttack(Character attacker, Character defender)
        {
            //Roll a 100 sided dice
            int roll = new Random().Next(1, 101);
            Thread.Sleep(50);
            //The attacker "hits" if the roll is less than the attacker's hit - defender's block.
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //calculate the damage
                int damageDealt = attacker.CalcDamage();
                //Detract that damage from the defender's life
                defender.Life -= damageDealt;
                //output the results to the screen
                //Red text helps indicate damage
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();//returns the color to normal
            }
            else //the attacker missed
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }
        }

        //Now we can create a method to handle "battle" - attack from both sides
        public static void DoBattle(Player player, Monster monster)
        {
            #region Potential Expansion - Initiative

            //Consider adding an "Initiative" property to Character
            //Then check the Initiative to determine who attacks first
            //if (player.Initiative >= monster.Initiative)
            //{
            //    DoAttack(player, monster);
            //}
            //else
            //{
            //    DoAttack(monster, player);
            //}

            #endregion

            DoAttack(player, monster);
            //If the monster survives, let them attack the player back
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
