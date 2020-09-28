﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class PvP
    {


        struct Items
        {
            public int statBoost;
            public string statName;
            public int itemPrice;
        }


        bool _gameOver = false;

        //players
        private Player _player1;
        private Player _player2;


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
            _longSword.itemPrice = 2;

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
            _mace.itemPrice = 2;

            _hammer.statBoost = 9;
            _hammer.statName = "Hammer";
            _hammer.itemPrice = 2;

        }


        public void Continue()
        {
            Console.WriteLine("\nPress [Enter] to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        //Inputs

        //two options
        public void GetInput(out char input, string option1, string option2, string quiry)
        {
            Console.WriteLine(quiry);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            input = ' ';

            //loops till valid is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");

                }
            }

            Continue();
        }

        //three options
        public void GetInput(out char input, string option1, string option2, string option3, string quiry)
        {
            Console.WriteLine(quiry);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            input = ' ';

            //loops till valid is received
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");

                }
            }

            Continue();
        }

        //four options
        public void GetInput(out char input, string option1, string option2, string option3, string option4, string quiry)
        {
            Console.WriteLine(quiry);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            input = ' ';

            //loops till valid is received
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");

                }
            }

            Continue();
        }

        //six options
        public void GetInput(out char input, string quiry)
        {
            Console.WriteLine(quiry);
            input = ' ';

            //loops till valid is received
            while (input != '1' && input != '2' && input != '3' && input != '4' && input != '5' && input != '6')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3' && input != '4' && input != '5' && input != '6')
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");

                }
            }

            Continue();
        }



        public void Save()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            _player1.Save(writer);
            _player2.Save(writer);
            writer.Close();
        }

        public virtual void Load()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            //save the characters stats
            _player2.Load(reader);
            _player2.Load(reader);
        }


        public void SelectWeapon(Player player)
        {
            Console.Clear();
            Console.WriteLine(_longSword.statName);
            Console.WriteLine(_dagger.statName);
            Console.WriteLine(_ax.statName);
            Console.WriteLine(_staff.statName);
            Console.WriteLine(_mace.statName);
            Console.WriteLine(_hammer.statName);


            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "Welcome! CHOOSE YOUR WEAPON!");

            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
            }
            if (input == '2')
            {
                player.AddItemToInventory(_dagger, 1);
            }
            if (input == '3')
            {
                player.AddItemToInventory(_ax, 2);
            }
        
            if (input == '4')
            {
                player.AddItemToInventory(_staff, 0);
            }
            if (input == '5')
            {
                player.AddItemToInventory(_mace, 1);
            }
            if (input == '6')
            { 
                player.AddItemToInventory(_hammer, 2);
            }
        }

        public void StartBattle()
        {
            Console.WriteLine("FIGHT TILL ONE DIES!!!!!!");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine((i + 1) + ". ");
            }
            Console.WriteLine("Go!");

            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //prints player one and two's stat
                Console.WriteLine("Player one");
                _player1.PrintStats();
                Console.WriteLine("Player two");
                _player2.PrintStats();

                char input;

                //Player One
                GetInput(out input, "Attack", "Peace", "Open Invatory", "\nPlayer one! What do you wish to do?");

                if (input == '1')
                {
                    float totalDamage = _player2.Attack(_player1);
                    Console.WriteLine(_player1.GetName() + " did " + totalDamage + " to " + _player2.GetName());
                }
                if (input == '2')
                {
                    Console.WriteLine("\nPlayer one went with a peaceful option! Hopefully Player two feels the same!");

                }
                Continue();

                //Player Two
                GetInput(out input, "Attack", "Peace", "Open Inventory", "Player two! What do you wish to do?");

                if (input == '1')
                {
                    float totalDamage = _player1.Attack(_player2);
                    Console.WriteLine(_player2.GetName() + " did " + totalDamage + " to " + _player1.GetName());
                }
                if (input == '2')
                {
                    Console.WriteLine("\nPlayer two went with a peaceful option! Hopefully Player one feels the same!");

                }

                Continue();
            }
        }



        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            //SelectItems(player);
            SelectWeapon(player);
            return player;
        }

        public void Run()
        {
            Console.WriteLine("Hello Players!");
            Start();
            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        public void Start()
        {
            InitializeItems();
        }

        public void Update()
        {
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();
        }

        public void End()
        {
            Console.WriteLine("Battle Over!");
            Console.WriteLine("Press [Enter] to close game.");
            Console.ReadKey();
        }
    }
}
