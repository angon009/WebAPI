using System.Collections.Generic;

namespace ReserveitProject.Interfaces
{
    public interface IWordsRepository
    {
        public bool SaveWords(List<string> words, int pageSize);
        public List<string> GetLines();
    }
}
