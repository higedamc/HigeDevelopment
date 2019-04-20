using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MasterDetailDemo.Droid
{
    public class FontManager
    {
        private IDictionary<string, Typeface> typeFace = null;
        protected FontManager()
        {
            typeFace = new Dictionary<string, Typeface>();
        }

        private static FontManager current = null;

        public static FontManager Current
        {
            get
            {
                return current ?? (current = new FontManager());
            }
        }

        private FontManager RegisterTypeFace(string fontName, string fontPath)
        {
            Typeface newTypeface = null;

            try
            {
                newTypeface = Typeface.CreateFromAsset(
                  Application.Context.Assets,
                  fontPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Typeface service: " + ex);
                newTypeface = Typeface.Default;
            }

            typeFace.Add(fontName, newTypeface);

            return this;
        }

        public Typeface GetTypeface(string fontName)
        {
            if (!typeFace.ContainsKey(fontName))
            {
                //RegisterTypeFace(
                //  fontName,
                //  string.Format("Fonts/{0}.ttf", fontName));
                throw new Exception();
            }

            return typeFace[fontName];
        }

        public void ChangeFont(Android.Widget.TextView control, string fontFamily)
        {
            control.TransformationMethod = null;
            var typeface = string.IsNullOrEmpty(fontFamily) ?
              Typeface.Default :
              GetTypeface(fontFamily);
            control.Typeface = typeface;
        }

        public FontManager RegisterTypeFace(string fontPath)
        {
            var fontName = System.IO.Path.GetFileNameWithoutExtension(fontPath);
            Console.WriteLine("fontName: " + fontName);
            return RegisterTypeFace(fontName, fontPath);
        }
    }
}