using System.Security.Policy;

namespace ConnectFour
{
    class Space
    {
        //public Disc Disc { get; set; }
        public SpaceState State { get; set; }

        public override string ToString()
        {
            if (State == SpaceState.R)
            {
                return "R";
            }

            return "Y";

        }
    }
}
