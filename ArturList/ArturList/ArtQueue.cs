using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArturList
{
    public interface IQueue<T>
    {
        void Enqueue(T qElement);
        T Dequeue();
        int Count { get; }
    }

    public class ArtQueue<T> : IQueue<T>
    {
        private int _count;
        private ArtNode<T> _current;
        private ArtNode<T> _last;
        public int Count { get { return _count; } }

        public T Dequeue()
        {
            if (_count == 1) { return _last.Value; }
            else
            {
                for (int i = 1; i < _count; i++)
                {
                    _current = _last.Prev;
                    
                }
                return _current.Value;
            }

        }

        public void Enqueue(T qElement)
        {
            _count++;
            ArtNode < T > addNode = new ArtNode<T>();
            if (_last == null)
            {
                _last = addNode;
                _last.Value = qElement;

                _current = addNode;
                _current.Value = qElement;
            }
            else
            {
                addNode.Value = qElement;
                _last.Prev = addNode;
                _last = addNode;
                    
            }
            
            
        }
    }
}
