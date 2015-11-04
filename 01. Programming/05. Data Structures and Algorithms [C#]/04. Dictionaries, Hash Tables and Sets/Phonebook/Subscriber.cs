namespace PhonebookADT
{
    public class Subscriber
    {
        /// <summary>
        /// Creates an instance of Subscriber class with name, town and phone number
        /// </summary>
        /// <param name="name"></param>
        /// <param name="town"></param>
        /// <param name="phoneNumber"></param>
        public Subscriber(string name, string town, string phoneNumber)
        {
            this.Name = name;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets and set the subscriber name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets and set the subscriber town
        /// </summary>
        public string Town { get; private set; }

        /// <summary>
        /// Gets and set the subscriber phone number
        /// </summary>
        public string PhoneNumber { get; private set; }

        public override string ToString()
        {
            return string.Format("{0,-25} |    {1,-10} |    {2,-10}",
                this.Name, this.Town, this.PhoneNumber);
        }
    }
}
