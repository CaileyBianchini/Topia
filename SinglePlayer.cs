using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace HelloWorld
{
    class SinglePlayer
    {

        //allows player time before clearing screen
        public void Continue()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress [Enter] to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }


        public void Title()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Topia");

            Console.ForegroundColor = ConsoleColor.White;
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

        private AdvancedPlayer _player;
        private Player _DemonKing;

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
            _player.Save(writer);
            writer.Close();
        }

        public virtual void Load()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            //save the characters stats
            _player.Load(reader);
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

            _player = CreateCharacter();
            Save();
        }

        public AdvancedPlayer CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("1. Wizard");
            Console.WriteLine("2. Knight");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");

            Console.WriteLine("Choose your role!");
            char input = Console.ReadKey().KeyChar;

            //float healthVal, float damageVal, string nameVal, int levelVal, int manaVal, int charismaVal, int karmaVal, int luckVal, int stealthVal, string roleVal
            switch (input)
            {
                case '1':
                    {
                        Console.WriteLine("What is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(80.0f, 25.0f, name, 0, 100, 2, 0, 1, 0, "Wizard", 3);
                        return _player;
                    }
                case '2':
                    {
                        Console.WriteLine("What is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(100.0f, 30.0f, name, 0, 100, 2, 0, 2, 0, "Knight", 3);
                        return _player;
                    }

                default:
                    {
                        Console.WriteLine("What is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(100.0f, 30.0f, name, 0, 100, 2, 0, 2, 0, "Hero", 3);
                        return _player;
                    }
            
            
            }


        }


        public Player CreateEnemy()
        {
            Player player = new Player("Demon King", 300, 30, 100, 3);
            return player;
        }


        public void Run()
        {
            Title();
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
            _DemonKing = CreateEnemy();
            Adventure();
        }

        public void End()
        {
            Console.Clear();

            if (_player.GetNotAlive())
            {
                Console.WriteLine("G A M E   O V E R.");
                Console.WriteLine("You Died.");
            }
            else if (_DemonKing.GetNotAlive())
            {
                Console.WriteLine("Congradulations! You defeated the Demon King! ");
                //blah blah blah more dialogue
            }
            else
            {
                Console.WriteLine("Version 0.0.2");
                Console.WriteLine("You reached the end of what we have. This is an early version of the game.");
                char input;
                GetInput(out input, "Yes", "No", "Do you wish to save?");
                if (input == '1')
                {
                    Console.WriteLine("Saving . . .");
                    Console.ReadKey();
                    Save();
                    Console.WriteLine("Have a great day!");
                }
                else
                {
                    Console.WriteLine("Oh well");
                }
            }

            Console.WriteLine("Press [Enter] to End Game.");
            Console.ReadLine();
            Console.Clear();
        }


        public void Adventure()
        {
            while (_player.GetIsAlive())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("~~~~~~~~~~");
                Console.WriteLine("The world is a violent one. Many creatures live in this world: Humans, Elves, Dwarfs, Spirits, and much more. This world use to be quite a peaceful one until the fowl Demons showed up. At first it was random killings, lone merchants traveling in between towns, farmers that where out on their feild.");
                Console.WriteLine("Everything changed when the Demon King appeared. They're random attacks became organized, the damage done tripled, and the causalties worsened. We were losing hope. That was until a prophecy was shared, 'Summon a Hero and the world shall be saved.' and thus a sliver of hope was born!"); //aparently i misspelled slimmer? How do I spell it then?
                Console.WriteLine("~~~~~~~~~~");
                Console.ForegroundColor = ConsoleColor.White;
                
            }

            
        }




    }
}
