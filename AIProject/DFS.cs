using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class DFS : ISearcher
    {
        private ISearchable searchable = null;
        public Solution Search<T>(ISearchable _searchable)
        {
            Solution solution = new Solution();
            this.searchable = _searchable;
            State<T> next = searchable.getInitialState<T>();
            next = DfsRecursive<T>(next);

            while (next.cameFrom != null)
            {
                solution.Add(next.state.ToString());
                next = next.cameFrom;
            }

            return solution._Reverse();

        }

        private State<T> DfsRecursive<T>(State<T> state)
        {

            if (this.searchable.isGoal<T>(state))
                return state;
            List<State<T>> list = searchable.getSuccessors<T>(state);
            State<T> currState = null; 
            for (int i=0;i<list.Count;i++)
            {
                if(state.cameFrom == null)
                    currState = DfsRecursive<T>(list[i]);
                else if(state.cameFrom!=null&&!list[i].state.Equals(state.cameFrom.state))
                    currState = DfsRecursive<T>(list[i]);
                if (currState != null)
                    break;
            }

            return currState;
        }
    }
}
