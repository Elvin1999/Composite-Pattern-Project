﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    interface IPoll
    {
        void Add(IPoll poll);
        bool Remove(IPoll poll);
        int GetPoll();
    }
    class Agency : IPoll
    {
        public string Name { get; set; }
        public int Mypool { get; set; }
        public Agency(string name, int mypool)
        {
            Name = name;
            Mypool = mypool;
        }

        public int GetPoll()
        {

            return Mypool;
        }

        public void Add(IPoll poll)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPoll poll)
        {
            throw new NotImplementedException();
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
        public bool Remove(IPoll poll)
        {
            return polls.Remove(poll);
        }
        List<IPoll> polls = new List<IPoll>();

        public Region(string name)
        {
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Agency agency = new Agency("Agency1", 20);
            Agency agency2 = new Agency("Agency1", 25);
            Region region = new Region("Wall st");
            Region region2 = new Region("Wall st2");
            Region city = new Region("London");
            
            try
            {
            
                region.Add(agency); region.Add(agency2);
                city.Add(region);
                region2.Add(agency); region2.Add(agency2);
                city.Add(region2);
                Console.WriteLine($"All polls are {city.GetPoll()} in {city.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
