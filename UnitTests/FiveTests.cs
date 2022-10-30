using DungeonLibrary;
namespace UnitTests
{
    public class FiveTests
        //made dungeon and dungeon library references
    {
        [Fact]
        public void checkWeaponDamage()
        {
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1, 0, 0);
            Player player = new Player(name: "Johny", hitChance: 70, block: 5, maxLife: 40, characterRace: Race.Human, equippedWeapon: sword);
            int actual = player.CalcDamage();
            bool expected = (actual < 9 && actual > 0);
            Assert.True(expected);
        }
        [Fact]
        public void checkPlayerHitChance()
        {
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1, 0, 0);
            Player player = new Player(name: "Johny", hitChance: 70, block: 5, maxLife: 40, characterRace: Race.Human, equippedWeapon: sword);
            int expected = (70+10);
            int actual = player.CalcHitChance();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void checkCalcBlock()
        {
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1, 0, 0);
            Player player = new Player(name: "Johny", hitChance: 70, block: 5, maxLife: 40, characterRace: Race.Human, equippedWeapon: sword);
            int expected = (5);
            int actual = player.CalcBlock();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void checkCharacterRace()
        {
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1, 0, 0);
            Player player = new Player(name: "Johny", hitChance: 70, block: 5, maxLife: 40, characterRace: Race.Human, equippedWeapon: sword);
            bool expected = true;
            bool actual = player.CharacterRace.GetType() == typeof(Race);
            Assert.True(actual);
        }
        [Fact]
        public void checkCombat()
        {
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1, 0, 0);
            Player player = new Player(name: "Johny", hitChance: 70, block: 5, maxLife: 40, characterRace: Race.Human, equippedWeapon: sword);
            Vampire vampire = new Vampire(name: "Batty: Menace of the Night", maxLife: 20, hitChance: 50, block: 6, minDamage: 1, maxDamage: 8, description: "Night is a scary time to be outside.", rarity: "Uncommon");
            Monster expected = vampire;
            Monster actual = Monster.GetMonster();
            Assert.Equal(expected, actual);
        }
    }
}
//I'm not really sure how this should work. I have multipe sections where I obtain user input and the values won't exist inside the context of the program.
//Moreover player params change based on race as is in a switch in the player class? Would it have been better to change the races to classes of their own so they can have +/- values for these combat params?