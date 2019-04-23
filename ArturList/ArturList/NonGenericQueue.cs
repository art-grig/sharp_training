using System;
using System.Collections.Generic;
using System.Text;

namespace ArturList
{
    public class Hivand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gangat { get; set; }

        public Hivand(string anun,string azg,string gangat)
        {
            Name = anun;
            Surname = azg;
            Gangat = gangat;
            Teghekutyun = new HertiMasinTeghekutyun();
        }
        public HertiMasinTeghekutyun Teghekutyun { get; set; }
    }

    public class HertiMasinTeghekutyun
    {
        public Hivand Hajord { get; set; }
        public Hivand Naxord { get; set; }
    }

    public class BjishkiHert
    {
        private Hivand _verchin;
        private Hivand _arachinHertum;
        private Hivand _arachinMtav;
        private int _qanak;

        public int Qanak { get { return _qanak; } }

        public Hivand EndunelHivandin()
        {
            _qanak--;
            if (_arachinMtav == null)
            {
                _arachinMtav = _arachinHertum;
                return _arachinMtav;
            }
            else
            {
                _arachinMtav.Teghekutyun.Hajord = _arachinHertum.Teghekutyun.Hajord;
                return _arachinMtav;
            }
        }

        public void KangnacnelHivandinHertiMech(string anun, string azganun, string gangat)
        {
            _qanak++;
            Hivand hivand = new Hivand(anun, azganun, gangat);

            if (_verchin == null)
            {
                _verchin = hivand;
                _arachinHertum = hivand;
            }
            else
            {
                _verchin.Teghekutyun.Hajord = hivand;
                hivand.Teghekutyun.Naxord = _verchin;
                _verchin = hivand;
            }
        }
    }
}
