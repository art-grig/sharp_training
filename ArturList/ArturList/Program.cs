using System;
using System.Collections.Generic;
namespace ArturList
{
        #region legacy
    public interface IArtList<T>
    {
        void Add(T value);
        T Get(int hamar);
    }

    public class ArtNode<T>
    {
        public ArtNode<T> Next { get; set; }
        public ArtNode<T> Prev { get; set; }
        public T Value { get; set; }
    }

    public class ArtList<T> : IArtList<T>
    {
        private ArtNode<T> _last;
        private ArtNode<T> _first;

        public void Add(T value)
        {
            ArtNode<T> addNode = new ArtNode<T>();
            addNode.Value = value;

            if (_last == null)
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
        public T Get(int hamar)
        {
            ArtNode<T> currentElement;
            currentElement = _first;

            for ( int i = 1; i < hamar; i++)
            {
                currentElement = currentElement.Next;
            }
            return currentElement.Value;
        }
    }
    public class ArtList { }
    class Program
    {
        private static void StugelListe()
        {
            ArtList<string> strList = new ArtList<string>();
            strList.Add("a4aa");
            strList.Add("a4aa");
            strList.Add("aa5a");
            strList.Add("aa5");

            strList.Get(4);
            ArtList<int> list = new ArtList<int>();
            ArtList l = new ArtList();
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
        private static void StugelQueue()
        {
            IQueue<int> queue = new ArtQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(6);
            queue.Enqueue(10);

            queue.Dequeue();
            int ekrordElment = queue.Dequeue();
            queue.Dequeue();

            int esiminch = queue.Dequeue();

            if (ekrordElment == 1 && queue.Count == 1)
                Console.WriteLine("Queuen chisht ashxatec");
            else
                Console.WriteLine("Queuen sxal ashxatec");
        }

        static void StugelHivandanociHerte()
        {
            BjishkiHert hert = new BjishkiHert();

            hert.KangnacnelHivandinHertiMech("Suro", "Gonzales", "Xelar");
            hert.KangnacnelHivandinHertiMech("Karen", "xhazaryan", "poshkek");
            hert.KangnacnelHivandinHertiMech("Aram", "xhazaryan", "poshkek");

            Hivand arajinEndunvacHivand = hert.EndunelHivandin();
            Hivand erkrordEndunvacHivand = hert.EndunelHivandin();
            Hivand errordEndunvacHivand = hert.EndunelHivandin();
            
            if (arajinEndunvacHivand.Name == "Suro" && hert.Qanak == 0)
                Console.WriteLine("Cragire chisht ashxatec!");
            else
                Console.WriteLine("Cragire sxal ashxatec!");
        }

        #endregion

        #region new

        public class Hanguyc<T>
        {
            public Hanguyc<T> Hajord { get; set; }
            public Hanguyc<T> Naxord { get; set; }
            public T Arjek { get; set; }
        }

        public interface ICucak<T>
        {
            void Avelacnel(T arjek);
            T Veradarcnel(int hamar);
        }
        public class Cucak<T> : ICucak<string>
        {
            protected Hanguyc<string>  _arachin;
            protected Hanguyc<string>  _verchin;
            
            public virtual void Avelacnel(string arjek)
            {
                Hanguyc<string> hang = new Hanguyc<string>();

                if (_verchin == null)
                {
                    _verchin = hang;
                    _verchin.Arjek = arjek;

                    _arachin = hang;
                    _arachin.Arjek = arjek;
                }
                else
                {
                    hang.Arjek = arjek;

                    _verchin.Hajord = hang;
                    hang.Naxord = _verchin;
                    _verchin = hang;
                }
            }

            public string Veradarcnel(int hamar)
            {
                Hanguyc<string> veradarcvec = _arachin;

                for (int i = 1; i < hamar; i++)
                {
                    veradarcvec = veradarcvec.Hajord;
                }
                return veradarcvec.Arjek;
            }
        }

        public interface IHert<T>
        {
            void Avelacnel(T arjek);
            T HerticHanel();
        }

        public class Hert<T> : Cucak<T>, IHert<string>
        {
            public override void Avelacnel(string arjek)
            {
                base.Avelacnel(arjek);
            }

            public string HerticHanel()
            {
                Hanguyc<string> entacik = _arachin;

                _arachin = _arachin.Hajord;
                return entacik.Arjek;
            }
        }

        #endregion

        public static void HertiTest()
        {
            Hert<string> imHert = new Hert<string>();
            imHert.Avelacnel("test1");
            imHert.Avelacnel("test2");
            imHert.Avelacnel("test3");
            imHert.Avelacnel("test4");
            imHert.Avelacnel("test5");

            string arachin = imHert.HerticHanel();
            string erord = imHert.Veradarcnel(2);
            string ekrord = imHert.HerticHanel();
            imHert.HerticHanel();
            string hingErord = imHert.Veradarcnel(2);

            if (arachin == "test1" && erord == "test3" && ekrord == "test2" && hingErord == "test5")
                Console.WriteLine("Cragire chisht ashxatec");
            else
                Console.WriteLine("Cragire sxal ashxatec");
        }

        static void Main(string[] args)
        {
            HertiTest();
        }
    }
}
