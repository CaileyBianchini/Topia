using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private Items[] _inventory;
        private Items _currentWeapon;
        private Items _hands;

        public Player() : base()
        {
            
            _hands.statName = "Your fugly hands";
            _hands.statBoost = 0;
        }
        public Player(string nameVal, float healthVal, float damageVal, int levelVal, int inventorySize)
            : base(damageVal, healthVal, nameVal, inventorySize)
        {
            _hands.statName = "Your fugly hands";
            _hands.statBoost = 0;
        }


        public void AddItemToInventory(Items item, int index)
        {
            _inventory[index] = item;

        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex) == true)
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public Items[] GetInventory()
        {
            return _inventory;
        }


    }
}
