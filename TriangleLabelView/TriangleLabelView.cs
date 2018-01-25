using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace TriangleLabelView
{
    [Register("jp.shts.android.library.TriangleLabelView")]
    public class TriangleLabelView : View
    {
        private PaintHolder primary = new PaintHolder();
        private PaintHolder secondary = new PaintHolder();

        private Paint trianglePaint;

        private int width, height;

        private const int DEGREES_LEFT = -45;
        private const int DEGREES_RIGHT = 45;

        public TriangleLabelView(Context context)
            : base(context)
        {
            this.Init(context, null);
        }

        public TriangleLabelView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            this.Init(context, attrs);
        }

        public TriangleLabelView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            this.Init(context, attrs);
        }

        public TriangleLabelView(IntPtr javaReference, JniHandleOwnership handle)
            : base(javaReference, handle)
        {
        }

        public TriangleLabelView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleAttr)
        {
            this.Init(context, attrs);
        }

        private float topPadding;
        public float TopPadding
        {
            get
            {
                return this.topPadding;
            }
            set
            {
                this.topPadding = value.DpToPx(this.Context);
            }
        }

        private float bottomPadding;
        public float BottomPadding
        {
            get
            {
                return this.bottomPadding;
            }
            set
            {
                this.bottomPadding = value.DpToPx(this.Context);
                this.Relayout();
            }
        }

        private float centerPadding;
        public float CenterPadding
        {
            get
            {
                return this.centerPadding;
            }
            set
            {
                this.centerPadding = value.DpToPx(this.Context);
                this.Relayout();
            }
        }

        public string PrimaryText
        {
            get
            {
                return this.primary.Text;
            }
            set
            {
                this.primary.Text = value;
                this.primary.ResetStatus();
                this.Relayout();
            }
        }

        public string SecondaryText
        {
            get
            {
                return this.secondary.Text;
            }
            set
            {
                this.secondary.Text = value;
                this.secondary.ResetStatus();
                this.Relayout();
            }
        }

        public Color PrimaryTextColor
        {
            get
            {
                return this.primary.Color;
            }
            set
            {
                this.primary.Color = value;
                this.primary.Initialize();
                this.primary.ResetStatus();
                this.Relayout();
            }
        }

        public Color SecondaryTextColor
        {
            get
            {
                return this.secondary.Color;
            }
            set
            {
                this.secondary.Color = value;
                this.secondary.Initialize();
                this.secondary.ResetStatus();
                this.Relayout();
            }
        }

        public float PrimaryTextSize
        {
            get
            {
                return this.primary.Size;
            }
            set
            {
                this.primary.Size = value.SpToPx(this.Context);
                this.Relayout();
            }
        }

        public float SecondaryTextSize
        {
            get
            {
                return this.secondary.Size;
            }
            set
            {
                this.secondary.Size = value.SpToPx(this.Context);
                this.Relayout();
            }
        }

        private Color triangleBackgroundColor;
        public Color TriangleBackgroundColor
        {
            get
            {
                return this.triangleBackgroundColor;
            }
            set
            {
                this.triangleBackgroundColor = value;
                this.trianglePaint.Color = this.triangleBackgroundColor;
                this.Relayout();
            }
        }

        private Corner corner;
        public Corner Corner
        {
            get
            {
                return this.corner;
            }
            set
            {
                this.corner = value;
                this.Relayout();
            }
        }

        private void Init(Context context, IAttributeSet attrs)
        {
            TypedArray ta = context.ObtainStyledAttributes(attrs, Resource.Styleable.TriangleLabelView);

            this.topPadding = ta.GetDimension(Resource.Styleable.TriangleLabelView_labelTopPadding, 7f.DpToPx(this.Context));
            this.centerPadding = ta.GetDimension(Resource.Styleable.TriangleLabelView_labelCenterPadding, 3f.DpToPx(this.Context));
            this.bottomPadding = ta.GetDimension(Resource.Styleable.TriangleLabelView_labelBottomPadding, 3f.DpToPx(this.Context));

            this.triangleBackgroundColor = ta.GetColor(Resource.Styleable.TriangleLabelView_backgroundColor, Color.ParseColor("#66000000"));
            this.primary.Color = ta.GetColor(Resource.Styleable.TriangleLabelView_primaryTextColor, Color.White);
            this.secondary.Color = ta.GetColor(Resource.Styleable.TriangleLabelView_secondaryTextColor, Color.White);

            this.primary.Size = ta.GetDimension(Resource.Styleable.TriangleLabelView_primaryTextSize, 11f.SpToPx(this.Context));
            this.secondary.Size = ta.GetDimension(Resource.Styleable.TriangleLabelView_secondaryTextSize, 8f.SpToPx(this.Context));

            var primaryText = ta.GetString(Resource.Styleable.TriangleLabelView_primaryText);
            if (!string.IsNullOrEmpty(primaryText))
            {
                this.primary.Text = primaryText;
            }
            var secondaryText = ta.GetString(Resource.Styleable.TriangleLabelView_secondaryText);
            if (!string.IsNullOrEmpty(secondaryText))
            {
                this.secondary.Text = secondaryText;
            }

            this.primary.Style = ta.GetInt(Resource.Styleable.TriangleLabelView_primaryTextStyle, 2);
            this.secondary.Style = ta.GetInt(Resource.Styleable.TriangleLabelView_secondaryTextStyle, 0);

            this.Corner = (Corner)ta.GetInt(Resource.Styleable.TriangleLabelView_corner, 1);

            ta.Recycle();

            this.primary.Initialize();
            this.secondary.Initialize();

            this.trianglePaint = new Paint(PaintFlags.AntiAlias);
            this.trianglePaint.Color = this.triangleBackgroundColor;

            this.primary.ResetStatus();
            this.secondary.ResetStatus();
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.Save();

            // translate
            if (this.Corner == Corner.TopLeft || this.Corner == Corner.TopRight)
            {
                canvas.Translate(0, (float)(this.height * Math.Sqrt(2) - this.height));
            }

            // rotate
            if (this.Corner == Corner.TopLeft || this.Corner == Corner.TopRight)
            {
                if (this.Corner == Corner.TopLeft || this.Corner == Corner.BottomLeft)
                {
                    canvas.Rotate(DEGREES_LEFT, 0, this.height);
                }
                else
                {
                    canvas.Rotate(DEGREES_RIGHT, this.width, this.height);
                }
            }
            else
            {
                if (this.Corner == Corner.TopLeft || this.Corner == Corner.BottomLeft)
                {
                    canvas.Rotate(DEGREES_RIGHT, 0, 0);
                }
                else
                {
                    canvas.Rotate(DEGREES_LEFT, this.width, 0);
                }
            }

            // draw triangle
            var path = new Path();
            if (this.Corner == Corner.TopLeft || this.Corner == Corner.TopRight)
            {
                path.MoveTo(0, this.height);
                path.LineTo(this.width / 2, 0);
                path.LineTo(this.width, this.height);
            }
            else
            {
                path.MoveTo(0, 0);
                path.LineTo(this.width / 2, this.height);
                path.LineTo(this.width, 0);
            }
            path.Close();
            canvas.DrawPath(path, this.trianglePaint);

            // draw secondary text
            if (this.Corner == Corner.TopLeft || this.Corner == Corner.TopRight)
            {
                canvas.DrawText(this.secondary.Text, this.width / 2, this.TopPadding + this.secondary.Height, this.secondary.Paint);
                canvas.DrawText(this.primary.Text, this.width / 2, this.TopPadding + this.secondary.Height + this.CenterPadding + this.primary.Height, this.primary.Paint);
            }
            else
            {
                canvas.DrawText(this.secondary.Text, this.width / 2, this.BottomPadding + this.secondary.Height + this.CenterPadding + this.primary.Height, this.secondary.Paint);
                canvas.DrawText(this.primary.Text, this.width / 2, this.BottomPadding + this.primary.Height, this.primary.Paint);
            }
            canvas.Restore();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            this.height = (int)(this.TopPadding + this.CenterPadding + this.BottomPadding + this.secondary.Height + this.primary.Height);
            this.width = 2 * this.height;
            int realHeight = (int)(this.height * Math.Sqrt(2));
            this.SetMeasuredDimension(this.width, realHeight);
        }

        private void Relayout()
        {
            this.Invalidate();
            this.RequestLayout();
        }
    }
}
