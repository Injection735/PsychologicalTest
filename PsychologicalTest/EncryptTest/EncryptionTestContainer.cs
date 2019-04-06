using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest.EncryptTest
{
	class EncryptionTestContainer : IGraphicElement
	{
		private List<EncryptionTestElement> elements;
		private int maxWidth;
		private int currentX;
		private int currentY;
		private int count;
		private int startX = 0;

		private TestTimer timer;

		public EncryptionTestContainer(Action onNext, int maxWidth, int count, int x, int y)
		{
			elements = new List<EncryptionTestElement>();
			
			this.maxWidth = maxWidth;
			this.count = count;

			currentX = x;
			currentY = y;

			startX = x;

			timer = new TestTimer(onNext, 5, 0, y - 20);
		}

		public void AddElement()
		{
			for (int i = 0; i < count; i++)
			{
				EncryptionTestElement element = new EncryptionTestElement(currentX, currentY);
				currentX += EncryptionTestElement.WIDTH;
				if (currentX >= maxWidth + startX)
				{
					currentX = startX;
					currentY += EncryptionTestElement.HEIGHT + 20;
				}
				element.AddElement();
				elements.Add(element);
			}
			timer.AddElement();

			timer.x = (maxWidth + startX - timer.width) / 2;
		}

		public void Hide()
		{
			foreach(EncryptionTestElement element in elements)
				element.Hide();

			timer.Hide();
		}

		public void AcceptAnswers()
		{
			var legend = EncryptionTest.GetLegend();

			foreach (EncryptionTestElement element in elements)
				EncryptionTest.answersCount += legend[element.GetInfo()] == element.GetValue() ? 1 : 0;
		}
	}
}
