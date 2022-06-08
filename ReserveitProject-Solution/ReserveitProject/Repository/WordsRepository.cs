using ReserveitProject.Repository;
using System.Collections.Generic;

namespace ReserveitProject.Repository
{
    public class WordsRepository : IWordsRepository
    {
        private static List<string> Words = new List<string>();
        private static int pageSize = 0;

        public List<string> GetLines()
        {
            if (pageSize == 0)
                return null;

            List<string> Lines = new List<string>();

            string temp = "";
            foreach (var word in Words)
            {
                temp += word;
            }

            int startIndex = 0;
            while (startIndex < temp.Length)
            {
                if (startIndex + pageSize > temp.Length)
                {
                    Lines.Add(temp.Substring(startIndex, temp.Length - startIndex));
                }
                else
                {
                    Lines.Add(temp.Substring(startIndex, pageSize));
                }

                startIndex += pageSize;
            }

            return Lines;
        }

        public bool SaveWords(List<string> words, int size)
        {
            if (size > 0)
            {
                Words = words;
                pageSize = size;
                return true;
            }
            return false;
        }
    }
}
