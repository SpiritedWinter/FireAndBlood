using System;

namespace FireAndBlood.SOLIDS
{
    // do not force a class to implement interfaces it does not use
    // In Westeros, not every house participates in every type of warfare.
    // The Interface Segregation Principle (ISP) states that no client should be forced to depend on methods it does not use.
    // Do not force a man to swear oaths he does not intend to keep
    public interface IWarrier
    {
        void Fight();
        void FlyDragon();
        void SailShip();
        void LeadInfantry();
        void CommandNavy();
    }

    // the above example is a bad example of ISP violation as you can see that all the job is done by one warrior the base class must 
    // implement all the methods even if it does not use them
    // for excample a infantry soldier does not need to fly a dragon or sail a ship
    public class Warrior : IWarrier
    {
        public void Fight()
        {
            Console.WriteLine("Warrior fighting!");
        }

        public void FlyDragon()
        {
            throw new NotImplementedException();
        }

        public void SailShip()
        {
            throw new NotImplementedException();
        }

        public void LeadInfantry()
        {
            Console.WriteLine("Leading Infantry!");
        }

        public void CommandNavy()
        {
            throw new NotImplementedException();
        }
    }




    /// below is a better example of ISP adherence
    /// each class implements only the methods it uses
    public interface IFighter
    {
        void Fight();
    }
    public interface ICavalry
    {
        void RideHorse();
    }
    public interface IDragonRider
    {
        void FlyDragon();
    }

    public interface INavalCommander
    {
        void CommandNavy();
    }
    public class InfantrySoldier : IFighter
    {
        public void Fight()
        {
            Console.WriteLine("Infantry Soldier fighting!");
        }
    }

    public class CavalrySoldier : IFighter, ICavalry
    {
        public void Fight()
        {
            Console.WriteLine("Cavalry Soldier fighting!");
        }

        public void RideHorse()
        {
            Console.WriteLine("Cavalry Soldier riding horse!");
        }
    }

    public class DragonRider : IFighter, IDragonRider
    {
        public void Fight()
        {
            Console.WriteLine("Dragon Rider fighting!");
        }

        public void FlyDragon()
        {
            Console.WriteLine("Dracarys!");
        }
    }
}