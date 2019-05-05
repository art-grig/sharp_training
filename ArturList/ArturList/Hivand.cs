using System;
using System.Collections.Generic;
using System.Text;

namespace ArturList
{
    public interface IHert
    {
        void HertKangnel(int arjek);
        HivandMard HerticHelnel();

    }

    public class Shark
    {
        public HivandMard Hajord { get; set; }
        public HivandMard Naxord { get; set; }

        public int Arjek {get; set;}
    }
    public class HivandMard
    {
        public string Anun { get; set; }
        public string  Azganun { get; set; }
        public string Gangat { get; set; }
        public int Dram { get; set; }
        public Shark hertakanutyun { get; set; }

        public HivandMard()
        {
            hertakanutyun = new Shark();     
        }
    }

    public class BjishkiMot : IHert
    {
        private HivandMard _verchin;
        private HivandMard _arachin;
        private int _qanak;

        public HivandMard HerticHelnel()
        {
            
            while (StugelArajineSaxiHet() != true)
            {
                
            }
            HivandMard mtav = _arachin;
            _arachin = _arachin.hertakanutyun.Hajord;
            _qanak--;
            return mtav;
        }

        public void HertKangnel(int arjek)
        {
            _qanak++;

            HivandMard hivand = new HivandMard();

            if (_verchin == null)
            {
                hivand.Dram = arjek;

                _verchin = hivand;
                _arachin = hivand;
            }
            else
            {
                hivand.Dram = arjek;
                _verchin.hertakanutyun.Hajord = hivand;
                hivand.hertakanutyun.Naxord = _verchin;
                _verchin = hivand;
            }
        }

        private bool StugelArajineSaxiHet()
        {
            HivandMard entacikHivand = _arachin;
            HivandMard hamematvoxHivand = _arachin.hertakanutyun.Hajord;
            _arachin.hertakanutyun.Naxord = null;

            for (int i = 0; i < _qanak-1; i++)
            {
                if (entacikHivand.Dram >= hamematvoxHivand.Dram)
                {
                    if (hamematvoxHivand.hertakanutyun.Hajord == null)
                    {
                        continue;
                    }
                    hamematvoxHivand = hamematvoxHivand.hertakanutyun.Hajord;
                }
                else
                {
                    if (entacikHivand.hertakanutyun.Naxord == null)
                    {

                        hamematvoxHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = hamematvoxHivand.hertakanutyun.Hajord;
                        hamematvoxHivand.hertakanutyun.Hajord.hertakanutyun.Naxord = hamematvoxHivand.hertakanutyun.Naxord;
                        entacikHivand.hertakanutyun.Naxord = hamematvoxHivand;
                        hamematvoxHivand.hertakanutyun.Hajord = entacikHivand;


                        _arachin = hamematvoxHivand;
                        

                    }
                    else if(hamematvoxHivand.hertakanutyun.Hajord != null)
                    {
                        hamematvoxHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = hamematvoxHivand.hertakanutyun.Hajord;
                        hamematvoxHivand.hertakanutyun.Hajord.hertakanutyun.Naxord = hamematvoxHivand.hertakanutyun.Naxord;
                        entacikHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = hamematvoxHivand;
                        hamematvoxHivand.hertakanutyun.Naxord = entacikHivand.hertakanutyun.Naxord; 
                        
                        hamematvoxHivand.hertakanutyun.Hajord = entacikHivand;
                        entacikHivand.hertakanutyun.Naxord = hamematvoxHivand;

                    }

                    //hamematvox hivandin berum enk araj
                    if (hamematvoxHivand.hertakanutyun.Hajord == null)
                    {
                        hamematvoxHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = null;
                        entacikHivand.hertakanutyun.Hajord = hamematvoxHivand.hertakanutyun.Naxord;
                        hamematvoxHivand.hertakanutyun.Naxord.hertakanutyun.Naxord = entacikHivand;

                        entacikHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = hamematvoxHivand;
                        hamematvoxHivand.hertakanutyun.Naxord = entacikHivand.hertakanutyun.Naxord;

                        entacikHivand.hertakanutyun.Naxord = hamematvoxHivand;
                        hamematvoxHivand.hertakanutyun.Hajord = entacikHivand;

                        continue;
                    }
                    
                   
                    hamematvoxHivand = hamematvoxHivand.hertakanutyun.Hajord.hertakanutyun.Hajord.hertakanutyun.Hajord;
                }
                
            }
            
            if (entacikHivand.Dram == _arachin.Dram)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
