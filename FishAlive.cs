using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class FishAlive
    {
        public static int solution_FishAlive2(int[] A, int[] B)
        {
            Stack<int> upstreamfishidx = new Stack<int>();
            Stack<int> downstreamfishidx = new Stack<int>();

            int alivecnt = A.Length;

            //populate the stack
            int j = A.Length - 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (B[i] != 0)
                    downstreamfishidx.Push(i);

                if (B[j] == 0)
                    upstreamfishidx.Push(j--);
            }

            //loop will only be alive when either the downstream or upstream fish runs out. SO we don't have to check N*N-1
            while (downstreamfishidx.Any() && upstreamfishidx.Any())
            {
                int downfish = downstreamfishidx.Peek();
                int upfish = upstreamfishidx.Peek();

                //only when upfish meet downfish
                if (upfish > downfish)
                {
                    //upfish dies, downfish lives
                    if (A[downfish] > A[upfish])
                    {
                        upstreamfishidx.Pop();
                        alivecnt--;
                    }
                    //upfish lives, downfish dies
                    else
                    {
                        downstreamfishidx.Pop();
                        alivecnt--;
                    }
                }
                else
                {
                    upstreamfishidx.Pop();
                }

            }
            return alivecnt;
        }

    }
}
