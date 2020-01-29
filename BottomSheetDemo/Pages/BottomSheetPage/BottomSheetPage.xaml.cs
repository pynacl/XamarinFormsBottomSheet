using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BottomSheetDemo.Helpers;
using Xamarin.Forms;

namespace BottomSheetDemo.Pages.BottomSheetPage
{
    public partial class BottomSheetPage : ContentPage
    {
        private double BOTTOM_SHEET_OPEN_RATIO = -1.85; // you'll need to play with this value to get the right height or look into making it dynamic based on content height
        //private double BOTTOM_SHEET_OPEN_EXTENDED_RATIO = -1;
        private double BOTTOM_SHEET_CLOSED_RATIO = 999;
        private uint BOTTOM_SHEET_ANIMATION_SPEED = 500;
        public bool isBottomSheetOpen;

        public BottomSheetPage()
        {
            InitializeComponent();
            SubscribeToMessengers();

            // if you have an entry you will want to do something like the below to raise/lower the bottomsheet so the user can see what they are typing

            //entry.Unfocused += (object sender, FocusEventArgs e) =>
            //{
            //    if (isBottomSheetOpen)
            //    {
            //        bottomSheet.TranslateTo(bottomSheet.X, Height / BOTTOM_SHEET_OPEN_RATIO, BOTTOM_SHEET_ANIMATION_SPEED, Easing.SinOut);
            //    }
            //    isBottomSheetOpen = true;
            //};

            //entry.Focused += (object sender, FocusEventArgs e) => {
            //    // move the bottom sheet up a lil bit
            //    bottomSheet.TranslateTo(bottomSheet.X, Height / BOTTOM_SHEET_OPEN_EXTENDED_RATIO, BOTTOM_SHEET_ANIMATION_SPEED, Easing.SinOut);
            //    isBottomSheetOpen = true;
            //};
        }

        public Action CustomBackButtonAction
        {
            get
            {
                return async () =>
                {
                    CloseBottomSheet(null, null);
                };
            }
        }

        private void SubscribeToMessengers()
        {
            MessagingCenter.Subscribe<Application>(this, Constants.SHOW_BOTTOM_SHEET, (sender) =>
            {
                OpenBottomSheet(sender, null);
            });

            MessagingCenter.Subscribe<Application>(this, Constants.HIDE_BOTTOM_SHEET, (sender) =>
            {
                CloseBottomSheet(sender, null);
            });
        }

        private void CloseBottomSheet(object sender, SwipedEventArgs swipedEventArgs)
        {
            bottomSheet.TranslateTo(bottomSheet.X, Height + BOTTOM_SHEET_CLOSED_RATIO, BOTTOM_SHEET_ANIMATION_SPEED, Easing.SinIn);
            backgroundFade.FadeTo(0, BOTTOM_SHEET_ANIMATION_SPEED);
            backgroundFade.IsVisible = false;
            isBottomSheetOpen = false;
        }

        void CloseBottomSheetTap(object sender, EventArgs args)
        {
            bottomSheet.TranslateTo(bottomSheet.X, Height + BOTTOM_SHEET_CLOSED_RATIO, BOTTOM_SHEET_ANIMATION_SPEED, Easing.SinIn);
            backgroundFade.FadeTo(0, BOTTOM_SHEET_ANIMATION_SPEED);
            backgroundFade.IsVisible = false;
            isBottomSheetOpen = false;
        }

        private void OpenBottomSheet(object sender, SelectedItemChangedEventArgs e)
        {
            bottomSheet.TranslateTo(bottomSheet.X, Height / BOTTOM_SHEET_OPEN_RATIO, BOTTOM_SHEET_ANIMATION_SPEED, Easing.SinOut);
            backgroundFade.IsVisible = true;
            backgroundFade.FadeTo(.5, BOTTOM_SHEET_ANIMATION_SPEED);
            isBottomSheetOpen = true;
        }

    }
}
