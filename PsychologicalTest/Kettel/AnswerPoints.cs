using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	struct AnswerPoints
	{
		public int answer1;
		public int answer2;
		public int answer3;

		public AnswerPoints(int answer1 = 0, int answer2 = 0, int answer3 = 0)
		{
			this.answer1 = answer1;
			this.answer2 = answer2;
			this.answer3 = answer3;
		}

		public void SetEmpty()
		{
			answer1 = 0;
			answer2 = 0;
			answer3 = 0;
		}

		public bool isEmpty => answer1 == 0 && answer2 == 0 && answer3 == 0;
	}
}
