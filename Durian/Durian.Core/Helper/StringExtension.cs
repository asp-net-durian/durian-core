namespace Durian.Core.Helper
{
    public static class StringExtension
    {
        public static string MergeParameter(this string keyConst, params object[] parameter)
        {
            return string.Format(keyConst,parameter);
        }
    }
}