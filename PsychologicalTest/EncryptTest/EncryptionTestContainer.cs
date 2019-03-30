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

		public EncryptionTestContainer(int maxWidth, int count, int x, int y)
		{
			elements = new List<EncryptionTestElement>();
			
			this.maxWidth = maxWidth;
			this.count = count;

			currentX = x;
			currentY = y;

			startX = x;
		}

		public void AddElement()
		{
			for (int i = 0; i < count; i++)
			{
				EncryptionTestElement element = new EncryptionTestElement(currentX, currentY);
				currentX += EncryptionTestElement.WIDTH;
				if (currentX > maxWidth)
				{
					currentX = startX;
					currentY += EncryptionTestElement.HEIGHT + 20;
				}
				element.AddElement();
			}
		}

		public void Hide()
		{
			foreach(EncryptionTestElement element in elements)
				element.Hide();
		}

		public void AcceptAnswers()
		{
			var legend = EncryptionTest.GetLegend();

			foreach (EncryptionTestElement element in elements)
				EncryptionTest.answers.Add(legend[element.GetInfo()] == element.GetValue());
		}
	}
}
