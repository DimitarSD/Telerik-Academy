namespace PhonebookADT
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Comparers;

    public class Phonebook
    {
        private const string NullCollectionExceptionMessage = "Collection cannot be null.";

        /// <summary>
        /// Holds all subscribers objects in collection.
        /// </summary>
        private readonly ICollection<Subscriber> subscribers;

        /// <summary>
        /// Holds all subscribers as keys of its names.
        /// </summary>
        private readonly IDictionary<string, LinkedList<Subscriber>> subscribersByName;

        /// <summary>
        /// Holds all subscribers as keys of its names and town.
        /// </summary>
        private readonly IDictionary<Tuple<string, string>, LinkedList<Subscriber>> subscribersByNameAndTown;

        /// <summary>
        /// Creates an instance of Phonebook class with given collection of subscribers
        /// </summary>
        /// <param name="subscribers"></param>
        public Phonebook(IList<Subscriber> subscribers)
        {
            if (subscribers == null)
            {
                throw new ArgumentNullException(NullCollectionExceptionMessage);
            }

            this.subscribers = new List<Subscriber>(subscribers);

            this.subscribersByName =
                new Dictionary<string, LinkedList<Subscriber>>(new CaseInsensitiveComparer());

            this.subscribersByNameAndTown =
                new Dictionary<Tuple<string, string>, LinkedList<Subscriber>>(new CaseInsensitiveTupleComparer());

            this.AddSubscribers(this.subscribers);
        }

        /// <summary>
        /// Adds new subscriber
        /// </summary>
        /// <param name="subscriber">Subscriber to be added</param>
        public void AddSubscriber(Subscriber subscriber)
        {
            this.AddSubscribers(new List<Subscriber>() { subscriber });
        }

        /// <summary>
        /// Adds collection of subscribers
        /// </summary>
        /// <param name="subscribers">Collection to be added</param>
        public void AddSubscribers(ICollection<Subscriber> subscribers)
        {
            if (subscribers == null)
            {
                throw new ArgumentNullException(NullCollectionExceptionMessage);
            }

            if (subscribers != this.subscribers)
            {
                foreach (var subscriber in subscribers)
                {
                    this.subscribers.Add(subscriber);
                }
            }

            foreach (var subscriber in subscribers)
            {
                var subscriberNames = subscriber.Name.Split(' ');

                foreach (var name in subscriberNames)
                {
                    this.AddSubscriberByName(name, subscriber);

                    this.AddSubscriberByNameAndTown(name, subscriber);
                }
            }
        }

        /// <summary>
        /// Search a subscriber by given name
        /// </summary>
        /// <param name="name">Name to search</param>
        /// <returns>Returns collection of all subscriber founded with that name. If can't find returns empty collection</returns>
        public ICollection<Subscriber> Find(string name)
        {
            LinkedList<Subscriber> subscribers;
            this.subscribersByName.TryGetValue(name, out subscribers);

            return subscribers ?? new LinkedList<Subscriber>();
        }

        /// <summary>
        /// Search a subcriber by given name and town
        /// </summary>
        /// <param name="name">Name to search</param>
        /// <param name="town">Town to search</param>
        /// <returns>Returns collection of all subscriber founded with that name and town. 
        /// If can't find any subscriber returns empty collection</returns>
        public ICollection<Subscriber> Find(string name, string town)
        {
            var tuple = new Tuple<string, string>(name, town);
            LinkedList<Subscriber> subscribers;
            this.subscribersByNameAndTown.TryGetValue(tuple, out subscribers);

            return subscribers ?? new LinkedList<Subscriber>();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(new string('-', 35) + " PHONEBOOK" + new string('-', 35) + Environment.NewLine);

            foreach (var item in this.subscribers)
            {
                result.AppendFormat("   - {0}{1}", item, Environment.NewLine);
            }

            result.AppendLine(Environment.NewLine + new string('-', 80));
            return result.ToString();
        }

        private void AddSubscriberByName(string name, Subscriber subscriber)
        {
            if (!this.subscribersByName.ContainsKey(name))
            {
                this.subscribersByName[name] = new LinkedList<Subscriber>();
            }

            this.subscribersByName[name].AddLast(subscriber);
        }

        private void AddSubscriberByNameAndTown(string name, Subscriber subscriber)
        {
            var tuple = new Tuple<string, string>(name, subscriber.Town);

            if (!this.subscribersByNameAndTown.ContainsKey(tuple))
            {
                this.subscribersByNameAndTown[tuple] = new LinkedList<Subscriber>();
            }

            this.subscribersByNameAndTown[tuple].AddLast(subscriber);
        }
    }
}
