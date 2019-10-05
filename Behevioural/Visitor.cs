using System;
using System.Collections.Generic;

namespace Design_Patterns.Behevioural
{
    // NOTE: Operator = Visitor
    // NOTE: Data = Element
    // Changed the names so its easier for me to understand when I was first studying it

    class Manager
    {
        public List<IData> Data { get; private set; }

        public void AddData(IData data)
            => Data.Add(data);

        public void PerformOperation(IOperator op)
        {
            foreach (var data in Data)
                data.AcceptOperator(op);
        }

        public void PerformOperations(IEnumerable<IOperator> ops)
        {
            foreach (var op in ops)
                foreach (var data in Data)
                    data.AcceptOperator(op);
        }
    }

    interface IData
    {
        void AcceptOperator(IOperator op);
    }

    class DataA : IData
    {
        public string DataForA;

        public void AcceptOperator(IOperator op)
            => op.Operate(this);
    }

    class DataB : IData
    {
        public string DataForB;

        public void AcceptOperator(IOperator op)
            => op.Operate(this);
    }


    interface IOperator
    {
        void Operate(DataA data);
        void Operate(DataB data);
    }

    class OperatorA : IOperator
    {
        public void Operate(DataA data)
            => Console.WriteLine($"OperatorA operated on DataA. Result: {data.DataForA}");

        public void Operate(DataB data)
            => Console.WriteLine($"OperatorA operated on DataB. Result: {data.DataForB}");
    }

    class OperatorB : IOperator
    {
        public void Operate(DataA data)
            => Console.WriteLine($"OperatorB operated on DataA. Result: {data.DataForA}");

        public void Operate(DataB data)
            => Console.WriteLine($"OperatorB operated on DataB. Result: {data.DataForB}");
    }
}
