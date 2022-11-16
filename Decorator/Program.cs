using Microsoft.SqlServer.Server;
using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            Tree c = new Tree();
            TreeDecoratorA d1 = new TreeDecoratorA();
            TreeDecoratorB d2 = new TreeDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class Tree : Component
    {
        private decimal height;
        private Random random = new Random();
        public Tree()
        {
            height = random.Next(10);
        }
        public override void Operation()
        {
            Console.WriteLine($"tree grows, height is {height} m");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class TreeDecoratorA : Decorator
    {
        private string addedDecorations;

        public override void Operation()
        {
            base.Operation();
            addedDecorations = "blue balls, yellow stars, red stripes";
            Console.WriteLine($"Decorations added: {addedDecorations}");
        }
    }

    // "ConcreteDecoratorB" 
    class TreeDecoratorB : Decorator
    {
        private string behaviorDescription;
        private Random random = new Random();
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine($"Behavior: {behaviorDescription}\n");
        }
        void AddedBehavior()
        {
            var trigger = random.Next(2);
            if (trigger == 1) { behaviorDescription = "lights on"; }
            else { behaviorDescription = "lights off"; }
        }
    }
}
