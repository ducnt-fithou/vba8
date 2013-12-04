using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneDirect3DXamlAppInterop.Resources;
using PhoneDirect3DXamlAppComponent;

namespace PhoneDirect3DXamlAppInterop
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public const String VControllerPosKey = "VirtualControllerOnTop";
        public const String EnableSoundKey = "EnableSound";
        public const String LowFreqModeKey = "LowFrequencyModeNew";
        public const String OrientationKey = "Orientation";
        public const String ControllerScaleKey = "ControllerScale";
        public const String StretchKey = "FullscreenStretch";
        public const String OpacityKey = "ControllerOpacity";
        public const String AspectKey = "AspectRatioModeKey";
        public const String SkipFramesKey = "SkipFramesKey";
        public const String ImageScalingKey = "ImageScalingKey";
        public const String TurboFrameSkipKey = "TurboSkipFramesKey";
        public const String SyncAudioKey = "SynchronizeAudioKey";
        public const String PowerSaverKey = "PowerSaveSkipKey";
        public const String DPadStyleKey = "DPadStyleKey";
        public const String DeadzoneKey = "DeadzoneKey";
        public const String CameraAssignKey = "CameraAssignmentKey";
        public const String ConfirmationKey = "ConfirmationKey";
        public const String ConfirmationLoadKey = "ConfirmationLoadKey";
        public const String AutoIncKey = "AutoIncKey";
        public const String SelectLastState = "SelectLastStateKey";
        public const String RestoreCheatKey = "RestoreCheatKey";
        public const String CreateManualSnapshotKey = "ManualSnapshotKey";

        bool initdone = false;

        public SettingsPage()
        {
            InitializeComponent();
            ReadSettings();
#if GBC
            RestoreListItem.Visibility = Visibility.Collapsed;

            this.turboSkip1Radio.Content = "2";
            this.turboSkip2Radio.Content = "4";
            this.turboSkip3Radio.Content = "6";
            this.turboSkip4Radio.Content = "8";
            this.turboSkip5Radio.Content = "10";
            
            this.aspect32Radio.Content = AppResources.AspectRatio10to9Setting;
#endif
        }

        private void ReadSettings()
        {
            EmulatorSettings emuSettings = EmulatorSettings.Current;

            this.vcontrollerPosSwitch.IsChecked = emuSettings.VirtualControllerOnTop;
            this.enableSoundSwitch.IsChecked = emuSettings.SoundEnabled;
            this.lowFreqSwitch.IsChecked = emuSettings.LowFrequencyMode;
            //this.stretchToggle.IsChecked = emuSettings.FullscreenStretch;
            this.scaleSlider.Value = emuSettings.ControllerScale;
            this.opacitySlider.Value = emuSettings.ControllerOpacity;
            this.imageScaleSlider.Value = emuSettings.ImageScaling;
            this.deadzoneSlider.Value = emuSettings.Deadzone;
            this.syncSoundSwitch.IsChecked = emuSettings.SynchronizeAudio;
            this.confirmationSwitch.IsChecked = emuSettings.HideConfirmationDialogs;
            this.autoIncSwitch.IsChecked = emuSettings.AutoIncrementSavestates;
            this.confirmationLoadSwitch.IsChecked = emuSettings.HideLoadConfirmationDialogs;
            this.restoreLastStateSwitch.IsChecked = emuSettings.SelectLastState;
            this.cheatRestoreSwitch.IsChecked = emuSettings.RestoreOldCheatValues;
            this.manualSnapshotSwitch.IsChecked = emuSettings.ManualSnapshots;            
            
            this.Loaded += (o, e) =>
            {
                switch (emuSettings.Orientation)
                {
                    default:
                    case 0:
                        this.orientationBothRadio.IsChecked = true;
                        break;
                    case 1:
                        this.orientationLandscapeRadio.IsChecked = true;
                        break;
                    case 2:
                        this.orientationPortraitRadio.IsChecked = true;
                        break;
                }

#if GBC
                switch (emuSettings.TurboFrameSkip)
                {
                    default:
                    case 2:
                        this.turboSkip1Radio.IsChecked = true;
                        break;
                    case 4:
                        this.turboSkip2Radio.IsChecked = true;
                        break;
                    case 6:
                        this.turboSkip3Radio.IsChecked = true;
                        break;
                    case 8:
                        this.turboSkip4Radio.IsChecked = true;
                        break;
                    case 10:
                        this.turboSkip5Radio.IsChecked = true;
                        break;
                }
#else
                switch (emuSettings.TurboFrameSkip)
                {
                    default:
                    case 1:
                        this.turboSkip1Radio.IsChecked = true;
                        break;
                    case 2:
                        this.turboSkip2Radio.IsChecked = true;
                        break;
                    case 3:
                        this.turboSkip3Radio.IsChecked = true;
                        break;
                    case 4:
                        this.turboSkip4Radio.IsChecked = true;
                        break;
                    case 5:
                        this.turboSkip5Radio.IsChecked = true;
                        break;
                }
#endif
                switch (emuSettings.PowerFrameSkip)
                {
                    default:
                    case 0:
                        this.powerSkip0Radio.IsChecked = true;
                        break;
                    case 1:
                        this.powerSkip1Radio.IsChecked = true;
                        break;
                    case 2:
                        this.powerSkip2Radio.IsChecked = true;
                        break;
                }
                switch (emuSettings.FrameSkip)
                {
                    case -1:
                        this.skipAutoRadio.IsChecked = true;
                        break;
                    default: 
                    case 0:
                        this.skip0Radio.IsChecked = true;
                        break;
                    case 1:
                        this.skip1Radio.IsChecked = true;
                        break;
                    case 2:
                        this.skip2Radio.IsChecked = true;
                        break;
                    case 3:
                        this.skip3Radio.IsChecked = true;
                        break;
                }

                switch (emuSettings.DPadStyle)
                {
                    default:
                    case 0:
                        this.dpadStandardRadio.IsChecked = true;
                        break;
                    case 1:
                        this.dpadFixedRadio.IsChecked = true;
                        break;
                    case 2:
                        this.dpadDynamicRadio.IsChecked = true;
                        break;
                }

                switch (emuSettings.CameraButtonAssignment)
                {
                    default:
                    case 0:
                        this.cameraTurboRadio.IsChecked = true;
                        break;
                    case 1:
                        this.cameraRRadio.IsChecked = true;
                        break;
                    case 2:
                        this.cameraLRadio.IsChecked = true;
                        break;
                }

                switch (emuSettings.AspectRatio)
                {
                    default:
                    case AspectRatioMode.Original:
                        this.aspect32Radio.IsChecked = true;
                        break;
                    case AspectRatioMode.Stretch:
                        this.aspectStretchRadio.IsChecked = true;
                        break;
                    case AspectRatioMode.FourToThree:
                        this.aspect43Radio.IsChecked = true;
                        break;
                    case AspectRatioMode.FiveToFour:
                        this.aspect54Radio.IsChecked = true;
                        break;
                    case AspectRatioMode.One:
                        this.aspect1Radio.IsChecked = true;
                        break;
                }
                initdone = true;
            };

        }

        private void vcontrollerPosSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.VirtualControllerOnTop = true;
            }
        }

        private void vcontrollerPosSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.VirtualControllerOnTop = false;
            }
        }

        private void enableSoundSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SoundEnabled = true;
            }
        }

        private void enableSoundSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SoundEnabled = false;
            }
        }

        private void lowFreqSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.LowFrequencyMode = true;
            }
        }

        private void lowFreqSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.LowFrequencyMode = false;
            }
        }

        private void opacitySlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ControllerOpacity = (int) this.opacitySlider.Value;
            }
        }

        private void scaleSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ControllerScale = (int)this.scaleSlider.Value;
            }
        }

        private void imageScaleSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ImageScaling = (int)this.imageScaleSlider.Value;
            }
        }

        private void syncSoundSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SynchronizeAudio = true;
            }
        }

        private void syncSoundSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SynchronizeAudio = false;
            }
        }

        private void deadzoneSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Deadzone = (float)this.deadzoneSlider.Value;
            }
        }

        private void confirmationSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideConfirmationDialogs = true;
            }
        }

        private void confirmationSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideConfirmationDialogs = false;
            }
        }

        private void autoIncSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AutoIncrementSavestates = true;
            }
        }

        private void autoIncSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AutoIncrementSavestates = false;
            }
        }

        private void confirmationLoadSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideLoadConfirmationDialogs = true;
            }
        }

        private void confirmationLoadSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideLoadConfirmationDialogs = false;
            }
        }

        private void restoreLastStateSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SelectLastState = true;
            }
        }

        private void restoreLastStateSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SelectLastState = false;
            }
        }

        private void cheatRestoreSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.RestoreOldCheatValues = true;
            }
        }

        private void cheatRestoreSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.RestoreOldCheatValues = false;
            }
        }

        private void manualSnapshotSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ManualSnapshots = true;
            }
        }

        private void manualSnapshotSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ManualSnapshots = false;
            }
        }

        private void cameraTurboRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.CameraButtonAssignment = 0;
            }
        }

        private void cameraRRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.CameraButtonAssignment = 1;
            }
        }

        private void cameraLRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.CameraButtonAssignment = 2;
            }
        }

        private void dpadStandardRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.DPadStyle = 0;
            }
        }

        private void dpadFixedRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.DPadStyle = 1;
            }
        }

        private void dpadDynamicRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.DPadStyle = 2;
            }
        }

        private void skipAutoRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FrameSkip = -1;
            }
        }

        private void skip0Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FrameSkip = 0;
            }
        }

        private void skip1Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FrameSkip = 1;
            }
        }

        private void skip2Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FrameSkip = 2;
            }
        }

        private void skip3Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FrameSkip = 3;
            }
        }

        private void powerSkip0Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.PowerFrameSkip = 0;
            }
        }

        private void powerSkip1Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.PowerFrameSkip = 1;
            }
        }

        private void powerSkip2Radio_Checked(object sender, RoutedEventArgs e)
        {

            if (this.initdone)
            {
                EmulatorSettings.Current.PowerFrameSkip = 2;
            }
        }

        private void turboSkip1Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
