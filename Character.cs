using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Raylib_cs;
using MathLibrary;

namespace HelloWorld
{
    class Character
    {
        protected float _health;
        protected float _damage;
        protected string _name;

        protected char _icon = ' ';
        protected Vector2 _velocity;
        protected Matrix3 _transform;
        protected ConsoleColor _color;
        protected Color _rayColor;
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_transform.m11, _transform.m12);
            }
            set
            {
                _transform.m11 = value.X;
                _transform.m12 = value.Y;
            }
        }


        public Vector2 Position
        {
            get { return new Vector2(_transform.m13, _transform.m23); }
            set
            {
                _transform.m13 = value.X;
                _transform.m23 = value.Y;
            }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set{_velocity = value;}
        }

        public Character(float y, float x, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _health = 100;
            _name = "Player";
            _damage = 10;

            _rayColor = Color.WHITE;
            _icon = icon;
            _transform = new Matrix3();
            Position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            Forward = new Vector2(1, 0);
        }
        public Character(float healthVal, float damageVal, string nameVal, float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;

            _transform = new Matrix3();
            _rayColor = rayColor;
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
