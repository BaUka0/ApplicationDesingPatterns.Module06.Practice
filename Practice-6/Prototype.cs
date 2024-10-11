using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    public class Character
    {
        public int Health { get; set; }
        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Intelegence { get; set; }

        public Weapon weapon { get; set; }
        public Armor armor { get; set; }
        public List<Skill> skills { get; set; }

        public Character() { }
        public Character(int health, int strenght, int agility, int intelegence, Weapon weapon, Armor armor, List<Skill> skills)
        {
            Health = health;
            Strenght = strenght;
            Agility = agility;
            Intelegence = intelegence;
            this.weapon = weapon;
            this.armor = armor;
            this.skills = skills;
        }

        public Character Clone()
        {
            return new Character(
                this.Health, this.Strenght, this.Agility, this.Intelegence, this.weapon.Clone(), this.armor.Clone(), this.skills.Select(skill => skill.Clone()).ToList()
                );
        }
    }

    public class Weapon
    { 
        public string Type { get; set; }
        public int Damage { get; set; }
        public Weapon() { }
        public Weapon(string type, int damage)
        {
            Type = type;
            Damage = damage;
        }
        public Weapon Clone()
        {
            return new Weapon(this.Type, this.Damage);
        }
    }
    public class Armor
    {
        public string Type { get; set; }
        public int Defence { get; set; }
        public Armor() { }
        public Armor(string type, int defence)
        {
            Type = type;
            Defence = defence;
        }
        public Armor Clone()
        {
            return new Armor(this.Type, this.Defence);
        }
    }
    public class Skill
    {
        public string Type { get; set; }
        public int Power { get; set; }
        public Skill() { }
        public Skill(string type, int power)
        {
            Type = type;
            Power = power;
        }
        public Skill Clone()
        {
            return new Skill(this.Type, this.Power);
        }
    }

    internal class Prototype
    {
        //Prototype pattern
    }
}
