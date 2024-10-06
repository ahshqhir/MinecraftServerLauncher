namespace MinecraftServerLauncher
{
    public static class Extension
    {
        public static void setText(this TextBox tb, string text)
        {
            tb.Text = text;
            tb.Select(text.Length, 0);
            tb.ScrollToCaret();
        }
    }
}
