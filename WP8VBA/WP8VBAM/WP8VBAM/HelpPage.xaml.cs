using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using PhoneDirect3DXamlAppInterop.Resources;

namespace PhoneDirect3DXamlAppInterop
{
    public partial class HelpPage : PhoneApplicationPage
    {
        public HelpPage()
        {
            InitializeComponent();
#if GBC
            importSkydriveText.Text = AppResources.HelpImportSkyDriveText2;
            importEmailText.Text = AppResources.HelpImportEmailText2;
            importWebText.Text = AppResources.HelpImportWebText2;
            contactBlock.Text = AppResources.AboutContact2;
#endif
        }

        private void contactBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailcomposer = new EmailComposeTask();
#if !GBC
            emailcomposer.To = AppResources.AboutContact;
#else
            emailcomposer.To = AppResources.AboutContact2;
#endif
            emailcomposer.Subject = "bug report or feature suggestion";
            emailcomposer.Body = "Insert your bug report or feature request here.";
            emailcomposer.Show();
        }
    }
}