namespace ASM2.Helpers
{
    public abstract class SearchHelper<T>
    {
        public List<T> SearchList(List<T>? list, string keyword)
        {
            List<T> result = new List<T>();
            foreach (var obj in list)
            {
                if (Compare(obj, keyword))
                {
                    result.Add(obj);
                }
            }
            return result;
        }

        public List<T> SearchList(List<T>? list, string keyword, string type)
        {
            List<T> result = new List<T>();
            foreach (var obj in list)
            {
                if (Compare(obj, keyword, type))
                {
                    result.Add(obj);
                }
            }
            return result;
        }

        protected abstract bool Compare(T obj, string keyword);
        protected abstract bool Compare(T obj, string keyword, string type);
    }
}
