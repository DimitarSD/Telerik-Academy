namespace TreeOfNodes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Node<T>
    {
        private T value;
        private Node<T> parent;
        private ICollection<Node<T>> children;

        /// <summary>
        /// Creates a new instance of the Node class with empty set of children.
        /// </summary>
        /// <param name="value">The value uniquely identifies the node.</param>
        public Node(T value)
        {
            this.Value = value;
            this.Children = new HashSet<Node<T>>();
        }

        /// <summary>
        /// Creates a new instance of the Node class with given value and parent node.
        /// </summary>
        /// <param name="value">The value uniquely identifies the node.</param>
        /// <param name="parent">The parent node</param>
        public Node(T value, Node<T> parent) 
           : this(value)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Gets and sets node's value that uniquely identifies it.
        /// </summary>
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Gets and sets the parent node.
        /// </summary>
        public Node<T> Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.parent = value;
            }
        }

        /// <summary>
        /// Gets and sets a collection of the children nodes.
        /// </summary>
        public ICollection<Node<T>> Children
        {
            get
            {
                return this.children;
            }

            set
            {
                this.children = value;
            }
        }
        
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("Node -> Value: {0}", this.Value);

            if (this.Children.Count > 0)
            {
                var childrenValues = this.Children.Select(c => c.Value);
                var valuesToString = string.Join(", ", childrenValues);
                output.AppendFormat(" | Direct children: {{ {0} }}", valuesToString);
            }

            return output.ToString();
        }
    }
}
