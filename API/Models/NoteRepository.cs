using System.Collections.Generic;

namespace WebCore.API.Models
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Note Find(string id);
        void Add(Note item);
        void Remove(string id);
    }
    public class NoteRepository : INoteRepository
    {
        private List<Note> _list;

        public NoteRepository()
        {
            _list = new List<Note>();
        }

        public void Add(Note item)
        {
            item.Key=(_list.Count+1).ToString();
            _list.Add(item);
        }

        public Note Find(string id)
        {
            return _list.Find(n=>n.Key==id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _list.AsReadOnly();
        }

        public void Remove(string id)
        {
            _list.RemoveAll(n=>n.Key==id);
        }
    }
}