using System;


namespace Virus
{
    public class Covid19
    {
        public double _lvlmortality;
        public double _lvlspread;

        public Covid19()
        {
            _lvlmortality = 0.02;
            _lvlspread = 0.10;
        }

        public double LvlMortality
        {
            get { return _lvlmortality; }
            set { _lvlmortality = value; }
        }

        public double LvlSpread
        {
            get { return _lvlspread; }
            set { _lvlspread = value; }
        }
    }

    public class Ebola
    {
        public double _lvlmortality;
        public double _lvlspread;

        public Ebola()
        {
            _lvlmortality = 0.02;
            _lvlspread = 0.10;
        }

        public double LvlMortality
        {
            get { return _lvlmortality; }
            set { _lvlmortality = value; }
        }

        public double LvlSpread
        {
            get { return _lvlspread; }
            set { _lvlspread = value; }
        }
    }

        public class Dengue
    {
        public double _lvlmortality;
        public double _lvlspread;

        public Dengue()
        {
            _lvlmortality = 0.02;
            _lvlspread = 0.10;
        }

        public double LvlMortality
        {
            get { return _lvlmortality; }
            set { _lvlmortality = value; }
        }

        public double LvlSpread
        {
            get { return _lvlspread; }
            set { _lvlspread = value; }
        }
    }
}