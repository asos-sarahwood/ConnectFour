namespace ConnectFour
{
    class Filled : Space
    {
        public override string ToString()
        {
            if (Disc.Colour == "R")
            {
                return "R";

            }

            return "Y";
        }
    }
}