using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class SinglePlayer
    {

        struct Items
        {
            public int statBoost;
            public string statName;
            public int itemPrice;
        }


        bool _gameOver = false;

        private Player _player1;

        //weapons
        private Items _longSword;
        private Items _dagger;
        private Items _ax;
        private Items _staff;
        private Items _mace;
        private Items _hammer;


        //shop
        private Shop shop;
        private Items shopInventory;
        private Items _money;



        public void InitializeItems()
        {
            _longSword.statBoost = 15;
            _longSword.statName = "Long Sword";
            _longSword.itemPrice = 4;

            _dagger.statBoost = 10;
            _dagger.statName = "Dagger";
            _dagger.itemPrice = 2;

            _ax.statBoost = 13;
            _ax.statName = "Ax";
            _ax.itemPrice = 2;

            _staff.statBoost = 14;
            _staff.statName = "Staff";
            _staff.itemPrice = 2;

            _mace.statBoost = 17;
            _mace.statName = "Mace";
            _mace.itemPrice = 5;

            _hammer.statBoost = 9;
            _hammer.statName = "Hammer";
            _hammer.itemPrice = 1;

        }


        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            //SelectRoles(player);
            return player;
        }


        public void Run()
        {

        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void End()
        {

        }
    }
}
