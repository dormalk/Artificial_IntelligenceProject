using System;


namespace AI
{
    public interface ISearcher
    {
        Solution Search<T>(ISearchable searchable);
    }
}
