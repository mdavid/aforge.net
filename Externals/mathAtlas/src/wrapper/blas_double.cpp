#include "stdafx.h"

extern "C"
{
	#include "cblas.h"

	__declspec(dllexport) void d_copy( const int n, const double* x, const int incX, double* y, const int incY )
	{
		cblas_dcopy( n, x, incX, y, incY );
	}
}


