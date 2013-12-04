#pragma once

#include "Input.h"
#include "EmulatorInput.h"

using namespace Windows::UI::Core;

namespace Win8Snes9x
{
	class KeyboardInput
		: public EmulatorInput
	{		
	public:
		KeyboardInput(void);
		~KeyboardInput(void);

		const ControllerState *GetControllerState(void);
		void Update(void);

	private:
		ControllerState state;
		CoreWindow ^window;
	};
}