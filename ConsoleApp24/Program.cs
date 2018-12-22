using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    interface IPoll
    {
        void Add(IPoll poll);
        void Remove(IPoll poll);
        int GetPoll();
    }
    class Poll : IPoll
    {        
        public void Add(IPoll poll)
        {
            throw new NotImplementedException();
        }
        public int GetPoll()
        {
            return 1;
        }
        public void Remove(IPoll poll)
        {
            throw new NotImplementedException();
        }
    }

    class Agency : IPoll
    {
        List<IPoll> polls = new List<IPoll>();
        public Agency(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public void Add(IPoll poll)
        {
            polls.Add(poll);
        }

        public int GetPoll()
        {
            int sum = 0;
            for (int i = 0; i < polls.Count; i++)
            {
                sum += polls[i].GetPoll();
            }
            return sum;
        }

        public void Remove(IPoll poll)
        {
            polls.Remove(poll);
        }
    }
    class Region : IPoll
    {
        public string Name { get; set; }
        public void Add(IPoll poll)
        {
            polls.Add(poll);
        }

        public int GetPoll()
        {
            int sum = 0;
            for (int i = 0; i < polls.Count; i++)
            {
                sum += polls[i].GetPoll();
            }
            return sum;
        }
        public void Remove(IPoll poll)
        {
            polls.Remove(poll);
        }
        List<IPoll> polls = new List<IPoll>()
;

        public Region(string name)
        {
            Name = name;
        }
    }
    class City : IPoll
    {
        public string Name { get; set; }

        public void Add(IPoll poll)
        {
            polls.Add(poll);
        }

        public int GetPoll()
        {
            int sum = 0;
            for (int i = 0; i < polls.Count; i++)
            {
                sum += polls[i].GetPoll();
            }
            return sum;
        }

        public void Remove(IPoll poll)
        {
            polls.Remove(poll);
        }
        List<IPoll> polls = new List<IPoll>();
        public City(string name)
        {
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Poll poll = new Poll();
            Agency agency = new Agency("Agency");
            for (int i = 0; i < 10; i++)
            {
                agency.Add(poll);
            }
            Agency agency2 = new Agency("Agency2");
            for (int i = 0; i < 10; i++)
            {
                agency2.Add(poll);
            }
            Region region = new Region("Wall st");
            region.Add(agency);region.Add(agency2);
            Region region2 = new Region("Wall st2");
            region.Add(agency); region.Add(agency2);
            City city = new City("London");
            city.Add(region); city.Add(region2);
            Console.WriteLine($"All polls are {city.GetPoll()} in {city.Name}");
        }
    }
}
