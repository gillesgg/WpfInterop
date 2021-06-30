#pragma once

#include "../NativeClient/NativeClient.h"

public ref class StubClient
{
	public:
		int Add(int x, int y)
		{
			return (x + y);
		}
		int Multiply(int x, int y)
		{
			CNativeClient m;

			

			return (m.Multiply(x, y));			
		}
		double PI(int digit)
		{
			CNativeClient m;
			return m.PI(digit);
		}
};


