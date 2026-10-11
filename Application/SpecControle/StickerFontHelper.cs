namespace SpecControle
{
    public static class StickerFontHelper
    {
        /// <summary>
        /// Scales the font down step by step until the text fits within the given width. Used for the
        /// fan application sentence, which is far longer than any other cell text on the stickers, so it
        /// stays inside its bar both on screen and when printing.
        /// </summary>
        public static Font FitToWidth(Graphics graph, Font font, string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return font;
            }

            var fitted = font;
            while (fitted.Size > 1 && graph.MeasureString(text, fitted).Width > width)
            {
                fitted = new Font(fitted.FontFamily, fitted.Size * 0.9f, fitted.Style, fitted.Unit);
            }
            return fitted;
        }
    }
}
