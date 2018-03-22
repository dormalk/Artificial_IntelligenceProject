using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public interface ISearchable
    {
        State<T> getInitialState<T>();
        bool isGoal<T>(State<T> state);
        List<State<T>> getSuccessors<T>(State<T> s);
    }
}
