using System;
using System.Collections;
using System.Text;

namespace Mediator.Examples
{
    // Mainapp test application
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            ConcreteColleague3 c3 = new ConcreteColleague3(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;
            m.Colleague3 = c3;

            c3.Send("Hello", c2);
            m.Send("How are you?", c1, c2);
            m.Send("Fine, thanks", c2, c1);
             
            // Wait for user
            Console.Read();
        }
    }
    // "Mediator"
    abstract class Mediator
    {
        public abstract void Send(string message,
          Colleague colleague_s, Colleague colleague_r);
    }
    // "ConcreteMediator"
    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;
        private ConcreteColleague3 colleague3;
        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }

        public ConcreteColleague3 Colleague3
        {
            set { colleague3 = value; }
        }
        public override void Send(string message,
          Colleague colleague_s, Colleague colleague_r)
        {
            if (colleague_r == colleague1)
            {
                colleague1.Notify(message, colleague_s);
            }
            else if (colleague_r == colleague2)
            {
                colleague2.Notify(message, colleague_s);
            }
            else
            {
                colleague3.Notify(message, colleague_s);
            }
        }
    }

    // "Colleague"
    abstract class Colleague
    {
        protected Mediator mediator;
        protected string name;
        // Constructor
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public string Name { get { return name; } }
    }

    // "ConcreteColleague1"
    class ConcreteColleague1 : Colleague
    {
        // Constructor
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {
            name = "Colleague1";
        }
        public void Send(string message, Colleague coleague_r)
        {
            mediator.Send(message, this, coleague_r);
        }

        public void Notify(string message, Colleague coleague_s)
        {
            Console.WriteLine("Colleague1 gets message: "
              + message + $"  From:  {coleague_s.Name}");
        }
    }
    // "ConcreteColleague2"
    class ConcreteColleague2 : Colleague
    {
        // Constructor
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {
            name = "Colleague2";
        }

        public void Send(string message, Colleague coleague_r)
        {
            mediator.Send(message, this, coleague_r);
        }

        public void Notify(string message, Colleague coleague_s)
        {
            Console.WriteLine("Colleague2 gets message: "
              + message + $"  From:  {coleague_s.Name}");
        }
    }
    class ConcreteColleague3 : Colleague
    {
        // Constructor
        public ConcreteColleague3(Mediator mediator)
            : base(mediator)
        {
            name = "Colleague3";
        }

        public void Send(string message, Colleague coleague_r)
        {
            mediator.Send(message, this, coleague_r);
        }

        public void Notify(string message, Colleague coleague_s)
        {
            Console.WriteLine("Colleague3 gets message: "
              + message + $"  From:  {coleague_s.Name}");
        }
    }
}
