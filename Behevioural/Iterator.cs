using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Behevioural
{

    interface IIterator<T>
    {
        T FirstItem();
        T CurrentItem();
        T NextItem();
        bool IsDone();
    }

    interface IAggregate<T>
    {
        IIterator<T> GetIterator();
    }

    class Iterator : IIterator<string>
    {
        public string CurrentItem() => throw new NotImplementedException();
        public string FirstItem() => throw new NotImplementedException();
        public bool IsDone() => throw new NotImplementedException();
        public string NextItem() => throw new NotImplementedException();
    }

    class Aggregate : IAggregate<string>
    {
        public IIterator<string> GetIterator() => throw new NotImplementedException();
    }
}
