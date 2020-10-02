using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class AdvancedPlayer : Character
    {
        private string _role;
        private int _level;
        private int _mana;
        private int _charisma;
        private int _karma;
        private int _luck;
        private int _stealth;

        private Items _currentWeapon;
        private Items _hands;
        private Items[] _inventory;

        //Calls the default constructor for the Advanced Player, and then calls the base classes constructor.
        public AdvancedPlayer() : base()
        {
            _role = "Hero";
            _level = 0;
            _mana = 0;
            _charisma = 0;
            _karma = 0;
            _luck = 0;
            _stealth = 0;

            _hands.statName = "Your fugly hands";
            _hands.statBoost = 0;
        }

        public AdvancedPlayer(float healthVal, float damageVal, string nameVal, int levelVal, int manaVal, int charismaVal, int karmaVal, int luckVal, int stealthVal, string roleVal, int inventorySize)
            : base(healthVal, damageVal, nameVal)
        {
            _level = levelVal;
            _mana = manaVal;
            _charisma = charismaVal;
            _karma = karmaVal;
            _luck = luckVal;
            _stealth = stealthVal;
            _role = roleVal;

            _hands.statName = "Your fugly hands";
            _hands.statBoost = 0;
        }

        public void PrintAdvancedStats()
        {
            Console.WriteLine("\nName: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("\nLevel: " + _level);
            Console.WriteLine("Role: " + _role);
            Console.WriteLine("Mana: " + _mana);
            Console.WriteLine("Charisma: " + _charisma);
            Console.WriteLine("Karma: " + _karma);
            Console.WriteLine("luck: " + _luck);
            Console.WriteLine("Stealth: " + _stealth);
        }

        //this will put item into a slot of inventory 
        public void AddItemToInventory(Items item, int index)
        {
            _inventory[index] = item;

        }

        //this checks to see if the inventory has at least one item inside of the slots
        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        //this will allow the item from the inventory to affect the players stats
        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex) == true)
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        //this is similar to EquipItem() however it takes away from the players stats
        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        //this will allow the program to print what is in the slots for the inventory =
        public Items[] GetInventory()
        {
            return _inventory;
        }


        //everything below will +1 the stats
        public int LevelUp()
        {
            return _level + 1;
        }

        
        public int CharismaUp()
        {
            return _charisma + 1;
        }

        public int KarmaUp()
        {
            return _karma + 1;
        }

        public int LuckUp()
        {
            return _luck + 1;
        }
    }
}
