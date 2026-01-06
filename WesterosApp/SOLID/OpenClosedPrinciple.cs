using System;
using System.Collections.Generic;


namespace FireAndBlood.SOLID
{
    //Sofware entities should be open for extension but closed for modification
    // In Westeros, houses can form alliances and adapt to new threats without changing their core identities.
    //Westeros Mental Model
    // New Houses rise
    // New war strategies emerge
    //But

    // we do not rewrite the kings Laws everytime, we need to write the class which should be entendible
    public class BattleStrategy
    {
        public void Attack(string house)
        {
            if (house == "Stark")
            {
                Console.WriteLine("Using the Northern Assault Strategy!");
            }
            else if (house == "Lannister")
            {
                Console.WriteLine("Using the Golden Maneuver!");
            }
            else
            {
                Console.WriteLine("Using the Default Battle Strategy.");
            }
        }
    }

    // what we see up top is a bad example of OCP violation,
    // as you can see that we have multiple  if else statement, if I were to add a new house this already tested funtion would be changed
    // which is not ideal and voilation of OCP
    // Below is a better example of OCP adherence


    public interface IBattleStrategy
    {
        void Attack();
    }

    public class StarkStrategy : IBattleStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Using the Northern Assault Strategy!");
        }
    }

    public class LannisterStrategy : IBattleStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Using the Golden Maneuver!");
        }
    }


    public class BattleContext
    {
        private readonly IBattleStrategy _strategy;

        public BattleContext(IBattleStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.Attack();
        }
    }

    // the above code doesnt care about the new houses that are added 
    // rather it only cares about the job or the intent
    // so if a new house is added we just need to create a new class implementing the interface
    // and passs on the object of that class to the BattleContext
    // this way the already tested code remains unchanged
}