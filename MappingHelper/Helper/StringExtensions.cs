namespace MappingHelper.Helper
{
    internal static class StringExtensions
    {
        public static string Pipe(this string input, Func<string, string> func)
        {
            return func(input);
        }
    }
}