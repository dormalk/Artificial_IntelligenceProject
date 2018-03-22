using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class AStar : ISearcher
    {
        public Solution Search<T>(ISearchable searchable)
        {
            Solution solution = new Solution();
            List<State<T>> opened = new List<State<T>>();
            HashSet<T> closed = new HashSet<T>();
            State<T> next = searchable.getInitialState<T>();
            double totalCost = 0;

            while (!searchable.isGoal<T>(next))
            {

                searchable.getSuccessors<T>(next).ForEach(s =>
                {
                    if (!closed.Contains(s.state))
                        opened.Add(s);
                });
                closed.Add(next.state);

                double temp = totalCost + opened[0].cost;
                int index = 0;
                next = opened[0];

                for(int i = 1; i < opened.Count; i++)
                {
                    if (temp > totalCost + opened[i].cost)
                    {
                        temp = totalCost + opened[i].cost;
                        next = opened[i];
                    }
                }
                opened.Remove(next);
                totalCost = temp;
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
