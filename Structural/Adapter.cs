using System;

namespace Design_Patterns.Structural
{
    class Client
    {
        ITarget _target;

        public Client(ITarget target)
            => _target = target;

        public int GetAge()
            => _target.ConvertToInt();

        public void DoSomething()
            => _target.MethodA();
    }

    class Adapter : ITarget
    {
        Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
            => _adaptee = adaptee;

        public int ConvertToInt()
            => int.Parse(_adaptee.GetAge());


        public void MethodA()
            => _adaptee.MethodB();
    }

    interface ITarget
    {
        int ConvertToInt();
        void MethodA();
    }

    class Adaptee
    {
        public string GetAge()
            => "69";

        public void MethodB()
            => Console.WriteLine("Stuff happened");
    }
}
