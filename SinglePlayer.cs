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

        //this just prints the Title of the game out in Cyan
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
        //really need to figure out how to implement the money system uuuuuugh


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

        //this saves the functions value
        public virtual void Saving()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            _player.Save(writer);
            writer.Close();
        }

        //this loads the functions value
        public virtual void Loading()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            string word = reader.ReadLine();
            //save the characters stats
            _player.Load(reader);
        }

        //this allows you to either create a new character or load one
        public void OpenMenu()
        {
            char input;
            GetInput(out input, "Create new character", "Load Character[Not Available]", "What do you wish to do?");
            if (input == '2')
            {
                Loading();
                return;
            }

            _player = CreateCharacter();
            Saving();
        }

        //this creates a new player
        public AdvancedPlayer CreateCharacter()
        {
            Console.Clear();
            //this is you choosing which role you want
            Console.WriteLine("1. Wizard");
            Console.WriteLine("2. Knight");
            Console.WriteLine("3. Hero");
            Console.WriteLine("4. Monk");
            Console.WriteLine("5. Ranger");
            Console.WriteLine("6. Bard");

            Console.WriteLine("Choose your role!");
            char input = Console.ReadKey().KeyChar;

            //float healthVal, float damageVal, string nameVal, int levelVal, int manaVal, int charismaVal, int karmaVal, int luckVal, int stealthVal, string roleVal
            switch (input)
            {
                case '1':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(80.0f, 25.0f, name, 0, 100, 2, 0, 1, 0, "Wizard", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }
                case '2':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(100.0f, 30.0f, name, 0, 50, 3, 0, 2, 0, "Knight", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }
                case '3':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(150.0f, 40.0f, name, 0, 80, 2, 0, 2, 1, "Hero", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }
                case '4':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(200.0f, 40.0f, name, 0, 0, 3, 0, 3, 0, "Monk", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }
                case '5':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(80.0f, 25.0f, name, 0, 50, 1, 0, 2, 5, "Ranger", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }
                case '6':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(100.0f, 30.0f, name, 0, 120, 8, 0, 4, 2, "Bard", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }

                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat is your name?");
                        string name = Console.ReadLine();
                        AdvancedPlayer _player = new AdvancedPlayer(100.0f, 30.0f, name, 0, 100, 2, 0, 2, 0, "Hero", 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        return _player;
                    }
            
            
            }


        }

        //this is creating an enemy demon king
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
                    Saving();
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

        //this is the story
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
                Console.WriteLine("You awoke in a bright marble room, standing in front of you a tall and goddess like dark elf and her eyes had galxies in them. There was a halo behing her making her even more goddess like, she gives you small smile and open her arms.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("'Welcome Hero " + _player.GetName() + "! You were summouned from your world to help the world of Topia that is raveged by demons. There is only one way to return home. That is to defeat the Demon King! Please understand that this is for the greater good! But no worries I will help aid you in this Advanture!'");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The room became brighter.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("It seems that it is time for you to go. I thank you for your service Hero " + _player.GetName() + ".'");

                Continue();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("- Quest Recieved: Defeat the Demon King! - ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("- D A Y  O N E -");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("A bright light blinded you after you were given the quest by the woman. When the light finally cleared you realized you were in the center of a crowd.");
                Console.WriteLine("You look around and notice that the town was a mix of races: Elves, Humans, Drawfs, and more. The crowd then departs and an Ederly Dragon Born walks inbetween the parted group.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Are you a Hero? Did Goddess Cecilia send you?");

                Console.ForegroundColor = ConsoleColor.White;

                char input;
                GetInput(out input,"Answer him honestly about what you saw and what she said.", "A Goddess? Sorry I don't know who you are talking about.", "Your response:");

                if (input == '1')
                {

                    for(int i = 0; i < 2; i++)
                    {
                        _player.CharismaUp();
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        _player.KarmaUp();
                    }
                    Console.WriteLine("Everyone around began cheering for finally the Hero sent by their Goddess Cecilia.");
                    Console.WriteLine("The Elder grabbed your arm happily 'Since you were sent by our goddess we must treat you well!' He handed you a bag of what you presume to be a bag of coins.");
                    Console.WriteLine("'Quickly we must show you to your room! And no worries its on us!' You followed the Elder to the tavern, and was greeted by the woman at the front desk.");
                    Console.WriteLine("'Welcome to the Kraken Tavern, for one room its 2 silver coins!' the elderly walked up to her, 'This young hero sent by the Goddess! No need to make them pay the fee!'");
                    Console.WriteLine("The woman gased and quickly grabbed a set of keys behind her, 'Room 11, Hero....?' you realized that you haven't given them your name, '" + _player.GetName() + "' she nodded to herself 'Here you go Hero " + _player.GetName() + ", your room keys!'");
                    Console.WriteLine("You found your room, entered it then layed onto the bed, waiting for the next day to come.");

                    Continue();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Congradulations! You gained 2 charisma and 3 karma!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (input == '2')
                {
                    //karma = karma - 1;
                    Console.WriteLine("Everyone around you grew gloomy as you told them 'I do not know who you are talking about.' Even the Elders calm demeanor was shattered in his dissapointment.");
                    Console.WriteLine("You were quite uncomfortable with their gazes of awe but the gloom in the air is even much more unnerving. 'Do you have a place to stay?' you asked the Elder.");
                    Console.WriteLine("'We do.' He answered shortly. He pointed towards a tavern that seemed to have a second level. Perhaps the main floor was similar to a pub and the other floor may be a hotel. You bowed to the Elder and with a polite tone 'Thank you.'");
                    Console.WriteLine("You walked in. You were greeted by a woman at the front desk 'Welcome to the Kraken Tavern, for one room its 2 copper coins!' You walked up to her and handed her the 2 silver coins. 'Here you go! Room 11! May I know your name so I can put it in the Log Book!'");
                    //coppercoins = coppercoins - 2;
                    Console.WriteLine("'" + _player.GetName() + "'");
                    Console.WriteLine("You found your room, entered it and then layed onto the bed, wating for the next day to come.");

                    Continue();

                    //Console.WriteLine("It's a sad day, you were taken to a world you do not know of, you had already used 2 silver coins and lost 2 karma points. Hopefully tommorrow would be better than it was today.");

                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine("- E N D  O F  D A Y  O N E -");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                //TEMPERARY!!!
                //ERASE SOON \/\/\/
                _gameOver = true;
                return;
            }

            
        }




    }
}
