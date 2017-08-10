namespace Demo
{
    public class StringWorker
    {
        public string ConcatenateStrings(string s1, string s2) => string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) ? null : $"{s1} {s2}";
    }
}
