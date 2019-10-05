using System;
using System.Collections.Generic;

namespace Design_Patterns.Behevioural
{
    class Data
    {
        public string State { get; set; }
        public string OtherData { get; set; }

        public Memento TakeSnapshot()
            => new Memento(State);

        public void LoadSnapshot(Memento snapshot)
            => State = snapshot.State;
    }

    class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
            => State = state;
    }

    class History
    {
        Stack<Memento> _undoStack;
        Stack<Memento> _redoStack;
        public Memento CurrentSnapshot { get; private set; }

        public History()
        {
            _undoStack = new Stack<Memento>();
            _redoStack = new Stack<Memento>();
        }

        public void IndexState(Data data)
        {
            if (CurrentSnapshot != null)
                _undoStack.Push(CurrentSnapshot);

            if (_redoStack.Count > 0)
                _redoStack.Clear();

            CurrentSnapshot = data.TakeSnapshot();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0)
                return;

            _redoStack.Push(CurrentSnapshot);
            CurrentSnapshot = _undoStack.Pop();
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
                return;

            _undoStack.Push(CurrentSnapshot);
            CurrentSnapshot = _redoStack.Pop();
        }
    }

    class MementoExample
    {
        // An example of an undo/redo implementation using the above 'Memento' pattern
        public void StartExample()
        {
            Data d = new Data();
            History h = new History();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Data: {d.State}");
                Console.WriteLine("Waiting for input...");

                var key = Console.ReadKey();
                if (key.KeyChar == 'q')
                {
                    h.Undo();
                    d.State = h.CurrentSnapshot.State;
                }
                else if (key.KeyChar == 'e')
                {
                    h.Redo();
                    d.State = h.CurrentSnapshot.State;
                }
                else
                {
                    d.State = key.KeyChar.ToString();
                    h.IndexState(d);
                }
            }
        }
    }
}