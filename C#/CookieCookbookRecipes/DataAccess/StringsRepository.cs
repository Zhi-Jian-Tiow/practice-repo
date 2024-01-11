namespace CookieCookBook.DataAccess
{
    public abstract class StringsRepository : IStringsRepository
    {

        protected abstract List<string> TextToString(string fileContents);
        protected abstract string StringToText(List<string> strings);

        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                string fileContents = File.ReadAllText(filePath);
                return TextToString(fileContents);
            }
            return new List<string>();
        }

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringToText(strings));
        }
    }
}
