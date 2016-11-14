using Android.OS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using WKEU_BESR.Common;
using WKEU_BESR.Controls;
using WKEU_BESR.Events;
using WKEU_BESR.Models;
using WKEU_BESR.Services;
using WKEU_BESR.Services.Cache;
using WKEU_BESR.Services.MessagingCenter;
using WKEU_BESR.Services.Network;
using WKEU_BESR.ViewModels;
using WKEU_BESR.Services.PageDialogService;

namespace WKEU_BESR.Views
{
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
        }


        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }


    }
}
