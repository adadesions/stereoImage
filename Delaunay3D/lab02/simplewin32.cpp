// simplewin32.cpp : Defines the entry point for the application.
//
#include <stdio.h>
#include    "simplewin32.h"
#define     MAX_LOADSTRING  100

#include <gl\gl.h>
#include <gl\glu.h>
#include <iostream>
#include <fstream>



// Global Variables:
HINSTANCE   hInst;                          // current instance
char        szTitle [MAX_LOADSTRING];       // The title bar text
char        szWindowClass [MAX_LOADSTRING]; // the main window class name

// Forward declarations of functions included in this code module:
ATOM                    RegisterMainClass (HINSTANCE hInstance);
BOOL                    InitInstance (HINSTANCE, int);
LRESULT CALLBACK        WndProc (HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK        About (HWND, UINT, WPARAM, LPARAM);

HWND			hWndText;
char			szText [241];
unsigned char	*image	= NULL;			// image array
long			 bpp, cx = 0, cy = 0;	// image dimension
BITMAPINFO		 bi;

// OpenGL related variables
#define clamp(x) x = x > 360.0f ? x-360.0f : x < -360.0f ? x+=360.0f : x

HWND		m_hWnd	= NULL;
HDC			m_hDC	= NULL;
HGLRC		m_hRC	= NULL;
float		m_rot [2] = {0.0f, 0.0f}, m_zdist = -2.0f, m_px = 0.0, m_py = 0.0;
int			m_nDrag = 0;
int			m_elapse = 0;	

using namespace std;
static GLuint texName;
ifstream pointflie, matrixflie, PixelFileR, PixelFileG, PixelFileB, DepthFile;
double point[37][3], matrix[37][37], pixelR[365][355], pixelG[365][355], pixelB[365][355];
float Depthpixel[365][355];

int APIENTRY _tWinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                        LPTSTR lpCmdLine,
                        int nCmdShow)
{
    MSG     msg;
    HACCEL  hAccelTable;

    // Initialize global strings
    strcpy (szTitle, "Computer Graphic 423206");
    strcpy (szWindowClass, "simplewin32");
    RegisterMainClass (hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow)) 
    {
        return FALSE;
    }

    hAccelTable = LoadAccelerators (hInstance, MAKEINTRESOURCE (IDC_SIMPLEWIN32));

    // Main message loop:
    while (GetMessage (&msg, NULL, 0, 0)) 
    {
        if (!TranslateAccelerator (msg.hwnd, hAccelTable, &msg)) 
        {
            TranslateMessage (&msg);
            DispatchMessage (&msg);
        }
    }

    return (int) msg.wParam;
}

void resize (int cx, int cy)
{
    ::glMatrixMode (GL_PROJECTION);
    ::glLoadIdentity ();

    ::gluPerspective (30.0, (float) cx/cy, 0.001, 40.0);
    ::glViewport (0, 0, cx, cy);

    ::glMatrixMode (GL_MODELVIEW);
    ::glLoadIdentity ();

    ::glEnable (GL_DEPTH_TEST);
    ::glDepthFunc (GL_LESS);
}

