namespace ConnectFour
{
    class Disc
    {
        public DiscColour Colour { get; set; }

        public override string ToString()
        {
            if (Colour == DiscColour.R)
            {
                return "R";
            }

            return "Y";

        }
    }


}
