#pragma once

#include "Input.h"

namespace Win8Snes9x
{
	class EmulatorInput
	{
	public:
		virtual ~EmulatorInput(void) { }

		const virtual ControllerState *GetControllerState(void) = 0;

		virtual void Update(void) = 0;
	};
}