void initlighting (void)
{
    //  initalize light
    GLfloat ambient [4]     = {  0.20f, 0.20f, 0.20f, 0.5f };
    GLfloat diffuse [4]     = {  0.80f, 0.80f, 0.80f, 0.9f };
    GLfloat position0 []    = { -0.2f, 0.5f, +5.0f, 0.0f };
    GLfloat position1 []    = { -0.2f, 0.5f, -5.0f, 0.0f };

    GLfloat materialShininess [1]   = { 8.0f };

    // enable all the lighting & depth effects
    ::glLightfv (GL_LIGHT0, GL_AMBIENT, ambient);
    ::glLightfv (GL_LIGHT0, GL_DIFFUSE, diffuse);
    ::glLightfv (GL_LIGHT0, GL_POSITION, position0);

    ::glLightfv (GL_LIGHT1, GL_AMBIENT, ambient);
    ::glLightfv (GL_LIGHT1, GL_DIFFUSE, diffuse);
    ::glLightfv (GL_LIGHT1, GL_POSITION, position1);

	::glShadeModel (GL_FLAT);
    ::glMaterialfv (GL_FRONT_AND_BACK, GL_SHININESS, materialShininess);

    ::glEnable (GL_LIGHTING);
    ::glEnable (GL_LIGHT0);
	::glEnable (GL_LIGHT1);

    ::glEnable (GL_BLEND);
    ::glBlendFunc (GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
    ::glEnable (GL_LINE_SMOOTH);
}

void initopengl (void)
{
    PIXELFORMATDESCRIPTOR   pfd;
    int                     format;
    RECT                    rcclient;

    m_hDC   =   GetDC (m_hWnd);

    // set the pixel format for the DC
    ZeroMemory (&pfd, sizeof (pfd));
    pfd.nSize       = sizeof (pfd);
    pfd.nVersion    = 1;
    pfd.dwFlags     = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER;
    pfd.iPixelType  = PFD_TYPE_RGBA;
    pfd.cColorBits  = 16;
    pfd.cDepthBits  = 32;
    pfd.iLayerType  = PFD_MAIN_PLANE;

    format = ChoosePixelFormat (m_hDC, &pfd);
    SetPixelFormat (m_hDC, format, &pfd);

    // create the render context (RC)
    m_hRC = wglCreateContext (m_hDC);

    // make it the current render context
    wglMakeCurrent (m_hDC, m_hRC);

    GetClientRect (m_hWnd, &rcclient);

    resize (rcclient.right, rcclient.bottom);
    initlighting ();
}

void purge (void)
{
    if (m_hRC) {
        wglMakeCurrent (NULL, NULL);
        wglDeleteContext (m_hRC);
    }

	if (m_hWnd && m_hDC) {
        ReleaseDC (m_hWnd, m_hDC);
    }

    m_hDC           = NULL;
    m_hRC           = NULL;
}

void recoverRigidDisplay (void)
{
    ::glTranslatef (-0.1f, 0.3f, m_zdist);
	::glRotatef(180.0f, 1.0f, 0.0f, 0.0f);
    ::glRotatef (m_rot [0], 1.0f, 0.0f, 0.0f);
    ::glRotatef (m_rot [1], 0.0f, 1.0f, 0.0f);
}

void drawaxes (void)
{
    ::glDisable (GL_LIGHTING);
    ::glBegin (GL_LINES);
    ::glColor3f (1.0f, 0.0f, 0.0f);     //  X : R
    ::glVertex3f (0.0f, 0.0f, 0.0f);
    ::glVertex3f (1.0f, 0.0f, 0.0f);
    ::glVertex3f (0.0f, 1.0f, 0.0f);
    ::glVertex3f (1.0f, 1.0f, 0.0f);

    ::glColor3f (1.0f, 1.0f, 0.0f);     //  Y : Y
    ::glVertex3f (0.0f, 0.0f, 0.0f);
    ::glVertex3f (0.0f, 1.0f, 0.0f);
    ::glVertex3f (1.0f, 0.0f, 0.0f);
    ::glVertex3f (1.0f, 1.0f, 0.0f);

    ::glColor3f (0.0f, 0.0f, 1.0f);     //  Z : B
    ::glVertex3f (0.0f, 0.0f, 0.0f);
    ::glVertex3f (0.0f, 0.0f, 1.0f);
    ::glEnd ();

    ::glColor3f (1.0f, 1.0f, 1.0f);
    ::glEnable (GL_LIGHTING);
}

void mouse_update (float cx, float cy)
{
    if (m_nDrag == 1)
	{
		m_rot [0] += ((cy - m_py) * 0.1f);
		m_rot [1] -= ((cx - m_px) * 0.1f);

		clamp (m_rot[0]);
		clamp (m_rot[1]);
	}
	else
	{
		m_zdist += (cy - m_py)*0.02f;
	}

    m_px = cx;
    m_py = cy;
}

void Draw_Point()
{
	//glDisable(GL_LIGHTING);
	double i;
	int c = 0;

	pointflie.open("PointFace/PointFaceCropAverageXYZ.txt");

	while (pointflie >> i) {
		if (c % 3 == 0)
			point[c / 3][0] = i / 1000; //set as x-cord.

		else if (c % 3 == 1)
			point[c / 3][1] = i / 1000; //set as y-cord.

		else
			point[c / 3][2] = -((i / 1000) * 10); //set as z-cord.


		glPointSize(3.0);
		if (point[c / 3][0] && point[c / 3][1] && point[c / 3][2])
		{
			glBegin(GL_POINTS);
			//
			glColor3f(0.0, 0.0, 1.0);
			glNormal3f(0.0, 0.0, 1.0);
			glVertex3f(point[c / 3][0], point[c / 3][1], point[c / 3][2]);
			glEnd();
			//cout << point[1][2] << endl;

		}
		c++;
		//cout <<c;
		glEnable(GL_LIGHTING);
	}
}

void AdjacencyMatrix()
{
	//glDisable(GL_LIGHTING);
	int m = 1, k;

	matrixflie.open("AdjacencyMatrix.txt");

	while (matrixflie >> k) {
		if (m % 37 == 1) { //if i is the first integer in a row
			matrix[m / 37][0] = k;
		}
		else if (m % 37 == 2) {
			matrix[m / 37][1] = k;
		}
		else if (m % 37 == 3) {
			matrix[m / 37][2] = k;
		}
		else if (m % 37 == 4) {
			matrix[m / 37][3] = k;
		}
		else if (m % 37 == 5) {
			matrix[m / 37][4] = k;
		}
		else if (m % 37 == 6) {
			matrix[m / 37][5] = k;
		}
		else if (m % 37 == 7) {
			matrix[m / 37][6] = k;
		}
		else if (m % 37 == 8) {
			matrix[m / 37][7] = k;
		}
		else if (m % 37 == 9) {
			matrix[m / 37][8] = k;
		}
		else if (m % 37 == 10) {
			matrix[m / 37][9] = k;
		}
		else if (m % 37 == 11) {
			matrix[m / 37][10] = k;
		}
		else if (m % 37 == 12) {
			matrix[m / 37][11] = k;
		}
		else if (m % 37 == 13)
		{
			matrix[m / 37][12] = k;
		}
		else if (m % 37 == 14) {
			matrix[m / 37][13] = k;
		}
		else if (m % 37 == 15) {
			matrix[m / 37][14] = k;
		}
		else if (m % 37 == 16) {
			matrix[m / 37][15] = k;
		}
		else if (m % 37 == 17) {
			matrix[m / 37][16] = k;
		}
		else if (m % 37 == 18) {
			matrix[m / 37][17] = k;
		}
		else if (m % 37 == 19) {
			matrix[m / 37][18] = k;
		}
		else if (m % 37 == 20) {
			matrix[m / 37][19] = k;
		}
		else if (m % 37 == 21) {
			matrix[m / 37][20] = k;
		}
		else if (m % 37 == 22) {
			matrix[m / 37][21] = k;
		}
		else if (m % 37 == 23) {
			matrix[m / 37][22] = k;
		}
		else if (m % 37 == 24) {
			matrix[m / 37][23] = k;
		}
		else if (m % 37 == 25) {
			matrix[m / 37][24] = k;
		}
		else if (m % 37 == 26) {
			matrix[m / 37][25] = k;
		}
		else if (m % 37 == 27) {
			matrix[m / 37][26] = k;
		}
		else if (m % 37 == 28) {
			matrix[m / 37][27] = k;
		}
		else if (m % 37 == 29) {
			matrix[m / 37][28] = k;
		}
		else if (m % 37 == 30) {
			matrix[m / 37][29] = k;
		}
		else if (m % 37 == 31) {
			matrix[m / 37][30] = k;
		}
		else if (m % 37 == 32) {
			matrix[m / 37][31] = k;
		}
		else if (m % 37 == 33) {
			matrix[m / 37][32] = k;
		}
		else if (m % 37 == 34) {
			matrix[m / 37][33] = k;
		}
		else if (m % 37 == 35) {
			matrix[m / 37][34] = k;
		}
		else if (m % 37 == 36) {
			matrix[m / 37][35] = k;
		}
		else if (m % 37 == 0) {
			matrix[(m - 1) / 37][36] = k;
		}
		//cout << k;		
		m++;
	}

	glLineWidth(3.0);
	for (int matrixRow = 0; matrixRow < 37; matrixRow++) { //row	
		for (int matrixCol = 0; matrixCol < 37; matrixCol++) { //column
			if ((matrix[matrixRow][matrixCol] == 1)) {
				glBegin(GL_LINES);
				glColor3f(0.0, 1.0, 0.0);
				glVertex3f(point[matrixRow][0], point[matrixRow][1], point[matrixRow][2]);
				glVertex3f(point[matrixCol][0], point[matrixCol][1], point[matrixCol][2]);
			}
		}
	}
	glEnd();
	glEnable(GL_LIGHTING);
}

void display (void)
{
    ::glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    ::glPushMatrix ();
	
	recoverRigidDisplay ();
	//drawaxes ();
	glDisable(GL_LIGHTING);
	Draw_Point();
	AdjacencyMatrix();
	glEnable(GL_LIGHTING);
    ::glFlush();
    ::glPopMatrix ();

    ::SwapBuffers (m_hDC);          /* nop if singlebuffered */
}

ATOM RegisterMainClass (HINSTANCE hInstance)
{
    WNDCLASSEX  wcex;

    wcex.cbSize = sizeof (WNDCLASSEX); 

    wcex.style              = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc        = (WNDPROC)WndProc;
    wcex.cbClsExtra         = 0;
    wcex.cbWndExtra         = 0;
    wcex.hInstance          = hInstance;
    wcex.hIcon              = LoadIcon (hInstance, (LPCTSTR) IDI_SIMPLEWIN32);
    wcex.hCursor            = LoadCursor (NULL, IDC_ARROW);
    wcex.hbrBackground      = (HBRUSH) (COLOR_WINDOW+1);
    wcex.lpszMenuName       = (LPCTSTR) IDC_SIMPLEWIN32;
    wcex.lpszClassName      = szWindowClass;
    wcex.hIconSm            = LoadIcon (wcex.hInstance, (LPCTSTR) IDI_SMALL);

    return RegisterClassEx (&wcex);
}

BOOL InitInstance (HINSTANCE hInstance, int nCmdShow)
{
    hInst   = hInstance; // Store instance handle in our global variable
    m_hWnd	= CreateWindow (szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
                            0, 0, 710, 730, NULL, NULL, hInstance, NULL);

	if (!m_hWnd)
    {
        return FALSE;
    }

    ShowWindow (m_hWnd, nCmdShow);
	UpdateWindow (m_hWnd);
	initopengl ();
	SetTimer (m_hWnd, 100, 300, NULL);

    return TRUE;
}

void mydraw (HDC hdc)
{
	if (image == NULL) return;

	SetDIBitsToDevice (hdc, 0, 0, cx, cy, 0, 0, 0, cy, 
					   image, &bi, DIB_RGB_COLORS);
}

void process (unsigned char *ig, long w, long h)
{
	int	r = 0, g = 255, b = 0;
	int x, y;

//	ig [3*(10 + 100*w)+0] = 255;

	for (y = 0; y < h; y ++)
		for (x = 0; x < w; x ++) {
			ig [3*(x + y*w) + 0] = y;
			ig [3*(x + y*w) + 1] = g;
			ig [3*(x + y*w) + 2] = x;
		}
}

void initfbuffer (int w, int h)
{
	bi.bmiHeader.biSize			= sizeof (BITMAPINFOHEADER);
	bi.bmiHeader.biWidth		= w;
	bi.bmiHeader.biHeight		= -h;
	bi.bmiHeader.biPlanes		= 1;
	bi.bmiHeader.biBitCount		= 24;
	bi.bmiHeader.biCompression	= BI_RGB;
	bi.bmiHeader.biSizeImage	= w*h*3;

	bi.bmiHeader.biXPelsPerMeter	= 0;
	bi.bmiHeader.biYPelsPerMeter	= 0;
	bi.bmiHeader.biClrUsed			= 0;
	bi.bmiHeader.biClrImportant		= 0;

	cx		= w;
	cy		= h;
	image	= (unsigned char *) malloc (cx*cy*3);
	memset (image, 0, w*h*3);
}

//
//  FUNCTION: WndProc(HWND, unsigned, WORD, LONG)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//

LRESULT CALLBACK WndProc (HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    int         wmId, wmEvent;
	int			tm;
/*    PAINTSTRUCT ps;
    HDC         hdc;
*/
    switch (message) 
    {
		case WM_TIMER	:	if (wParam == 100) {
								display ();
								m_elapse ++;
								m_elapse = m_elapse % 21;
							}
							break;

		case WM_COMMAND :   wmId    = LOWORD (wParam);
                            wmEvent = HIWORD (wParam);

                            // Parse the menu selections:
                            switch (wmId)
                            {
                                case IDM_ABOUT  :   DialogBox (hInst, (LPCTSTR) IDD_ABOUTBOX, hWnd, (DLGPROC) About);
                                                    break;

								case IDM_EXIT   :   initopengl ();
													/*initfbuffer (320, 240);
													process (image, 320, 240);
													hdc = GetDC (hWnd);
													mydraw (hdc);
													ReleaseDC (hWnd, hdc);
													*/
													break;
                                                       
                                default         :   
                                                    return DefWindowProc(hWnd, message, wParam, lParam);
                            }
                            break;
/*
        case WM_PAINT   :   display ();
							break;
*/
		case WM_LBUTTONDOWN :   SetCapture (m_hWnd);
								m_px    =   (float) LOWORD (lParam);
                                m_py    =   (float) HIWORD (lParam);
                                m_nDrag = 1;
                                break;

        case WM_LBUTTONUP   :   ReleaseCapture ();
                                m_px    = 0.0f;
                                m_py    = 0.0f;
                                m_nDrag = 0;
								display ();
                                break;

        case WM_RBUTTONDOWN :   SetCapture (m_hWnd);
                                m_px    =   (float) LOWORD (lParam);
                                m_py    =   (float) HIWORD (lParam);
                                m_nDrag = 2;
                                break;

        case WM_RBUTTONUP   :   ReleaseCapture ();
                                m_px    = 0.0f;
                                m_py    = 0.0f;
                                m_nDrag = 0;
								display ();
                                break;

        case WM_MOUSEMOVE   :   if (m_nDrag)
                                {
                                    int mx, my;

                                    mx = LOWORD (lParam);
                                    my = HIWORD (lParam);

                                    if (mx & (1 << 15)) mx -= (1 << 16);
                                    if (my & (1 << 15)) my -= (1 << 16);

                                    mouse_update ((float) mx, (float) my);
                                    display ();
                                }
                                break;

        case WM_DESTROY :	purge ();//if (image != NULL) free (image);
							PostQuitMessage (0);
							KillTimer (m_hWnd, 100);
                            break;

        default         :   return DefWindowProc (hWnd, message, wParam, lParam);
    }
    return 0;
}

// Message handler for about box.
LRESULT CALLBACK About (HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
        case WM_INITDIALOG  :   return TRUE;

        case WM_COMMAND     :   if (LOWORD (wParam) == IDOK || LOWORD (wParam) == IDCANCEL)
                                {
                                    EndDialog (hDlg, LOWORD (wParam));
                                    return TRUE;
                                }
                                break;
    }
    return FALSE;
}

LRESULT CALLBACK Event (HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
        case WM_INITDIALOG  :   return TRUE;

        case WM_COMMAND     :   if (LOWORD (wParam) == IDOK || LOWORD (wParam) == IDCANCEL)
                                {
                                    EndDialog (hDlg, LOWORD (wParam));
                                    return TRUE;
                                }
                                break;
    }
    return FALSE;
}

