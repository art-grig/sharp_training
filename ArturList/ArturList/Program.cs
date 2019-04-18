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
			public ArtNode Prev { get;  set; }
			public int Value { get; set; }
		}

		public class ArtList : IArtList
		{
            
            private ArtNode _last ;
            private ArtNode _first;
            
			public void Add(int value)
			{
                ArtNode addNode = new ArtNode();
                addNode.Value = value;
                
                if (_last == null )
                {
                    _last = addNode;
                    _first = addNode;
                }
                else
                {
                   
                   _last.Next = addNode;
                   addNode.Prev = _last;
                   _last = addNode;
                }
                
			}
            
			public int Get(int hamar)
			{
                ArtNode currentElement;
                currentElement = _first;
                
                for (int i = 1; i < hamar; i++)
                {
                    currentElement = currentElement.Next;
                }
                return currentElement.Value;
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
            
			if ( ksan == 20 && erku == 2 && tas == 10)
				Console.WriteLine("Cragire chisht ashxatec");
			else
				Console.WriteLine("Cragire normal chashxatec");
        }
    }
}
