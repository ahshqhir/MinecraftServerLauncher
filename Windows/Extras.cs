namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    public static class Extension
    {
        #region methods

        public static void SetText(this TextBox tb, string? text)
        {
            text = text ?? string.Empty;
            tb.Text = text;
            tb.Select(text.Length, 0);
            tb.ScrollToCaret();
        }

        #endregion
    }

    public class WrongFileFormatException : IOException
    {
        #region constructors

        public WrongFileFormatException() : base("File is in wrong format!") { }

        #endregion
    }
}
