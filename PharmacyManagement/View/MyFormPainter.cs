using DevExpress.Skins;
using DevExpress.Skins.XtraForm;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagement.View
{
    internal class MyFormPainter: FormPainter
    {
        public MyFormPainter(Control owner, ISkinProvider provider) : base(owner, provider) { }
        protected override void DrawBackground(GraphicsCache cache)
        {
            base.DrawBackground(cache);
            cache.FillRectangle(Color.FromArgb(51, 77, 43), CaptionBounds);
        }

        protected override void DrawText(GraphicsCache cache)
        {
            string text = Text;
            if (text == null || text.Length == 0 || this.TextBounds.IsEmpty) return;
            AppearanceObject appearance = new AppearanceObject(GetDefaultAppearance());
            appearance.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            appearance.ForeColor = Color.White;
            appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Rectangle r = RectangleHelper.GetCenterBounds(CaptionBounds, 
            new Size(CaptionBounds.Width, appearance.CalcDefaultTextSize(cache.Graphics).Height));
            DrawTextShadow(cache, appearance, r);
            cache.DrawString(text, appearance.Font, appearance.GetForeBrush(cache), r, appearance.GetStringFormat());
        }
    }
}
