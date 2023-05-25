using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcTheCable
{
    internal class Core
    {
        private string selectedCable;

        public string SelectedCable
        {
            get { return selectedCable; }
            set { selectedCable = value; }
        }

        private double previousMax;


        private double _t;

        private int minT = 999;
        private int maxT = 8001;

        public double T // τ
        {
            get { return _t; }
            set { _t = value; }
        }

        private double _tnb;

        public double TNB
        {
            get { return _tnb; }
            set
            {
                if (value > minT & value < maxT)
                    _tnb = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }


        private double _nB;

        private int minNB = 9;
        private int maxNB = 2501;
        public double NB
        {
            get { return _nB; }
            set
            {
                if (value > minNB & value < maxNB)
                    _nB = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int minK = 999;
        private int maxK = 10000001;

        private int _ac120;

        public int AC120
        {
            get { return _ac120; }
            set
            {
                if (value > minK & value < maxK)
                    _ac120 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _ac150;

        public int AC150
        {
            get { return _ac150; }
            set
            {
                if (value > minK & value < maxK)
                    _ac150 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _ac240;

        public int AC240
        {
            get { return _ac240; }
            set
            {
                if (value > minK & value < maxK)
                    _ac240 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _ac300;

        public int AC300
        {
            get { return _ac300; }
            set
            {
                if (value > minK & value < maxK)
                    _ac300 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _ac400;

        public int AC400
        {
            get { return _ac400; }
            set
            {
                if (value > minK & value < maxK)
                    _ac400 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _ac500;

        public int AC500
        {
            get { return _ac500; }
            set
            {
                if (value > minK & value < maxK)
                    _ac500 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _ac600;

        public int AC600
        {
            get { return _ac600; }
            set
            {
                if (value > minK & value < maxK)
                    _ac600 = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public Dictionary<double, double> GetFirstLineForUh110()
        {
            var values = new List<double>();
            var keyValues = new Dictionary<double, double>();
            values.Add(Math.Sqrt(((_ac150 - _ac120) * (1 + 9.91 * 0.008) * (10 * 10 * 10)) / (3 * (int)_t * 2 * (0.286 - 0.204))));
            keyValues.Add(_t, values.Last());
            previousMax = values.Last();
            if (_nB <= values.First())
            {
                SelectedCable = "AC 120";
            }
            for (double i = 1000; i <= 8000; i += 100)
            {
                values.Add(Math.Sqrt(((_ac150 - _ac120) * (1 + 9.91 * 0.008) * (10 * 10 * 10)) / (3 * i * 2 * (0.286 - 0.204))));
                if (!keyValues.ContainsKey(i))
                    keyValues.Add(i, values.Last());
            }

            var ordered = keyValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }


        public Dictionary<double, double> GetSecondLineForUh110()
        {
            var values = new List<double>();
            var keyValues = new Dictionary<double, double>();
            values.Add(Math.Sqrt(((_ac240 - _ac150) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * _t * 2 * (0.204 - 0.124))));
            keyValues.Add(_t, values.Last());
            if (_nB <= values.First() && _nB >= previousMax)
            {
                SelectedCable = "AC 150";
            }
            else if (_nB >= values.First())
            {
                SelectedCable = "AC 240";
            }
            for (double i = 1000; i <= 8000; i += 100)
            {
                values.Add(Math.Sqrt(((_ac240 - _ac150) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * (i) * 2 * (0.204 - 0.124))));
                if (!keyValues.ContainsKey(i))
                    keyValues.Add(i, values.Last());
            }

            var ordered = keyValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }

        public Dictionary<double, double> GetFirstLineForUh220()
        {
            var values = new List<double>();
            var keyValues = new Dictionary<double, double>();
            values.Add(Math.Sqrt(((_ac300 - _ac240) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * _t * 2 * (0.124 - 0.097))));
            keyValues.Add(_t, values.Last());
            previousMax = values.Last();
            if (_nB <= values.First())
            {
                SelectedCable = "AC 240";
            }
            for (double i = 1000; i <= 8000; i += 100)
            {
                values.Add(Math.Sqrt(((_ac300 - _ac240) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * (i) * 2 * (0.124 - 0.097))));
                if (!keyValues.ContainsKey(i))
                    keyValues.Add(i, values.Last());
            }

            var ordered = keyValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }

        public Dictionary<double, double> GetSecondLineForUh220()
        {
            var values = new List<double>();
            var keyValues = new Dictionary<double, double>();
            values.Add(Math.Sqrt(((_ac400 - _ac300) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * _t * 2 * (0.097 - 0.077))));
            keyValues.Add(_t, values.Last());
            if (_nB <= values.First() && _nB >= previousMax)
            {
                SelectedCable = "AC 300";
            }
            previousMax = values.First();
            for (double i = 1000; i <= 8000; i += 100)
            {
                values.Add(Math.Sqrt(((_ac400 - _ac300) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * (i) * 2 * (0.097 - 0.077))));
                if (!keyValues.ContainsKey(i))
                    keyValues.Add(i, values.Last());
            }

            var ordered = keyValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }

        public Dictionary<double, double> GetThirdLineForUh220()
        {
            var values = new List<double>();
            var keyValues = new Dictionary<double, double>();
            values.Add(Math.Sqrt(((_ac500 - _ac400) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * _t * 2 * (0.077 - 0.061))));
            keyValues.Add(_t, values.Last());
            if (_nB <= values.First() && _nB >= previousMax)
            {
                SelectedCable = "AC 400";
            }
            previousMax = values.First();
            for (double i = 1000; i <= 8000; i += 100)
            {
                values.Add(Math.Sqrt(((_ac500 - _ac400) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * (i) * 2 * (0.077 - 0.061))));
                if (!keyValues.ContainsKey(i))
                    keyValues.Add(i, values.Last());
            }

            var ordered = keyValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }

        public Dictionary<double, double> GetFourthLineForUh220()
        {
            var values = new List<double>();
            var keyValues = new Dictionary<double, double>();
            values.Add(Math.Sqrt(((_ac600 - _ac500) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * _t * 2 * (0.061 - 0.047))));
            keyValues.Add(_t, values.Last());
            if (_nB <= values.First() && _nB >= previousMax)
            {
                SelectedCable = "AC 500";
            }
            else if (_nB >= values.First())
            {
                SelectedCable = "AC 600";
            }
            for (double i = 1000; i <= 8000; i += 100)
            {
                values.Add(Math.Sqrt(((_ac600 - _ac500) * (1 + 9.91 * 0.008) * 10 * 10 * 10) / (3 * (i) * 2 * (0.061 - 0.047))));
                if (!keyValues.ContainsKey(i))
                    keyValues.Add(i, values.Last());
            }

            var ordered = keyValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }

        public void GetT()
        {
            _t = ((0.124 + _tnb / 10000) * (0.124 + _tnb / 10000.0) * 8760);
        }

    }
}
