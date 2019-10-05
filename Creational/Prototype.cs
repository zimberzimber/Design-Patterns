namespace Design_Patterns.Creational
{
    interface IPrototype<T>
    {
        T Clone();
    }

    class ClassA : IPrototype<ClassA>
    {
        public int PropertyA;
        public ClassA Clone()
            => new ClassA { PropertyA = PropertyA };
    }

    class ClassB : IPrototype<ClassB>
    {
        public int PropertyB;
        public ClassB Clone()
            => new ClassB { PropertyB = PropertyB };
    }
}
