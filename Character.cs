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
        protected string _name;


        public Character()
        {
            _health = 100;
            _name = "Player";
            _damage = 10;
        }
        public Character(float healthVal, float damageVal, string nameVal)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
        }

        //this will use TakeDamage against the enemy using players damage
        public virtual float Attack(Character enemy)
        {
            float damageTaken = enemy.TakeDamage(_damage);
            return damageTaken;
        }

        //this will take one character and use their damage against another
        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if (_health < 0)
                _health = 0;
            return damageVal;
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

        

        public virtual void Save(StreamWriter writer)
        {
            //save the characters stats
            writer.WriteLine(_name);
            writer.WriteLine(_damage);
            writer.WriteLine(_health);
            writer.Close();
        }

        public virtual bool Load(StreamReader reader)
        {
            //creates variable to the store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;

            //checks to see if loading was successful
            if (float.TryParse(reader.ReadLine(), out damage) == false)
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

        public virtual void PrintStats()
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
