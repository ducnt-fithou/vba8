#include "vbam/System.h"
#include "EmulatorSettings.h"
#include "VirtualController.h"

using namespace Emulator;
using namespace PhoneDirect3DXamlAppComponent;

bool enableTurboMode = false;

void log(const char *,...) { }

void winSignal(int, int) { }

void winOutput(const char *s, u32 addr) { }

void (*dbgSignal)(int,int) = winSignal;
void (*dbgOutput)(const char *, u32) = winOutput;

bool systemPauseOnFrame() { return false; }
void systemGbPrint(u8 *,int,int,int,int) { }
void systemScreenCapture(int) { }
// updates the joystick data
bool systemReadJoypads() { return true; }
u32 systemGetClock() { return (u32) GetTickCount64(); }
void systemMessage(int, const char *, ...) { }
void systemSetTitle(const char *) { }
void systemWriteDataToSoundBuffer() { }
void systemSoundShutdown() { }
void systemSoundPause() { }
void systemSoundResume() { }
void systemSoundReset() { }
//SoundDriver *systemSoundInit() { return NULL; }
void systemScreenMessage(const char *) { }
void systemUpdateMotionSensor() { }
int  systemGetSensorX() { return 0; }
int  systemGetSensorY() { return 0; }
bool systemCanChangeSoundQuality() { return false; }
void systemShowSpeed(int){ }
void system10Frames(int){ }
void systemFrame(){ }
void systemGbBorderOn(){ }
void winlog(const char *, ...) { }
void systemOnWriteDataToSoundBuffer(const u16 * finalWave, int length) { }
void systemOnSoundShutdown() { }
extern SoundDriver *newXAudio2_Output();
extern void soundShutdown();
void systemGbPrint(unsigned char *, int, int, int, int, int) { }

SoundDriver * systemSoundInit()
{
	SoundDriver * drv = 0;
	soundShutdown();

	if(EmulatorSettings::Current->SoundEnabled)
	{	
		drv = newXAudio2_Output();
	}

	return drv;
}

u32 systemReadJoypad(int gamepad) 
{ 
	u32 res = 0;

	VirtualController *controller = VirtualController::GetInstance();
	if(!controller)
		return res;

	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;
	bool start = false;
	bool select = false;
	bool a = false;
	bool b = false;
	bool l = false;
	bool r = false;


	const Emulator::ControllerState *state = controller->GetControllerState();

	if(state->APressed || a)
		res |= 1;
	if(state->BPressed || b)
		res |= 2;
	if(state->SelectPressed || select)
		res |= 4;
	if(state->StartPressed || start)
		res |= 8;
	if(state->RightPressed || right)
		res |= 16;
	if(state->LeftPressed || left)
		res |= 32;
	if(state->UpPressed || up)
		res |= 64;
	if(state->DownPressed || down)
		res |= 128;

	// disallow L+R or U+D of being pressed at the same time
	if((res & 48) == 48)
		res &= ~16;
	if((res & 192) == 192)
		res &= ~128;

	EmulatorSettings ^settings = EmulatorSettings::Current;
	
	if(settings->CameraButtonAssignment == 0)
	{
		if(enableTurboMode && !settings->IsTrial)
		{ 
			// Speed
			res |= 1024;
		}
		if(state->RPressed | r)
			res |= 256;
		if(state->LPressed | l)
			res |= 512;
	}else if(settings->CameraButtonAssignment == 1)
	{
		if(enableTurboMode)
		{ 
			// R Button
			res |= 256;
		}
		if((state->RPressed | r) && !settings->IsTrial)
			res |= 1024;
		if(state->LPressed | l)
			res |= 512;
	}else if(settings->CameraButtonAssignment == 2)
	{
		if(enableTurboMode)
		{ 
			// L Button
			res |= 512;
		}
		if(state->RPressed | r)
			res |= 256;
		if((state->LPressed | l) && !settings->IsTrial)
			res |= 1024;
	}else if(settings->CameraButtonAssignment == 3)
	{
		if(enableTurboMode)
		{ 
			// L + R Button
			res |= 512;
			res |= 256;
		}
		if((state->LPressed || state->RPressed || l || r) && !settings->IsTrial)
			res |= 1024;
	}

	return res;
}

int RGB_LOW_BITS_MASK = 65793;
int emulating;
bool systemSoundOn;
u16 systemColorMap16[0x10000];
u32 systemColorMap32[0x10000];
u16 systemGbPalette[24];
int systemRedShift;
int systemGreenShift;
int systemBlueShift;
int systemColorDepth;
int systemDebug;
int systemVerbose;
int systemFrameSkip;
int systemSaveUpdateCounter;