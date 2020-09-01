using System;
using Android.Content;
using Android.Views;

using Xamarin.Forms;
using Android.Views.InputMethods;
using Android.Widget;
using System.Threading;

namespace MvvmAspire.Controls
{
    public static partial class UIHelper
    {
        public static Type Drawable;
        public static Type Layout;
        public static Type Id;
        public static Type Menu;
        public static Type Dimension;

        public static Context Context;

        public static int GetResource(Type resourceType, string name)
        {
            if (string.IsNullOrEmpty(name)) return -1;

            int resourceId = 0;
            var field = resourceType.GetField(name);
            if (field != null)
                resourceId = (int)field.GetValue(null);
            return resourceId;
        }

        public static int GetDrawableResource(FileImageSource source)
        {
            return source == null ? 0 : GetResource(Drawable, source.File);
        }

        public static int GetDimensionResource(string dimensionName)
        {
            return dimensionName == null ? 0 : GetResource(Dimension, dimensionName);
        }

        public static int GetLayoutResource(string name)
        {
            return GetResource(Layout, name);
        }

        public static int GetId(string name)
        {
            return GetResource(Id, name);
        }

        public static int GetMenuId(string name)
        {
            return GetResource(Menu, name);
        }

        public static void CloseSoftKeyboard(Android.Views.View view)
        {
            InputMethodManager imm = (InputMethodManager)view.Context.GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(view.WindowToken, 0);
        }

        public static void OpenSoftKeyboard(Android.Views.View view)
        {
            view.RequestFocus();
            ThreadPool.QueueUserWorkItem(s =>
            {
                try
                {
                    Thread.Sleep(100);
                    InputMethodManager inputMethodManager = view.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                    inputMethodManager.ShowSoftInput(view, ShowFlags.Forced);
                    inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
                }
                catch(Exception e)
                {

                }
     

            });
        }

        public static Android.Graphics.Color Convert(Color color)
        {
            return Android.Graphics.Color.Argb(BaseUIHelper.ConvertDoubleToByteColor(color.A),
                                               BaseUIHelper.ConvertDoubleToByteColor(color.R),
                                               BaseUIHelper.ConvertDoubleToByteColor(color.G),
                                               BaseUIHelper.ConvertDoubleToByteColor(color.B));
        }
    
    }
}