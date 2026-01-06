using System;


namespace FireAndBlood.SOLID
{
    //Object of subtypes must be replaceable with objects of the base type without altering the correctness of the program.
    // In War
    // you say: "Bring me a stark  soldier"
    // you expect any soldier from house stark to fulfill your request
    //you dont want it to break if 
    // a karstark soldier shows up
    // a umber soldier shows up
    // if a bolton soldier shows up you expect it to break as they are not starks
    public interface FightForNorth
    {
        public bool IsLoyalToStark { get; }
        public void Fight() ;

    }


    public class StarkSoldier : FightForNorth
    {
        public bool IsLoyalToStark { get; } = true;
        public void Fight()
        {
            Console.WriteLine("Stark Soldier fighting for the North!");
        }
    }

    public class KarstarkSoldier : FightForNorth
    {
        public bool IsLoyalToStark { get; } = true;
        public void Fight()
        {
            Console.WriteLine("Karstark Soldier fighting for the North!");
        }
    }
    public class BoltonSoldier : FightForNorth
    {
        public bool IsLoyalToStark { get; } = false;
        public void Fight()
        {
            throw new NotImplementedException("Bolton soldiers do not fight for the North!");
        }
    }


    public class Army
    {
        public IEnumerable<FightForNorth> Soldiers { get; set; }
        public Army(IEnumerable<FightForNorth> soldiers)
        {
            Soldiers = soldiers;
        }

        public void Battle()
        {
            foreach (var soldier in Soldiers)
            {
                soldier.Fight();
            }

            // here the above code will fail if bolton soldier is added to the 
            // army so we have to modify the code accordingly 
        }
    }

    // below is the correct implementation of LSP

    public class FightForNorthCorrect
    {
        private readonly IEnumerable<FightForNorth> _soldiers;
        public FightForNorthCorrect(IEnumerable<FightForNorth> soldiers)
        {
            _soldiers = soldiers;
        }
        public void Battle()
        {
            foreach (var soldier in _soldiers)
            {
                if ((soldier.IsLoyalToStark))
                {
                    soldier.Fight();
                }
                else
                {
                    Console.WriteLine("This soldier is not loyal to House Stark and cannot fight for the North.");
                }
            }
        }
    }
}