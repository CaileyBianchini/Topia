using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Character
    {
        protected float _health;
        protected float _damage;
        protected float _specialdamage;
        protected string _name;
        protected Items[] _inventory;


        public Character()
        {
            _inventory = new Items[3];
            _health = 100;
            _name = "Player";
            _damage = 10;
        }
        public Character(float healthVal, float damageVal, string nameVal, int inventorySize)
        {
            _inventory = new Items[inventorySize];
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
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
        }


        public virtual bool Load(StreamReader reader)
        {
            //creates variable to the store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            //checks to see if loading was successful
            if(float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            //if successful, set update the member variables and return true.
            _name = name;
            _damage = damage;
            _health = health;
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

        

        public void PrintStats()
        {
            Console.WriteLine("\nName: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }


        public void ChangingRace()
        {

        }
    }
}
