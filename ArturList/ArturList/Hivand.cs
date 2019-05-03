﻿using System;
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

            for (int i = 0; i < _qanak-1; i++)
            {
                if (entacikHivand.Dram >= hamematvoxHivand.Dram)
                {
                    hamematvoxHivand = hamematvoxHivand.hertakanutyun.Hajord;
                }
                else
                {
                    //hamematvox hivandin berum enk araj
                    if (hamematvoxHivand.hertakanutyun.Hajord == null)
                    {
                        hamematvoxHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = null;

                        hamematvoxHivand.hertakanutyun.Hajord = entacikHivand;
                        entacikHivand.hertakanutyun.Naxord = hamematvoxHivand;
                        hamematvoxHivand.hertakanutyun.Naxord = _arachin;
                        _arachin.hertakanutyun.Hajord = hamematvoxHivand;
                        break;
                    }
                    hamematvoxHivand.hertakanutyun.Naxord.hertakanutyun.Hajord = hamematvoxHivand.hertakanutyun.Hajord;
                    hamematvoxHivand.hertakanutyun.Hajord.hertakanutyun.Naxord = hamematvoxHivand.hertakanutyun.Naxord;
                    entacikHivand.hertakanutyun.Naxord = hamematvoxHivand;
                    hamematvoxHivand.hertakanutyun.Hajord = entacikHivand;
                    
                    hamematvoxHivand.hertakanutyun.Naxord = null;
                    _arachin = hamematvoxHivand;

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