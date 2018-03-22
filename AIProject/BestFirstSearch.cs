using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class BestFirstSearch : ISearcher
    {
        public Solution Search<T>(ISearchable searchable)
        {
            Solution solution = new Solution();
            Queue<State<T>> opened = new Queue<State<T>>();
            HashSet<T> closed = new HashSet<T>();
            State<T> next = searchable.getInitialState<T>();
            while (!searchable.isGoal<T>(next))
            {

                searchable.getSuccessors<T>(next).ForEach(s =>
                {
                    if (!closed.Contains(s.state))
                        opened.Enqueue(s);
                });
                closed.Add(next.state);
                opened = queueSort<T>(opened);
                next = opened.Dequeue();
            }

            while (next.cameFrom != null)
            {
                solution.Add(next.state.ToString());
                next = next.cameFrom;
            }

            return solution._Reverse();
        }

        private Queue<State<T>> queueSort<T>(Queue<State<T>> queue)
        {
            List<State<T>> list = new List<State<T>>();
            while (queue.Count != 0)
                list.Add(queue.Dequeue());

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j].cost > list[j + 1].cost)
                    {
                        State<T> temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            list.ForEach(val =>
            {
                queue.Enqueue(val);
            });

            return queue;
        }
    }
}
