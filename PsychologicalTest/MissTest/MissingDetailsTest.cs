using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest.MissTest
{
	class MissingDetailsTest
	{
		public static int rightAnswersCount = 0;

		private static List<MissingDetailsElementInfo> urls = null;

		private static int currentIterator = 0;

		public static List<MissingDetailsElementInfo> GetInfo()
		{
			if (urls == null)
				urls = new List<MissingDetailsElementInfo>(){
					new MissingDetailsElementInfo(new Point(231, 206),	new Size(30, 30),	"http://psylab.info/images/c/cc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_1.png"),
					new MissingDetailsElementInfo(new Point(60, 263),	new Size(50, 90),	"http://psylab.info/images/8/82/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_2.png"),
					new MissingDetailsElementInfo(new Point(242, 436),	new Size(50, 50),	"http://psylab.info/images/7/77/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_3.png"),
					new MissingDetailsElementInfo(new Point(180, 240),	new Size(160, 70),	"http://psylab.info/images/9/97/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_4.png"),
					new MissingDetailsElementInfo(new Point(100, 190),	new Size(270, 40),	"http://psylab.info/images/a/ac/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_6.png"),
					new MissingDetailsElementInfo(new Point(335, 270),	new Size(30, 40),	"http://psylab.info/images/4/4c/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_7.png"),
					new MissingDetailsElementInfo(new Point(150, 150),	new Size(30, 30),	"http://psylab.info/images/5/5d/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_8.png"),
					new MissingDetailsElementInfo(new Point(340, 280),	new Size(30, 30),	"http://psylab.info/images/1/10/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_9.png"),
					new MissingDetailsElementInfo(new Point(70, 260),	new Size(40, 90),	"http://psylab.info/images/a/ae/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_10.png"),
					new MissingDetailsElementInfo(new Point(145, 270),	new Size(30, 30),	"http://psylab.info/images/3/33/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_11.png"),
					new MissingDetailsElementInfo(new Point(50, 300),	new Size(100, 120), "http://psylab.info/images/7/7d/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_12.png"),
					new MissingDetailsElementInfo(new Point(470, 220),	new Size(50, 105),	"http://psylab.info/images/0/00/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_13.png"),
					new MissingDetailsElementInfo(new Point(220, 270),	new Size(110, 130), "http://psylab.info/images/6/60/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_14.png"),
					new MissingDetailsElementInfo(new Point(60, 70),	new Size(170, 120), "http://psylab.info/images/5/5a/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_15.png"),
					new MissingDetailsElementInfo(new Point(220, 180),	new Size(90, 80),	"http://psylab.info/images/d/dc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_16.png"),
					new MissingDetailsElementInfo(new Point(310, 310),	new Size(40, 40),	"http://psylab.info/images/7/72/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_17.png"),
					new MissingDetailsElementInfo(new Point(45, 310),	new Size(35, 50),	"http://psylab.info/images/d/d8/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_18.png"),
					new MissingDetailsElementInfo(new Point(290, 300),	new Size(50, 70),	"http://psylab.info/images/5/55/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_19.png"),
					new MissingDetailsElementInfo(new Point(130, 150),	new Size(70, 90),	"http://psylab.info/images/1/1e/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_20.png")
				};

			return urls;
		}

		public static MissingDetailsElementInfo GetNextInfo()
		{
			currentIterator++;
			
			if (currentIterator - 1 < GetInfo().Count)
				return GetInfo()[currentIterator - 1];
			
			return null;
		}

		public static int GetAnswer() => rightAnswersCount;
	}

	class MissingDetailsElementInfo
	{
		public Point point;
		public string url;
		public Size size;

		public MissingDetailsElementInfo(Point point, Size size, string url)
		{
			this.point = point;
			this.url = url;
			this.size = size;
		}
	}
}
