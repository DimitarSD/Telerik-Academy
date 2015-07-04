namespace RefactorIfStatements
{
    public class Potato
    {
        private bool isNotRotten;
        private bool hasBeenPeeled;

        public Potato()
        {
        }

        public bool IsNotRotten
        {
            get
            {
                return this.isNotRotten;
            }

            set
            {
                this.isNotRotten = value;
            }
        }

        public bool HasBeenPeeled
        {
            get
            {
                return this.hasBeenPeeled;
            }

            set
            {
                this.hasBeenPeeled = value;
            }
        }
    }
}
