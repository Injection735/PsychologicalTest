using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	class KettelTestQuestion
	{
		public string text;
		public KettelTest.Type type;
		public List<Answer> answers;

		public KettelTestQuestion(string text, KettelTest.Type type, List<Answer> answers)
		{
			this.text = text;	
			this.type = type;
			this.answers = answers;
		}
	}

	struct Answer
	{
		public string name;
		public int points;

		public Answer(string name, int points)
		{
			this.name = name;
			this.points = points;
		}
	}
}
