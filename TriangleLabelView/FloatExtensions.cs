using System;
using Android.Content;

namespace TriangleLabelView
{
    internal static class FloatExtensions
    {
        public static float DpToPx(this float dpValue, Context context)
        {
            var scale = context.Resources.DisplayMetrics.Density;
            return dpValue * scale + 0.5f;
        }

        public static float SpToPx(this float spValue, Context context)
        {
            var scale = context.Resources.DisplayMetrics.ScaledDensity;
            return spValue * scale;
        }
    }
}
