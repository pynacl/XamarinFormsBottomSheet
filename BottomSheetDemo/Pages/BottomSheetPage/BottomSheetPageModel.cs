using System;
using BottomSheetDemo.Helpers;
using FreshMvvm;
using Xamarin.Forms;

namespace BottomSheetDemo.Pages.BottomSheetPage
{
    public class BottomSheetPageModel : FreshBasePageModel
    {
        public BottomSheetPageModel()
        {
        }

        public Command OpenBottomSheet
        {
            get
            {
                return new Command(async () =>
                {
                    MessagingCenter.Send(Application.Current, Helpers.Constants.SHOW_BOTTOM_SHEET);
                });
            }
        }
    }
}
