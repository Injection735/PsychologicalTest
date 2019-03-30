using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest.EncryptTest
{
	class EncryptionLegend : IGraphicElement
	{
		private List<EncryptionLegendElement> elements;
		int currentX;
		int currentY;
		int startX;
		private int maxWidth;
		private int count;

		public EncryptionLegend(int maxWidth, int count, int x, int y)
		{
			elements = new List<EncryptionLegendElement>();
			currentX = x;
			currentY = y;

			startX = x;
			
			this.maxWidth = maxWidth;
			this.count = count;

			foreach (KeyValuePair<int, char> pair in EncryptionTest.GetLegend())
			{
				EncryptionLegendElement element = new EncryptionLegendElement(pair.Key.ToString(), pair.Value.ToString(), currentX, currentY);

				elements.Add(element);
				
				currentX += EncryptionTestElement.WIDTH;

				if (currentX > maxWidth)
				{
					currentX = startX;
					currentY += EncryptionTestElement.HEIGHT + 20;
				}
			}
		}

		public void AddElement()
		{
			foreach (EncryptionLegendElement element in elements)
				element.AddElement();
		}

		public void Hide()
		{
			foreach (EncryptionLegendElement element in elements)
				element.Hide();
		}
	}
}
