using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Raylib_cs;
using MathLibrary;


namespace HelloWorld
{
    class Player : Character
    {
        private Items[] _pocket;
        private Items _currentWeapon;
        private Items _hands;

        public Player() : base()
        {
            _pocket = new Items[3];
            _hands.statName = "Your fugly hands";
            _hands.statBoost = 0;
        }
        public Player(string nameVal, float healthVal, float damageVal, int levelVal, int pocketSize)
            : base(damageVal, healthVal, nameVal)
        {
            _pocket = new Items[pocketSize];
            _hands.statName = "Your fugly hands";
            _hands.statBoost = 0;
        }

        public override void Save(StreamWriter writer)
        {
            //save the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_pocket[0].statName);
            writer.WriteLine(_damage);
            writer.WriteLine(_pocket[0].statBoost);
            writer.WriteLine(_health);
        }

        public override bool Load(StreamReader reader)
        {
            if(File.Exists("SaveData.txt") == false)
            {
                return false;
            }

            //creates variable to the store loaded data.
            string name = reader.ReadLine();
            string weaponname = reader.ReadLine();
            float damage = 0;
            int weapondamage = 0;
            float health = 0;
            
            //checks to see if loading was successful
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out weapondamage) == false)
            {
                return false;
            }
            //if successful, set update the member variables and return true.
            _name = name;
            _currentWeapon.statName = weaponname;
            _damage = damage;
            _currentWeapon.statBoost = weapondamage;
            _health = health;
            return true;
        }

        public void AddItemToPocket(Items item, int index)
        {
            _pocket[index] = item;

        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _pocket.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex) == true)
            {
                _currentWeapon = _pocket[itemIndex];
            }
        }

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public Items[] GetPocket()
        {
            return _pocket;
        }

        public override float Attack(Character enemy)
        {
            float totalDamage = _damage + _currentWeapon.statBoost;
            return enemy.TakeDamage(totalDamage);
        }

    }
}
