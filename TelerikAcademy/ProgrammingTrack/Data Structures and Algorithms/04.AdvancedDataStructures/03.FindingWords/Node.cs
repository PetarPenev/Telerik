namespace _03.FindingWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Node
    {
        private Dictionary<char, Node> nextCharacters;

        private bool isFinishedWord;

        public Node(bool isFinishedWord)
        {
            this.nextCharacters = new Dictionary<char, Node>();
            this.isFinishedWord = isFinishedWord;
        }

        public Dictionary<char, Node> NextCharacters
        {
            get { return this.nextCharacters; }
            private set { this.nextCharacters = value; }
        }

        public bool IsFinishedWord
        {
            get { return this.isFinishedWord; }
            set { this.isFinishedWord = value; }
        }

        public void AddChild(char child, bool isFinishedWord)
        {
            this.nextCharacters.Add(child, new Node(isFinishedWord));
        }
    }
}
