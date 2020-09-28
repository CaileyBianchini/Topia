using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class SinglePlayer
    {


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

        public void Save()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            _player1.Save(writer);
            writer.Close();
        }

        public virtual void Load()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            //save the characters stats
            _player1.Load(reader);
        }

        public void OpenMenu()
        {
            char input;
            GetInput(out input, "Create new character", "Load Character", "What do you wish to do?");
            if (input == '2')
            {
                Load();
                return;
            }

            _player1 = CreateCharacter();
            Save();
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
            Console.WriteLine("Hello Player!");
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
            OpenMenu();
            Adventure();
        }

        public void End()
        {

        }


        public void Adventure()
        {
            while (_player1.GetIsAlive())
            {






            }

            Console.Clear();




        }




    }
}
