using System;

namespace GnomeSort
{
    public class Card
    {
        private City _cityIn;
        private City _cityOut;

        public City CityIn
        {
            get => _cityIn;
            set
            {
                if((int)value > Enum.GetNames(typeof(City)).Length)
                    return;

                _cityIn = value;
            }
        }

        public City CityOut
        {
            get => _cityOut;
            set
            {
                if((int)value > Enum.GetNames(typeof(City)).Length)
                    return;
                
                _cityOut = value;
            }
        }
    }
}
