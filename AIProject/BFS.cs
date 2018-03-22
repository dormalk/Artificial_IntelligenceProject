using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class BFS : ISearcher
    {

        public Solution Search<T>(ISearchable searchable)
        {
            Solution solution = new Solution();
            Queue<State<T>> opened = new Queue<State<T>>();
            HashSet<T> closed = new HashSet<T>();
            State<T> next = searchable.getInitialState<T>();
            while (!searchable.isGoal<T>(next))
            {

                searchable.getSuccessors<T>(next).ForEach(s => {
                    if(!closed.Contains(s.state))
                        opened.Enqueue(s);
                });
                closed.Add(next.state);
                next = opened.Dequeue();
            }

            while (next.cameFrom != null)
            {
                solution.Add(next.state.ToString());
                next = next.cameFrom;
            }

            return solution._Reverse();
        }

        
    }
}
