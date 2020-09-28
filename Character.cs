using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        protected float _damage;
        protected float _specialdamage;
        private string _name;
        private int _level;
        private int _mana;
        private int _charisma;
        private float _karma;
        private int _luck;
        private float _stealth;
        private int _defence;

        public Character()
        {
            _health = 100;
            _name = "Player";
            _damage = 10;
            _level = 0;
        }
        public Character(float healthVal, float damageVal, string nameVal, int levelVal)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
            _level = levelVal;
        }
        public virtual float Attack(Character enemy)
        {
            float damageTaken = enemy.TakeDamage(_damage);
            return damageTaken;
        }
        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if (_health < 0)
                _health = 0;
            return damageVal;
        }

        public virtual void Save(StreamWriter writer)
        {
            //save the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_damage);
            writer.WriteLine(_health);
            writer.WriteLine(_level);
        }


        public virtual bool Load(StreamReader reader)
        {
            //creates variable to the store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            int level = 0;
            //checks to see if loading was successful
            if(float.TryParse(reader.ReadLine(), out damage) == false)
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
            //if successful, set update the member variables and return true.
            _name = name;
            _damage = damage;
            _health = health;
            _level = _level;
            return true;
        }

        public string GetName()
        {
            return _name;
        }

        //need to find out how to put role name

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public bool GetNotAlive()
        {
            return _health < 1;
        }

        public int LevelUp()
        {
            return _level + 1;
        }

        public void PrintStats()
        {
            Console.WriteLine("\nName: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }


        public void ChangingStats()
        {
            Console.WriteLine("What you class? Use lower case!");
            string input = Console.ReadLine();

            switch (input)
            {
                case "mage":
                    {
                        _health = _health - 50;
                        _mana = _mana + 30;
                        _damage = _damage - 10;
                        _specialdamage = _specialdamage + 30;
                        _stealth = _stealth + 1;
                        _defence = _defence - 2;
                        return;
                    }
            }
        }

        public void ChangingRace()
        {

        }
    }
}
