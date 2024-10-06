namespace MinecraftServerLauncher
{
    public static class Extension
    {
        #region methods

        public static void SetText(this TextBox tb, string text)
        {
            tb.Text = text;
            tb.Select(text.Length, 0);
            tb.ScrollToCaret();
        }

        #endregion
    }
}
