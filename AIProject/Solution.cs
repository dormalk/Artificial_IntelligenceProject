using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Solution : List<String>
    {
        public Solution _Reverse()
        {
            Solution sol = new Solution();
            this.ForEach(value =>
            {
                sol.Add(value);
            });
            return sol;
        }

        public override string ToString()
        {
            String str = "";
            for(int i= this.Count-1;i>=0 ;i--)
                str += this[i]+"-";
            str += "FINISH";            
            return str;
        }
    }
}
