using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _gold;
        private Items[] _shopInventory;

        public Shop()
        {
            _shopInventory = new Items[7];
            _gold = 10;
        }
        public Shop(Items[] items)
        {
            _shopInventory = items;
            _gold = 10;
        }


        public bool SellWithGold(AdvancedPlayer _player, int shopIndex, int playerIndex)
        {
            //Find the item to buy in the inventory array
            Items itemToBuy = _shopInventory[shopIndex];
            //Check to see if the player ourchased the item successfully.
            if (_player.BuyWithGold(itemToBuy, playerIndex))
            {
                //Increase shops gold by item cost to complete the transaction
                _gold += itemToBuy.itemPrice;
                return true;
            }
            return false;
        }

        public bool SellWithSilver(AdvancedPlayer _player, int shopIndex, int playerIndex)
        {
            //Find the item to buy in the inventory array
            Items itemToBuy = _shopInventory[shopIndex];
            //Check to see if the player ourchased the item successfully.
            if (_player.BuyWithSilver(itemToBuy, playerIndex))
            {
                //Increase shops gold by item cost to complete the transaction
                _gold += itemToBuy.itemPrice;
                return true;
            }
            return false;
        }


    }
}
