using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest.MissTest
{
	class MissingDetailsTest
	{
		private static List<string> urls = null;

		public static List<string> GetUrls()
		{
			if (urls == null)
				urls = new List<string>(){
					"http://psylab.info/images/c/cc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_1.png",
					"http://psylab.info/images/8/82/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_2.png",
					"http://psylab.info/images/7/77/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_3.png",
					"http://psylab.info/images/9/97/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_4.png",
					"http://psylab.info/images/a/a0/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_5.png",
					"http://psylab.info/images/a/ac/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_6.png",
					"http://psylab.info/images/4/4c/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_7.png",
					"http://psylab.info/images/5/5d/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_8.png",
					"http://psylab.info/images/1/10/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_9.png",
					"http://psylab.info/images/a/ae/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_10.png",
					"http://psylab.info/images/3/33/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_11.png",
					"http://psylab.info/images/7/7d/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_12.png",
					"http://psylab.info/images/0/00/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_13.png",
					"http://psylab.info/images/6/60/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_14.png",
					"http://psylab.info/images/5/5a/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_15.png",
					"http://psylab.info/images/d/dc/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_16.png",
					"http://psylab.info/images/7/72/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_17.png",
					"http://psylab.info/images/d/d8/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_18.png",
					"http://psylab.info/images/5/55/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_19.png",
					"http://psylab.info/images/1/1e/WAIS_-_%D1%81%D1%83%D0%B1%D1%82%D0%B5%D1%81%D1%82_8_%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5_20.png"
				};

			return urls;
		}
	}
}
