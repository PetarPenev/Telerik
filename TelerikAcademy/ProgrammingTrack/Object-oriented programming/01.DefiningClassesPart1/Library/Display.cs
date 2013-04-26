using System;

namespace Library
{
    public class Display
    {
        // Fields

        private decimal? size;

        private int? numberColors;

        // Properties
        public decimal? Size
        {
            get { return size; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("The size of the display must be positive!");
                }
                if (value > 10)
                {
                    throw new ArgumentException("Size of the display suggests this is not a GSM but a tablet. Check for incorrect input.");
                }
                size = value; 
            }
        }

        public int? NumberColors
        {
            get { return numberColors; }
            set { 
                if (value<0)
                {
                    throw new ArgumentException("The number of colors of the display must be positive!");
                }
                if (value < 256)
                {
                    throw new ArgumentException("Stated number of colors suggests an outdated model. Plese check for incorrect input.");
                }
                numberColors = value;
            }
        }

        // Constructors

        public Display() 
        {
            this.Size = null;
            this.NumberColors = null;
        }

        public Display(decimal size) :this()
        {
            this.Size = size;
        }

        public Display(int numberColors) :this()
        {
            this.NumberColors = numberColors;
        }

        public Display(decimal size, int numberColors) :this(size)
        {
            this.NumberColors = numberColors;
        }
    }
}
