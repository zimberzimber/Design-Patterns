using System;

namespace Design_Patterns.Behevioural
{
    class StateMachine
    {
        public IState State;

        public StateMachine(IState state)
            => State = state;

        public void Handle()
            => State.Handle(this);
    }

    interface IState
    {
        void Handle(StateMachine sender);
    }

    class StateA : IState
    {
        public void Handle(StateMachine sender)
            => Console.WriteLine("Handled state A");
    }

    class StateB : IState
    {
        public void Handle(StateMachine sender)
            => Console.WriteLine("Handled state B");
    }
}
