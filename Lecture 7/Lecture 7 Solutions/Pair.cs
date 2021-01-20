using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_7_Solutions
{
    public class Pair<T1, T2>
    {
        public readonly T1 Fst;
        public readonly T2 Snd;

        public Pair(T1 fst, T2 snd)
        {
            Fst = fst;
            Snd = snd;
        }

        public Pair<T2, T1> Swap()
        {
            return new Pair<T2, T1>(Snd, Fst);
        }

        public Pair<C, T2> SetFst<C>(C value)
        {
            return new Pair<C, T2>(value, Snd);
        }

        public Pair<T1, C> SetSnd<C>(C value)
        {
            return new Pair<T1, C>(Fst, value);
        }
    }
}
