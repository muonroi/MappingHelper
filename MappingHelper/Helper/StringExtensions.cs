namespace MappingHelper.Helper
{
    internal static partial class StringExtensions
    {
        public static string Pipe(this string input, Func<string, string> func)
        {
            return func(input);
        }
    }
}