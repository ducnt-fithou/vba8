//
// HelpSettingsPane.xaml.cpp
// Implementation of the HelpSettingsPane class
//

#include "pch.h"
#include "AboutSettingsPane.xaml.h"

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

AboutSettingsPane::AboutSettingsPane()
{ 
	InitializeComponent();

#ifdef GBC
	this->appnameBlock->Text = "VGBC8";
	this->versionBlock->Text = "Version: 1.1";
	this->contactBlock->Text = "vgbc8dev@gmail.com";
#endif
}

void Win8Snes9x::AboutSettingsPane::BackClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	if(this->Parent->GetType() == Popup::typeid)
	{
		(safe_cast<Popup ^>(this->Parent))->IsOpen = false;
	}
	SettingsPane::Show();
}


void Win8Snes9x::AboutSettingsPane::gplButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Windows::Foundation::Uri("http://www.gnu.org/licenses/gpl-3.0.txt"));
}


void Win8Snes9x::AboutSettingsPane::sourceButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
	Windows::System::Launcher::LaunchUriAsync(ref new Windows::Foundation::Uri("http://sdrv.ms/10ehg2a"));
}
