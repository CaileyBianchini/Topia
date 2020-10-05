using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        private float _specialdamage;

        private Items _currentWeapon;
        private Items _hands;
        protected Items[] _inventory;

        //currency
        private int _gold;

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

            _gold = 10;
        }

        public AdvancedPlayer(float healthVal, float damageVal, string nameVal, int levelVal, int manaVal, int charismaVal, int karmaVal, int luckVal, int stealthVal, string roleVal, int inventorySize, int goldVal)
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

            _gold = goldVal;
        }

        public override void Save(StreamWriter writer)
        {
            //save the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_damage);
            writer.WriteLine(_health);
            writer.WriteLine(_role);
            writer.WriteLine(_level);
            writer.WriteLine(_mana);
            writer.WriteLine(_charisma);
            writer.WriteLine(_karma);
            writer.WriteLine(_luck);
            writer.WriteLine(_stealth);
            
        }

        public override bool Load(StreamReader reader)
        {
            if(File.Exists("SaveAdventure.txt") == false)
            {
                return false;
            }

            //creates variable to the store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            string role = reader.ReadLine();
            int level = 0;
            int mana = 0;
            int charisma = 0;
            int karma = 0;
            int luck = 0;
            int stealth = 0;

            //checks to see if loading was successful
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out level) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out mana) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out charisma) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out karma) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out luck) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out stealth) == false)
            {
                return false;
            }
            //if successful, set update the member variables and return true.
            _name = name;
            _damage = damage;
            _health = health;
            _role = role;
            _level = level;
            _mana = mana;
            _charisma = charisma;
            _karma = karma;
            _luck = luck;
            _stealth = stealth;
            return true;
        }


        //this will use TakeDamage against the enemy using players damage
        public override float Attack(Character enemy)
        {
            float totalDamage = 0.0f;
            if (_mana >= 5)
            {
                float damageTaken = _damage + _mana * .25f;
                _mana -= 5;
                damageTaken = enemy.TakeDamage(totalDamage);
                return damageTaken;
            }
            totalDamage = base.Attack(enemy);
            return totalDamage;
        }

        public override void PrintStats()
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

        public bool BuyWithGold(Items item, int Item)
        {
            if (_gold >= item.itemPrice)
            {
                //Pay for item.
                _gold -= item.itemPrice;
                //Place item in inventory array.
                _inventory[Item] = item;
                return true;
            }
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
