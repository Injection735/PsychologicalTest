using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	struct Pair
	{
		int a;
		int b;

		public Pair(int a, int b)
		{
			this.a = a;
			this.b = b;
		}

		public Pair(int a)
		{
			this.a = a;
			b = a;
		}

		public bool InRange(int points) => (a == b && points == a) || (a != b && points >= a && points <= b);
	}
}
