using System;
using System.Linq;

namespace Pokemon_scraper
{
    class Program
    {
        static void Main(string[] args)
        {

            Scraper scraper = new Scraper();
            var pokemons = scraper.GetAllPokemon();

            Console.WriteLine("Dragons:");
            var dragons = pokemons.Where(p => p.Type.Contains("Dragon"));
            dragons.ToList().ForEach(p => Console.WriteLine(p.ToString()));

            divide();

            Console.WriteLine($"Ennyi sárkány típusú Pokémon van jelenleg: {dragons.Count()}");

            divide();

            var strongestDragon = dragons.OrderByDescending(p => p.TotalPoints).First();
            Console.WriteLine($"Legerősebb sárkány jelenleg: {strongestDragon.Name} ({strongestDragon.TotalPoints})");

            divide();

            Console.WriteLine($"600-nál erősebb pokémonok:{Environment.NewLine}");
            var strongerPokemons = pokemons.Where(p => p.TotalPoints > 600);
            strongerPokemons.ToList().ForEach(p => Console.WriteLine(p.Name));

            divide();

            Console.WriteLine($"ugyanez abc sorrendben:{Environment.NewLine}");
            strongerPokemons.OrderBy(p => p.Name).ToList().ForEach(p => Console.WriteLine(p.Name));

            divide();

            Console.WriteLine($"összes Pokémon erejének átlaga: {pokemons.Average(p => p.TotalPoints)}");
        }

        private static void divide()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
        }
    }
}
