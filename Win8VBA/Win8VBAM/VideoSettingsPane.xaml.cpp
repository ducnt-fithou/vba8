//
// VideoSettingsPane.xaml.cpp
// Implementation of the VideoSettingsPane class
//

#include "pch.h"
#include "VideoSettingsPane.xaml.h"
#include "EmulatorSettings.h"
#include <string>
#include <sstream>

using namespace std;

using namespace Win8Snes9x;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

VideoSettingsPane::VideoSettingsPane()
	: emulator(EmulatorGame::GetInstance()), initDone(false)
{
	InitializeComponent();
	//this->fpsToggle->IsOn = ShowingFPS();
	//this->hzToggle->IsOn = LowDisplayRefreshModeActivated();
	this->skipComboBox->SelectedIndex = (GetFrameSkip() + 1 < this->skipComboBox->Items->Size) ? (GetFrameSkip() + 1) : (this->skipComboBox->Items->Size - 1);
	this->turboSkipComboBox->SelectedIndex = (GetTurboFrameSkip() - 1 < this->turboSkipComboBox->Items->Size) ? (GetTurboFrameSkip() - 1) : (this->turboSkipComboBox->Items->Size - 1);
	this->powerSkipComboBox->SelectedIndex = (GetPowerFrameSkip() > this->powerSkipComboBox->Items->Size) ? (this->powerSkipComboBox->Items->Size - 1) : GetPowerFrameSkip();
	this->monitorComboBox->SelectedIndex = GetMonitorType();
	switch(GetAspectRatio())
	{
	default:
	case AspectRatioMode::Original:
		this->aspectComboBox->SelectedIndex = 0;
		break;
	case AspectRatioMode::Stretch:
		this->aspectComboBox->SelectedIndex = 1;
		break;
	case AspectRatioMode::FourToThree:
		this->aspectComboBox->SelectedIndex = 2;
		break;
	case AspectRatioMode::FiveToFour:
		this->aspectComboBox->SelectedIndex = 3;
		break;
	case AspectRatioMode::One:
		this->aspectComboBox->SelectedIndex = 4;
		break;
	}
	this->imageScaleSlider->Value = (double) GetImageScale();
	initDone = true;
}

void Win8Snes9x::VideoSettingsPane::BackClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if(this->Parent->GetType() == Popup::typeid)
	{
		(safe_cast<Popup ^>(this->Parent))->IsOpen = false;
	}
	SettingsPane::Show();
}

void Win8Snes9x::VideoSettingsPane::fpsToggle_Toggled(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if(initDone)
	{
		//ShowFPS(this->fpsToggle->IsOn);
	}
}


//void Win8Snes9x::VideoSettingsPane::hzToggle_Toggled(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
//{
//	if(initDone)
//	{
//		EnableLowDisplayRefreshMode(this->hzToggle->IsOn);
//	}
//}


void Win8Snes9x::VideoSettingsPane::imageScaleSlider_ValueChanged_1(Platform::Object^ sender, Windows::UI::Xaml::Controls::Primitives::RangeBaseValueChangedEventArgs^ e)
{
	if(this->valueLabel)
	{
		wstringstream wss;
		wss << (int) e->NewValue;

		this->valueLabel->Text = ref new String(wss.str().c_str());

		if(initDone)
		{
			SetImageScale(e->NewValue);
		}
	}
}


void Win8Snes9x::VideoSettingsPane::skipComboBox_SelectionChanged_1(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
	if(initDone)
	{
		SetFrameSkip(this->skipComboBox->SelectedIndex - 1);
	}
}


void Win8Snes9x::VideoSettingsPane::turboSkipComboBox_SelectionChanged_1(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
	if(initDone)
	{
		SetTurboFrameSkip(this->turboSkipComboBox->SelectedIndex + 1);
	}
}

void Win8Snes9x::VideoSettingsPane::powerSkipComboBox_SelectionChanged_1(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
	if(initDone)
	{
		SetPowerFrameSkip(this->powerSkipComboBox->SelectedIndex);
	}
}


void Win8Snes9x::VideoSettingsPane::aspectComboBox_SelectionChanged_1(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
	if(initDone)
	{
		AspectRatioMode mode = AspectRatioMode::Original;
		switch(this->aspectComboBox->SelectedIndex)
		{
		case 0:
			mode = AspectRatioMode::Original;
			break;
		case 1:
			mode = AspectRatioMode::Stretch;
			break;
		case 2:
			mode = AspectRatioMode::FourToThree;
			break;
		case 3:
			mode = AspectRatioMode::FiveToFour;
			break;
		case 4:
			mode = AspectRatioMode::One;
		}
		SetAspectRatio(mode);
	}
}


void Win8Snes9x::VideoSettingsPane::monitorComboBox_SelectionChanged_1(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
	if(initDone)
	{
		SetMonitorType(this->monitorComboBox->SelectedIndex);
	}
}
