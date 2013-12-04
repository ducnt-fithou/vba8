#pragma once

#include "Input.h"
#include "CXBOXController.h"
#include "EmulatorInput.h"

namespace Win8Snes9x
{
	class ControllerInput
		: public EmulatorInput
	{
	public:
		ControllerInput(int index);
		~ControllerInput(void);

		const ControllerState *GetControllerState(void);
		void Update(void);

	private:
		ControllerState state;
		CXBOXController *xboxPad;
	};
}