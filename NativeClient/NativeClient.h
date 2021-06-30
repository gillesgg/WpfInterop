// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the NATIVECLIENT_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// NATIVECLIENT_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef NATIVECLIENT_EXPORTS
#define NATIVECLIENT_API __declspec(dllexport)
#else
#define NATIVECLIENT_API __declspec(dllimport)
#endif

// This class is exported from the dll
class NATIVECLIENT_API CNativeClient {
public:
	CNativeClient(void);
	int Multiply(int x, int y);
	double PI(int digit);
};
