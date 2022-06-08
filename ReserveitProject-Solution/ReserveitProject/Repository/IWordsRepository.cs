using System.Collections.Generic;

namespace ReserveitProject.Repository
{
    public interface IWordsRepository
    {
        public bool SaveWords(List<string> words, int pageSize);
        public List<string> GetLines();
    }
}
