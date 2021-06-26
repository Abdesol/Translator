using Android.Graphics.Drawables;
using Android.Text;
using Translator.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(Editor), typeof(EditorCH))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace Translator.Droid
{
    [System.Obsolete]
    public class EditorCH : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}