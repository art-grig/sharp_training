using System;

namespace ArturList
{
    class Program
    {
		public interface IArtList
		{
			void Add(int value);
			int Get(int hamar);
		}

		public class ArtNode
		{
			public ArtNode Next { get; set; }
			public ArtNode Prev { get; set; }
			public int Value { get; set; }
		}

		public class ArtList : IArtList
		{
			public void Add(int value)
			{
				throw new NotImplementedException();
			}

			public int Get(int hamar)
			{
				throw new NotImplementedException();
			}
		}

		static void Main(string[] args)
        {
			ArtList list = new ArtList();
			list.Add(1);
			list.Add(2);
			list.Add(10);
			list.Add(20);

			var ksan = list.Get(4);
			var erku = list.Get(2);
			var tas = list.Get(3);

			if (ksan == 20 && erku == 2 && tas == 10)
				Console.WriteLine("Cragire chisht ashxatec");
			else
				Console.WriteLine("Cragire normal chashxatec");
        }
    }
}
