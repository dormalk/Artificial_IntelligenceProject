using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class State<T>
    {
        public T state;
        public double cost;
        public State<T> cameFrom;

        public State(T _state, double _cost, State<T> _cameFrom)
        {
            this.state = _state;
            this.cost = _cost;
            this.cameFrom = _cameFrom;
        }
    }

    
}
