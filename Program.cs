/* Lab 6
* 
* Diana Guerrero
* Professor Aydin
* BCS 426 
* 4/4/21
* 
* Partner(s): Patrick Adams & Anthony Alvarez
* Resource(s): 
* 1. https://drive.google.com/drive/folders/1eGu6mGofqpIiQuuIknVh7L9icCLVpbKa
*/

using System;
using System.Collections;
using System.Linq;

namespace BCS426Lab6
{
    public abstract class Player
    {

        public string Name 
        { 
            get; 
            set; 
        }

        public double Salary 
        { 
            get; 
            set; 
        }

        public override string ToString() => $"{ Name } with salary of ${ Salary }";

        public abstract void displayStatistics();
    }



    public class BaseballPlayer : Player, IComparable
    {

        public int AtBats 
        { 
            get; 
            set; 
        }

        public int HomeRuns 
        { 
            get; 
            set; 
        }

        public int Hits 
        { 
            get; 
            set; 
        }

        public override void displayStatistics()

        {
            Console.WriteLine($" Name: { Name } \n Salary: { Salary } \n At Bats: { AtBats } \n Home Runs: {  HomeRuns } \n Hits: { Hits } \n");
        }

        int IComparable.CompareTo(object o)
        {
            BaseballPlayer bp = (BaseballPlayer)o;
            return String.Compare(this.Name, bp.Name);
        }
        private class sortNameHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                BaseballPlayer bp1 = (BaseballPlayer)a;
                BaseballPlayer bp2 = (BaseballPlayer)b;
                return String.Compare(bp1.Name, bp2.Name);
            }
        }
        private class sortSalaryHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                BaseballPlayer bp1 = (BaseballPlayer)a;
                BaseballPlayer bp2 = (BaseballPlayer)b;
                if (bp1.Salary > bp2.Salary)
                    return 1;
                if (bp1.Salary < bp2.Salary)
                    return -1;
                else
                    return 0;
            }
        }
        private class sortHitsHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                BaseballPlayer bp1 = (BaseballPlayer)a;
                BaseballPlayer bp2 = (BaseballPlayer)b;
                if (bp1.Hits > bp2.Hits)
                    return 1;
                if (bp1.Hits < bp2.Hits)
                    return -1;
                else
                    return 0;
            }
        }
        public static IComparer sortNames()
        {
            return (IComparer)new sortNameHelper();
        }
        public static IComparer sortHits()
        {
            return (IComparer)new sortHitsHelper();
        }
        public static IComparer sortSalarys()
        {
            return (IComparer)new sortSalaryHelper();
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            // Create a One Dimensional Array of Baseball Players w/ Size of 100
            BaseballPlayer[] baseballPlayers = new BaseballPlayer[100];

            // Add 3 Baseball Players To The Array

            baseballPlayers[0] = new BaseballPlayer()
            {
                Name = "Noah Syndergaard",
                Salary = 9700000,
                HomeRuns = 6,
                AtBats = 222,
                Hits = 34,
            };

            baseballPlayers[1] = new BaseballPlayer()
            {
                Name = "Steven Matz",
                Salary = 5200000,
                HomeRuns = 3,
                AtBats = 174,
                Hits = 30,
            };

            baseballPlayers[2] = new BaseballPlayer()
            {
                Name = "Jacob deGrom",
                Salary = 7000000,
                HomeRuns = 3,
                AtBats = 350,
                Hits = 66,
            };

            // Uses System.Linq to use .Where 
            baseballPlayers = baseballPlayers.Where(d => d != null).ToArray();


            // Show Menu to the User
            // 1. sort players based on salary and display
            // 2. sort players based on hits and display
            // 3. sort players based on name and display

            Console.WriteLine("1. Display & Sort Baseball Players Based on Salary: ");
            Console.WriteLine("2. Display & Sort Baseball Players Based on Hits: ");
            Console.WriteLine("3. Display & Sort Baseball Players Based on Name: ");

            // Ask the User What Option They Choose
            Console.WriteLine("Enter your choice: ");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            // Display Baseball Players List
            //foreach (BaseballPlayer bpl in baseballPlayers)
                //bpl.displayStatistics();

            //Display All the Info of the Baseball Players in that Specified Order
            // Menus & Sorting of Baseball Player Stats
            if (userChoice == 1)
            {
                Array.Sort(baseballPlayers, BaseballPlayer.sortSalarys());
                Console.WriteLine("Baseball Player Stats Sorted by Salary\n");
                foreach (BaseballPlayer bpl in baseballPlayers)
                    bpl.displayStatistics();
            }
            else if (userChoice == 2)
            {
                Array.Sort(baseballPlayers, BaseballPlayer.sortHits());
                Console.WriteLine("Baseball Player Stats Sorted by Hits\n");
                foreach (BaseballPlayer bpl in baseballPlayers)
                    bpl.displayStatistics();
            }
            else if (userChoice == 3)
            {
                Array.Sort(baseballPlayers, BaseballPlayer.sortNames());
                Console.WriteLine("Baseball Player Stats Sorted by Name\n");
                foreach (BaseballPlayer bpl in baseballPlayers)
                    bpl.displayStatistics();
            }
            //else { Console.WriteLine("\nEnter choice is wrong\n"); }
            Console.ReadLine();
        }
    }
}