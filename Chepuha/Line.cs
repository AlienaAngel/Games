using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chepuha
{
    class Line
    {
        private string _who;
        private string _withWhom;
        private string _whatDoing;
        private string _why;
        private string _where;
        private string _when;
        private string _whoCame;
        private string _whatSaid;
        private string _end;

        public Line(string who, string withWhom, string whatDoing, string why, string where, string when, string whoCame, string whatSaid, string end)
        {
            _who = who;
            _withWhom = withWhom;
            _whatDoing = whatDoing;
            _why = why;
            _where = where;
            _when = when;
            _whoCame = whoCame;
            _whatSaid = whatSaid;
            _end = end;
        }

        public string Who
        {
            get { return _who; }
        }

        public string WithWhom
        {
            get { return _withWhom; }
        }

        public string WhatDoing
        {
            get { return _whatDoing; }
        }

        public string Why
        {
            get { return _why; }
        }

        public string Where
        {
            get { return _where; }
        }

        public string When
        {
            get { return _when; }
        }

        public string WhoCame
        {
            get { return _whoCame; }
        }

        public string WhatSaid
        {
            get { return _whatSaid; }
        }

        public string End
        {
            get { return _end; }
        }
    }
}
