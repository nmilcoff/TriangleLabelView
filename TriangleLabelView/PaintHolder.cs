using System;
using Android.Graphics;

namespace TriangleLabelView
{
    internal class PaintHolder
    {
        public string Text { get; set; } = string.Empty;

        public Paint Paint { get; set; }

        public Android.Graphics.Color Color { get; set; }

        public int Style { get; set; }

        public float Size { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public void Initialize()
        {
            this.Paint = new Paint(PaintFlags.AntiAlias);
            this.Paint.Color = this.Color;
            this.Paint.TextAlign = Paint.Align.Center;
            this.Paint.TextSize = this.Size;

            if (this.Style == 1)
            {
                this.Paint.SetTypeface(Typeface.SansSerif);
            }
            else
            {
                this.Paint.SetTypeface(Typeface.DefaultBold);
            }
        }

        public void ResetStatus()
        {
            Rect rectText = new Rect();
            this.Paint.GetTextBounds(this.Text, 0, this.Text.Length, rectText);
            this.Width = rectText.Width();
            this.Height = rectText.Height();
        }
    }
}
