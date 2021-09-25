using HtmlAgilityPack;
using System.Collections.Generic;

namespace Pokemon_scraper
{
    class Scraper
    {
        HtmlDocument doc;

        public Scraper()
        {
            HtmlWeb web = new HtmlWeb();

            this.doc = web.Load("https://pokemondb.net/pokedex/all");
        }

        public List<Pokemon> GetAllPokemon()
        {
            var htmlTable = doc.DocumentNode.SelectSingleNode("//tbody");
            var pokemonsTr = htmlTable.SelectNodes("tr");
            List<Pokemon> pokemonList = new List<Pokemon>();

            foreach (var tr in pokemonsTr)
            {
                Pokemon pokemon = new Pokemon();

                int counter = 0;
                foreach (var data in tr.SelectNodes("td"))
                {
                    switch (counter)
                    {
                        case 0:
                            var span = data.SelectSingleNode("span[2]");
                            //Console.WriteLine(span.InnerText);
                            pokemon.Id = int.Parse(span.InnerText);
                            break;
                        case 1:
                            var a = data.SelectSingleNode("a");
                            var small = data.SelectSingleNode("small");
                            var subname = (small == null) ? "" : $" ({small.InnerText})";
                            var fullName = a.InnerText + subname;
                            pokemon.Name = fullName;
                            break;
                        case 2:
                            var typeNodes = data.SelectNodes("a");
                            foreach (var typeNode in typeNodes)
                            {
                                pokemon.Type.Add(typeNode.InnerText);
                            }
                            break;
                        case 3:
                            pokemon.TotalPoints = int.Parse(data.InnerText);
                            break;
                        case 4:
                            pokemon.Hp = int.Parse(data.InnerText);
                            break;
                        case 5:
                            pokemon.Attack = int.Parse(data.InnerText);
                            break;
                        case 6:
                            pokemon.Defense = int.Parse(data.InnerText);
                            break;
                        case 7:
                            pokemon.SpAttack = int.Parse(data.InnerText);
                            break;
                        case 8:
                            pokemon.SpDef = int.Parse(data.InnerText);
                            break;
                        case 9:
                            pokemon.Speed = int.Parse(data.InnerText);
                            break;
                    }
                    ++counter;
                }

                pokemonList.Add(pokemon);
            }

            return pokemonList;
        }
    }
}
