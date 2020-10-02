using System;
using System.Collections.Generic;
using System.Text;

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


    }
}
