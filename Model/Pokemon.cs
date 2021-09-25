using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_scraper
{
    class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Type { get; set; } = new List<string>();
        public int TotalPoints { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }

        public override string ToString()
        {
            string type = this.Type.Count == 1 ? this.Type[0] : this.Type[0] + " " + this.Type[1];
            return $"#{this.Id} Name: {this.Name}{Environment.NewLine} Type(s): {type}{Environment.NewLine} " +
                $"Hp: {this.Hp} Attack: {this.Attack} Defense: {this.Defense} Sp.Atk: {this.SpAttack} Sp.Def: {this.SpDef} Speed: {this.Speed}{Environment.NewLine} Total: {this.TotalPoints}";
        }
    }
}