#if GBC
                EmulatorSettings.Current.TurboFrameSkip = 2;
#else
                EmulatorSettings.Current.TurboFrameSkip = 1;
#endif
            }
        }

        private void turboSkip2Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
#if GBC
                EmulatorSettings.Current.TurboFrameSkip = 4;
#else
                EmulatorSettings.Current.TurboFrameSkip = 2;
#endif
            }
        }

        private void turboSkip3Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
#if GBC
                EmulatorSettings.Current.TurboFrameSkip = 6;
#else
                EmulatorSettings.Current.TurboFrameSkip = 3;
#endif
            }
        }

        private void turboSkip4Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
#if GBC
                EmulatorSettings.Current.TurboFrameSkip = 8;
#else
                EmulatorSettings.Current.TurboFrameSkip = 4;
#endif
            }
        }

        private void turboSkip5Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
#if GBC
                EmulatorSettings.Current.TurboFrameSkip = 10;
#else
                EmulatorSettings.Current.TurboFrameSkip = 5;
#endif
            }
        }

        private void aspect32Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AspectRatio = AspectRatioMode.Original;
            }
        }

        private void aspectStretchRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AspectRatio = AspectRatioMode.Stretch;
            }
        }

        private void aspect43Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AspectRatio = AspectRatioMode.FourToThree;
            }
        }

        private void aspect54Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AspectRatio = AspectRatioMode.FiveToFour;
            }
        }

        private void aspect1Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AspectRatio = AspectRatioMode.One;
            }
        }

        private void orientationBothRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = 0;
            }
        }

        private void orientationLandscapeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = 1;
            }
        }

        private void orientationPortraitRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = 2;
            }
        }
    }
}