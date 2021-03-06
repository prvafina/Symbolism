﻿using System.Collections.Generic;
using System.Linq;
using Symbolism.Has;

namespace Symbolism
{
  namespace DegreeGpe
  {
    public static class Extensions
    {
      public static int DegreeMonomialGpe(this MathObject u, List<MathObject> v)
      {
        if (v.All(u.FreeOf)) return 0;
        if (v.Contains(u)) return 1;
        if ((u as Power)?.exp is Integer && ((Integer)((Power)u).exp).val > 1)
          return ((Integer)((Power)u).exp).val;
        if (u is Product)
          return ((Product)u).elts.Select(elt => elt.DegreeMonomialGpe(v)).Sum();
        return 0;
      }
      public static int DegreeGpe(this MathObject u, List<MathObject> v)
      {
        if (u is Sum)
          return ((Sum)u).elts.Select(elt => elt.DegreeMonomialGpe(v)).Max();
        return u.DegreeMonomialGpe(v);
      }
    }
  }
}
