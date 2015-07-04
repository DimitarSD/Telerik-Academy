namespace ClassChef
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            this.Peel(carrot);
            this.Peel(potato);

            this.Cut(potato);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(Vegetable vegetableToBeCut)
        {
            // ...
        }

        private void Peel(Vegetable vegetableToBePeeled)
        {
            // ...
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }
    }
}
