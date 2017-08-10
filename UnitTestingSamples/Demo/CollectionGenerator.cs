using System.Collections.Generic;

namespace Demo
{
    public class CollectionGenerator
    {
        public IEnumerable<string> GetNames() => new List<string>(){"Jan Kowalski", "Piotr Kowalski", "Anna Morawiecka"};
    }
}
