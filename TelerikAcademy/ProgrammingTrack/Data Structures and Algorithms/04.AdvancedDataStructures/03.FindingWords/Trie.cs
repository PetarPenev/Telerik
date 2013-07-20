namespace _03.FindingWords
{
    using System;
    using System.Linq;
    using System.Text;

    public class Trie
    {
        private Node root;

        public Trie()
        {
            this.root = new Node(false);
        }

        public void AddWord(string word)
        {
            Node currentNode = this.root;
            int wordIndex = 0;

            while (wordIndex < word.Length)
            {
                char currentChar = word[wordIndex];
                if (currentNode.NextCharacters.Keys.Contains(currentChar))
                {
                    currentNode = currentNode.NextCharacters[currentChar];
                    if (wordIndex == word.Length - 1)
                    {
                        currentNode.IsFinishedWord = true;
                    }
                }
                else
                {
                    if (wordIndex == word.Length - 1)
                    {
                        currentNode.AddChild(currentChar, true);
                        currentNode = currentNode.NextCharacters[currentChar];
                    }
                    else
                    {
                        currentNode.AddChild(currentChar, false);
                        currentNode = currentNode.NextCharacters[currentChar];
                    }
                }

                wordIndex++;
            }
        }

        public bool ContainWord(string word)
        {
            Node currentNode = this.root;
            int wordIndex = 0;
            while (wordIndex < word.Length)
            {
                if (!currentNode.NextCharacters.Keys.Contains(word[wordIndex]))
                {
                    return false;
                }

                currentNode = currentNode.NextCharacters[word[wordIndex]];

                if (wordIndex == word.Length - 1)
                {
                    if (currentNode.IsFinishedWord == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                wordIndex++;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder("{");
            representation.Append(this.GetString(this.root));

            representation.Append("}");

            return representation.ToString();
        }

        private string GetString(Node node)
        {
            StringBuilder currentString = new StringBuilder();
            foreach (var item in node.NextCharacters.Keys)
            {
                currentString.Append(item);
            }

            foreach (var item in node.NextCharacters.Keys)
            {
                currentString.Append(this.GetString(node.NextCharacters[item]));
            }

            return currentString.ToString();
        }
    }
}
