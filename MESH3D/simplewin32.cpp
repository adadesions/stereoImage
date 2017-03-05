#include <windows.h>		// Header File For Windows
#include <stdio.h>			// Header File For Standard Input/Output
#include <gl\gl.h>			// Header File For The OpenGL32 Library
#include <gl\glu.h>			// Header File For The GLu32 Library
#include <glut.h>
#include "SOIL.h"
#include <iostream>
#include <fstream>

HDC			hDC = NULL;		// Private GDI Device Context
HGLRC		hRC = NULL;		// Permanent Rendering Context
HWND		hWnd = NULL;		// Holds Our Window Handle
HINSTANCE	hInstance;		// Holds The Instance Of The Application
bool	keys[256];			// Array Used For The Keyboard Routine
bool	active = TRUE;		// Window Active Flag Set To TRUE By Default
bool	fullscreen = TRUE;	// Fullscreen Flag Set To Fullscreen Mode By Default

GLfloat	xrot;				// X Rotation ( NEW )
GLfloat	yrot;				// Y Rotation ( NEW )
GLfloat	zrot;				// Z Rotation ( NEW )

GLfloat xspeed;                     // X Rotation Speed
GLfloat yspeed;                     // Y Rotation Speed

GLfloat z = -5.0f;                    // Depth Into The Screen

GLfloat LightAmbient[] = { 0.5f, 0.5f, 0.5f, 1.0f };    // Ambient Light Values
GLfloat LightDiffuse[] = { 1.0f, 1.0f, 1.0f, 1.0f };    // Diffuse Light Values
GLfloat LightPosition[] = { 0.0f, 0.0f, 2.0f, 1.0f };    // Light Position
#define clamp(x) x = x > 360.0f ? x-360.0f : x < -360.0f ? x+=360.0f : x
float		m_rot[2] = { 0.0f, 0.0f }, m_zdist = -2.7f, m_px = 0.0, m_py = 0.0;
int			m_elapse = 0;
GLuint	texture[3];			// Storage For One Texture ( NEW )
int			m_nDrag = 0;
LRESULT	CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);	// Declaration For WndProc

using namespace std;
ifstream pointflie, matrixflie, PixelFlie;
double point[37][3], matrix[37][37], pixel[355][365];

int LoadGLTextures()									// Load Bitmaps And Convert To Textures
{
	/* load an image file directly as a new OpenGL texture */
	texture[0] = SOIL_load_OGL_texture
		(
			"Data/depth180.png",
			SOIL_LOAD_AUTO,
			SOIL_CREATE_NEW_ID,
			SOIL_FLAG_INVERT_Y
		);

	if (texture[0] == 0)
		return false;


	// Typical Texture Generation Using Data From The Bitmap
	glBindTexture(GL_TEXTURE_2D, texture[0]);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	return true;										// Return Success
}

void initlighting(void)
{
	//  initalize light
	GLfloat ambient[4] = { 0.20f, 0.20f, 0.20f, 0.5f };
	GLfloat diffuse[4] = { 0.80f, 0.80f, 0.80f, 0.9f };
	GLfloat position0[] = { -2.0f, 0.5f, 0.5f, 1.0f };
	GLfloat position1[] = { -2.0f, 0.0f, -0.5f, 1.0f };
	GLfloat position2[] = { 1.0f, 0.0f, -6.0f, 1.0f };
	GLfloat position3[] = { -1.0f, 0.0f, -6.0f, 1.0f };

	GLfloat materialShininess[1] = { 8.0f };

	// enable all the lighting & depth effects
	::glLightfv(GL_LIGHT0, GL_AMBIENT, ambient);
	::glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuse);
	::glLightfv(GL_LIGHT0, GL_POSITION, position0);

	::glLightfv(GL_LIGHT1, GL_AMBIENT, ambient);
	::glLightfv(GL_LIGHT1, GL_DIFFUSE, diffuse);
	::glLightfv(GL_LIGHT1, GL_POSITION, position1);

	::glLightfv(GL_LIGHT2, GL_AMBIENT, ambient);
	::glLightfv(GL_LIGHT2, GL_DIFFUSE, diffuse);
	::glLightfv(GL_LIGHT2, GL_POSITION, position2);

	::glLightfv(GL_LIGHT3, GL_AMBIENT, ambient);
	::glLightfv(GL_LIGHT3, GL_DIFFUSE, diffuse);
	::glLightfv(GL_LIGHT3, GL_POSITION, position3);

	::glShadeModel(GL_SMOOTH);
	::glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, materialShininess);

	::glEnable(GL_LIGHTING);
	::glEnable(GL_LIGHT0);
	::glEnable(GL_LIGHT1);
	::glEnable(GL_LIGHT2);
	::glEnable(GL_LIGHT3);

	::glEnable(GL_BLEND);
	::glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	::glEnable(GL_LINE_SMOOTH);

}

void mouse_update(float cx, float cy)
{
	if (m_nDrag == 1)
	{
		xrot += ((cy - m_py) * 0.08f);
		yrot -= ((cx - m_px) * 0.08f);

		clamp(xrot);
		clamp(yrot);
	}
	else
	{
		m_zdist += (cy - m_py)*0.04f;
	}

	m_px = cx;
	m_py = cy;
}

void purge(void)
{
	if (hRC) {
		wglMakeCurrent(NULL, NULL);
		wglDeleteContext(hRC);
	}

	if (hWnd && hDC) {
		ReleaseDC(hWnd, hDC);
	}

	hDC = NULL;
	hRC = NULL;
}

void recoverRigidDisplay(void)
{
	::glTranslatef(-0.15f, 0.15f, m_zdist);
	::glRotatef(180.0f, 1.0f, 0.0f, 0.0f);
	::glRotatef(xrot, 1.0f, 0.0f, 0.0f);
	::glRotatef(yrot, 0.0f, 1.0f, 0.0f);
}

GLvoid ReSizeGLScene(GLsizei width, GLsizei height)		// Resize And Initialize The GL Window
{
	if (height == 0)										// Prevent A Divide By Zero By
	{
		height = 1;										// Making Height Equal One
	}

	glViewport(0, 1, width, height);						// Reset The Current Viewport //ตั้งค่า View

	glMatrixMode(GL_PROJECTION);						// Select The Projection Matrix
	glLoadIdentity();									// Reset The Projection Matrix

														// Calculate The Aspect Ratio Of The Window
	gluPerspective(20.0f, (GLfloat)width / (GLfloat)height, 0.1f, 100.0f);

	glMatrixMode(GL_MODELVIEW);							// Select The Modelview Matrix
	glLoadIdentity();									// Reset The Modelview Matrix
}

int InitGL(GLvoid)										// All Setup For OpenGL Goes Here
{
	if (!LoadGLTextures())								// Jump To Texture Loading Routine ( NEW )
	{
		return FALSE;									// If Texture Didn't Load Return FALSE
	}

	glEnable(GL_TEXTURE_2D);							// Enable Texture Mapping ( NEW )
	glShadeModel(GL_SMOOTH);							// Enable Smooth Shading
	glClearColor(0.0f, 0.0f, 0.0f, 0.5f);				// Black Background
	glClearDepth(1.0f);									// Depth Buffer Setup
	glEnable(GL_DEPTH_TEST);							// Enables Depth Testing
	glDepthFunc(GL_LEQUAL);								// The Type Of Depth Testing To Do
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);	// Really Nice Perspective Calculations	
	return TRUE;										// Initialization Went OK
}

void Draw_Point()
{
	glDisable(GL_LIGHTING);
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
			glColor3f(1.0, 0.0, 0.0);
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

	glLineWidth(1.0);
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

void depthPixel() {

	//::glDisable(GL_LIGHTING);
	//glBindTexture(GL_TEXTURE_2D, texture[0]);
	//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

	
	glBegin(GL_TRIANGLES);
	//glColor4f(1.0f, 1.0f, 1.0f, 0.5f);
	//glBlendFunc(GL_SRC_ALPHA, GL_ONE);
	//glNormal3f(0.0, 0.0, 1.0);
	//glEnable(GL_TEXTURE_2D);
	//0
	glTexCoord2f(0.1780f, 0.0028f); glVertex3f(0.065f, 0.001f, -0.071 * 10); //0
	glTexCoord2f(0.0657f, 0.3014f); glVertex3f(0.024f, 0.107f, -0.072 * 10); //4
	glTexCoord2f(0.1671f, 0.2507f); glVertex3f(0.061f, 0.089f, -0.074 * 10); //5
																			 //1
	glTexCoord2f(0.1780f, 0.0028f); glVertex3f(0.065f, 0.001f, -0.071 * 10); //0
	glTexCoord2f(0.3424f, 0.1154f); glVertex3f(0.125f, 0.041f, -0.075 * 10); //2
	glTexCoord2f(0.1671f, 0.2507f); glVertex3f(0.061f, 0.089f, -0.074 * 10); //5
																			 //2
	glTexCoord2f(0.1780f, 0.0028f); glVertex3f(0.065f, 0.001f, -0.071 * 10); //0
	glTexCoord2f(0.3424f, 0.1154f); glVertex3f(0.125f, 0.041f, -0.075 * 10); //2
	glTexCoord2f(0.6164f, 0.1154f); glVertex3f(0.225f, 0.041f, -0.075 * 10); //3
																			 //3
	glTexCoord2f(0.1780f, 0.0028f); glVertex3f(0.065f, 0.001f, -0.071 * 10); //0
	glTexCoord2f(0.7808f, 0.0028f); glVertex3f(0.285f, 0.001f, -0.071 * 10); //1
	glTexCoord2f(0.6164f, 0.1154f); glVertex3f(0.225f, 0.041f, -0.075 * 10); //3
																			 //4
	glTexCoord2f(0.7808f, 0.0028f); glVertex3f(0.285f, 0.001f, -0.071 * 10); //1
	glTexCoord2f(0.6164f, 0.1154f); glVertex3f(0.225f, 0.041f, -0.075 * 10); //3
	glTexCoord2f(0.8000f, 0.2478f); glVertex3f(0.292f, 0.088f, -0.074 * 10); //6
																			 //5
	glTexCoord2f(0.7808f, 0.0028f); glVertex3f(0.285f, 0.001f, -0.071 * 10); //1
	glTexCoord2f(0.8000f, 0.2478f); glVertex3f(0.292f, 0.088f, -0.074 * 10); //6
	glTexCoord2f(0.8986f, 0.2957f); glVertex3f(0.328f, 0.105f, -0.072 * 10); //7
																			 //6
	glTexCoord2f(0.0657f, 0.3014f); glVertex3f(0.024f, 0.107f, -0.072 * 10); //4
	glTexCoord2f(0.1671f, 0.2507f); glVertex3f(0.061f, 0.089f, -0.074 * 10); //5
	glTexCoord2f(0.2054f, 0.3098f); glVertex3f(0.075f, 0.110f, -0.073 * 10); //8
																			 //7
	glTexCoord2f(0.3424f, 0.1154f); glVertex3f(0.125f, 0.041f, -0.075 * 10); //2
	glTexCoord2f(0.1671f, 0.2507f); glVertex3f(0.061f, 0.089f, -0.074 * 10); //5
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //8
	glTexCoord2f(0.3424f, 0.1154f); glVertex3f(0.125f, 0.041f, -0.075 * 10); //2
	glTexCoord2f(0.6164f, 0.1154f); glVertex3f(0.225f, 0.041f, -0.075 * 10); //3
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //9
	glTexCoord2f(0.6164f, 0.1154f); glVertex3f(0.225f, 0.041f, -0.075 * 10); //3
	glTexCoord2f(0.8000f, 0.2478f); glVertex3f(0.292f, 0.088f, -0.074 * 10); //6
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //10
	glTexCoord2f(0.8000f, 0.2478f); glVertex3f(0.292f, 0.088f, -0.074 * 10); //6
	glTexCoord2f(0.8986f, 0.2957f); glVertex3f(0.328f, 0.105f, -0.072 * 10); //7
	glTexCoord2f(0.7616f, 0.3014f); glVertex3f(0.278f, 0.107f, -0.073 * 10); //9
																			 //11
	glTexCoord2f(0.1671f, 0.2507f); glVertex3f(0.061f, 0.089f, -0.074 * 10); //5
	glTexCoord2f(0.2054f, 0.3098f); glVertex3f(0.075f, 0.110f, -0.073 * 10); //8
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //12
	glTexCoord2f(0.8000f, 0.2478f); glVertex3f(0.292f, 0.088f, -0.074 * 10); //6
	glTexCoord2f(0.7616f, 0.3014f); glVertex3f(0.278f, 0.107f, -0.073 * 10); //9
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //13
	glTexCoord2f(0.0657f, 0.3014f); glVertex3f(0.024f, 0.107f, -0.072 * 10); //4
	glTexCoord2f(0.2054f, 0.3098f); glVertex3f(0.075f, 0.110f, -0.073 * 10); //8
	glTexCoord2f(0.2328f, 0.3549f); glVertex3f(0.085f, 0.126f, -0.072 * 10); //10
																			 //14
	glTexCoord2f(0.2054f, 0.3098f); glVertex3f(0.075f, 0.110f, -0.073 * 10); //8
	glTexCoord2f(0.2328f, 0.3549f); glVertex3f(0.085f, 0.126f, -0.072 * 10); //10
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //15
	glTexCoord2f(0.7616f, 0.3014f); glVertex3f(0.278f, 0.107f, -0.073 * 10); //9
	glTexCoord2f(0.7260f, 0.3464f); glVertex3f(0.265f, 0.123f, -0.072 * 10); //11
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //16
	glTexCoord2f(0.8986f, 0.2957f); glVertex3f(0.328f, 0.105f, -0.072 * 10); //7
	glTexCoord2f(0.7616f, 0.3014f); glVertex3f(0.278f, 0.107f, -0.073 * 10); //9
	glTexCoord2f(0.7260f, 0.3464f); glVertex3f(0.265f, 0.123f, -0.072 * 10); //11
																			 //17
	glTexCoord2f(0.0657f, 0.3014f); glVertex3f(0.024f, 0.107f, -0.072 * 10); //4
	glTexCoord2f(0.2328f, 0.4366f); glVertex3f(0.085f, 0.155f, -0.071 * 10); //12
	glTexCoord2f(0.0000f, 0.5126f); glVertex3f(0.0f, 0.182f, -0.065 * 10); //15
																		   //18
	glTexCoord2f(0.0657f, 0.3014f); glVertex3f(0.024f, 0.107f, -0.072 * 10); //4
	glTexCoord2f(0.2328f, 0.3549f); glVertex3f(0.085f, 0.126f, -0.072 * 10); //10
	glTexCoord2f(0.2328f, 0.4366f); glVertex3f(0.085f, 0.155f, -0.071 * 10); //12
																			 //19
	glTexCoord2f(0.2328f, 0.3549f); glVertex3f(0.085f, 0.126f, -0.072 * 10); //10
	glTexCoord2f(0.2328f, 0.4366f); glVertex3f(0.085f, 0.155f, -0.071 * 10); //12
	glTexCoord2f(0.4767f, 0.4253f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
																			 //20
	glTexCoord2f(0.7260f, 0.3464f); glVertex3f(0.265f, 0.123f, -0.072 * 10); //11
	glTexCoord2f(0.4767f, 0.4253f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
	glTexCoord2f(0.7178f, 0.4309f); glVertex3f(0.262f, 0.153f, -0.071 * 10); //14
																			 //21
	glTexCoord2f(0.8986f, 0.2957f); glVertex3f(0.328f, 0.105f, -0.072 * 10); //7
	glTexCoord2f(0.7260f, 0.3464f); glVertex3f(0.265f, 0.123f, -0.072 * 10); //11
	glTexCoord2f(0.7178f, 0.4309f); glVertex3f(0.262f, 0.153f, -0.071 * 10); //14
																			 //22
	glTexCoord2f(0.8986f, 0.2957f); glVertex3f(0.328f, 0.105f, -0.072 * 10); //7
	glTexCoord2f(0.7178f, 0.4309f); glVertex3f(0.262f, 0.153f, -0.071 * 10); //14
	glTexCoord2f(0.9561f, 0.5014f); glVertex3f(0.349f, 0.178f, -0.065 * 10); //18
																			 //23
	glTexCoord2f(0.2328f, 0.4366f); glVertex3f(0.085f, 0.155f, -0.071 * 10); //12
	glTexCoord2f(0.0000f, 0.5126f); glVertex3f(0.000f, 0.182f, -0.065 * 10); //15
	glTexCoord2f(0.0547f, 0.5605f); glVertex3f(0.020f, 0.199f, -0.071 * 10); //16
																			 //24
	glTexCoord2f(0.2328f, 0.4366f); glVertex3f(0.085f, 0.155f, -0.071 * 10); //12
	glTexCoord2f(0.0547f, 0.5605f); glVertex3f(0.020f, 0.199f, -0.071 * 10); //16
	glTexCoord2f(0.3589f, 0.5943f); glVertex3f(0.131f, 0.211f, -0.075 * 10); //19
																			 //25
	glTexCoord2f(0.2328f, 0.4366f); glVertex3f(0.085f, 0.155f, -0.071 * 10); //12
	glTexCoord2f(0.4767f, 0.4767f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
	glTexCoord2f(0.3589f, 0.5943f); glVertex3f(0.131f, 0.211f, -0.075 * 10); //19
																			 //26
	glTexCoord2f(0.4767f, 0.4253f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
	glTexCoord2f(0.3589f, 0.5943f); glVertex3f(0.131f, 0.211f, -0.075 * 10); //19
	glTexCoord2f(0.4794f, 0.5802f); glVertex3f(0.175f, 0.206f, -0.077 * 10); //20
																			 //27
	glTexCoord2f(0.4767f, 0.4253f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
	glTexCoord2f(0.4794f, 0.5802f); glVertex3f(0.175f, 0.206f, -0.077 * 10); //20
	glTexCoord2f(0.5917f, 0.5915f); glVertex3f(0.216f, 0.210f, -0.075 * 10); //21
																			 //28
	glTexCoord2f(0.4767f, 0.4253f); glVertex3f(0.174f, 0.151f, -0.073 * 10); //13
	glTexCoord2f(0.7178f, 0.4309f); glVertex3f(0.262f, 0.153f, -0.071 * 10); //14
	glTexCoord2f(0.5917f, 0.5915f); glVertex3f(0.216f, 0.210f, -0.075 * 10); //21
																			 //29
	glTexCoord2f(0.7178f, 0.4309f); glVertex3f(0.262f, 0.153f, -0.071 * 10); //14
	glTexCoord2f(0.5342f, 0.5492f); glVertex3f(0.325f, 0.195f, -0.071 * 10); //17
	glTexCoord2f(0.5917f, 0.5915f); glVertex3f(0.216f, 0.210f, -0.075 * 10); //21
																			 //30
	glTexCoord2f(0.7178f, 0.4309f); glVertex3f(0.262f, 0.153f, -0.071 * 10); //14
	glTexCoord2f(0.5342f, 0.5492f); glVertex3f(0.325f, 0.195f, -0.071 * 10); //17
	glTexCoord2f(0.9561f, 0.5014f); glVertex3f(0.349f, 0.178f, -0.065 * 10); //18
																			 //31
	glTexCoord2f(0.0000f, 0.5126f); glVertex3f(0.000f, 0.182f, -0.065 * 10); //15
	glTexCoord2f(0.0547f, 0.5605f); glVertex3f(0.020f, 0.199f, -0.071 * 10); //16
	glTexCoord2f(0.2246f, 0.7408f); glVertex3f(0.082f, 0.263f, -0.071 * 10); //27
																			 //32
	glTexCoord2f(0.0547f, 0.5605f); glVertex3f(0.020f, 0.199f, -0.071 * 10); //16
	glTexCoord2f(0.3150f, 0.6450f); glVertex3f(0.115f, 0.229f, -0.071 * 10); //22
	glTexCoord2f(0.2246f, 0.7408f); glVertex3f(0.082f, 0.263f, -0.071 * 10); //27
																			 //33
	glTexCoord2f(0.0547f, 0.5605f); glVertex3f(0.020f, 0.199f, -0.071 * 10); //16
	glTexCoord2f(0.3589f, 0.5943f); glVertex3f(0.131f, 0.211f, -0.075 * 10); //19
	glTexCoord2f(0.3150f, 0.6450f); glVertex3f(0.115f, 0.229f, -0.071 * 10); //22
																			 //34
	glTexCoord2f(0.5342f, 0.5492f); glVertex3f(0.325f, 0.195f, -0.071 * 10); //17
	glTexCoord2f(0.5917f, 0.5915f); glVertex3f(0.216f, 0.210f, -0.075 * 10); //21
	glTexCoord2f(0.6328f, 0.6450f); glVertex3f(0.231f, 0.229f, -0.071 * 10); //23
																			 //35
	glTexCoord2f(0.5342f, 0.5492f); glVertex3f(0.325f, 0.195f, -0.071 * 10); //17
	glTexCoord2f(0.6328f, 0.6450f); glVertex3f(0.231f, 0.229f, -0.071 * 10); //23
	glTexCoord2f(0.7205f, 0.7408f); glVertex3f(0.263f, 0.263f, -0.071 * 10); //30
																			 //36
	glTexCoord2f(0.5342f, 0.5492f); glVertex3f(0.325f, 0.195f, -0.071 * 10); //17
	glTexCoord2f(0.9561f, 0.5014f); glVertex3f(0.349f, 0.178f, -0.065 * 10); //18
	glTexCoord2f(0.7205f, 0.7408f); glVertex3f(0.263f, 0.263f, -0.071 * 10); //30
																			 //37
	glTexCoord2f(0.3150f, 0.6450f); glVertex3f(0.115f, 0.229f, -0.071 * 10); //22
	glTexCoord2f(0.2246f, 0.7408f); glVertex3f(0.082f, 0.263f, -0.071 * 10); //27
	glTexCoord2f(0.2904f, 0.7774f); glVertex3f(0.106f, 0.276f, -0.071 * 10); //28
																			 //38
	glTexCoord2f(0.3150f, 0.6450f); glVertex3f(0.115f, 0.229f, -0.071 * 10); //22
	glTexCoord2f(0.3671f, 0.7436f); glVertex3f(0.134f, 0.264f, -0.073 * 10); //24
	glTexCoord2f(0.2904f, 0.7774f); glVertex3f(0.106f, 0.276f, -0.071 * 10); //28
																			 //39
	glTexCoord2f(0.3150f, 0.6450f); glVertex3f(0.115f, 0.229f, -0.071 * 10); //22
	glTexCoord2f(0.3671f, 0.7436f); glVertex3f(0.134f, 0.264f, -0.073 * 10); //24
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
																			 //40
	glTexCoord2f(0.3589f, 0.5943f); glVertex3f(0.131f, 0.211f, -0.075 * 10); //19
	glTexCoord2f(0.3150f, 0.6450f); glVertex3f(0.115f, 0.229f, -0.071 * 10); //22
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
																			 //41
	glTexCoord2f(0.3589f, 0.5943f); glVertex3f(0.131f, 0.211f, -0.075 * 10); //19
	glTexCoord2f(0.4794f, 0.5802f); glVertex3f(0.175f, 0.206f, -0.077 * 10); //20
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
																			 //42
	glTexCoord2f(0.4794f, 0.5802f); glVertex3f(0.175f, 0.206f, -0.077 * 10); //20
	glTexCoord2f(0.5917f, 0.5915f); glVertex3f(0.216f, 0.210f, -0.075 * 10); //21
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
																			 //43
	glTexCoord2f(0.5917f, 0.5915f); glVertex3f(0.216f, 0.210f, -0.075 * 10); //21
	glTexCoord2f(0.6328f, 0.6450f); glVertex3f(0.231f, 0.229f, -0.071 * 10); //23
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
																			 //44
	glTexCoord2f(0.6328f, 0.6450f); glVertex3f(0.231f, 0.229f, -0.071 * 10); //23
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
	glTexCoord2f(0.5943f, 0.7436f); glVertex3f(0.211f, 0.264f, -0.073 * 10); //26
																			 //45
	glTexCoord2f(0.6328f, 0.6450f); glVertex3f(0.231f, 0.229f, -0.071 * 10); //23
	glTexCoord2f(0.5943f, 0.7436f); glVertex3f(0.211f, 0.264f, -0.073 * 10); //26
	glTexCoord2f(0.6602f, 0.7746f); glVertex3f(0.241f, 0.275f, -0.071 * 10); //29
																			 //46
	glTexCoord2f(0.6328f, 0.6450f); glVertex3f(0.231f, 0.229f, -0.071 * 10); //23
	glTexCoord2f(0.6602f, 0.7746f); glVertex3f(0.241f, 0.275f, -0.071 * 10); //29
	glTexCoord2f(0.7205f, 0.7408f); glVertex3f(0.263f, 0.263f, -0.071 * 10); //30
																			 //47
	glTexCoord2f(0.3671f, 0.7436f); glVertex3f(0.134f, 0.264f, -0.073 * 10); //24
	glTexCoord2f(0.2904f, 0.7774f); glVertex3f(0.106f, 0.276f, -0.071 * 10); //28
	glTexCoord2f(0.3698f, 0.8309f); glVertex3f(0.135f, 0.295f, -0.071 * 10); //31
																			 //48
	glTexCoord2f(0.3671f, 0.7436f); glVertex3f(0.134f, 0.264f, -0.073 * 10); //24
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
	glTexCoord2f(0.3698f, 0.8309f); glVertex3f(0.135f, 0.295f, -0.071 * 10); //31
																			 //48
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
	glTexCoord2f(0.3698f, 0.8309f); glVertex3f(0.135f, 0.295f, -0.071 * 10); //31
	glTexCoord2f(0.4767f, 0.8507f); glVertex3f(0.174f, 0.302f, -0.073 * 10); //32
																			 //49
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
	glTexCoord2f(0.4767f, 0.8507f); glVertex3f(0.174f, 0.302f, -0.073 * 10); //32
	glTexCoord2f(0.5753f, 0.8309f); glVertex3f(0.210f, 0.295f, -0.072 * 10); //33
																			 //50
	glTexCoord2f(0.4739f, 0.7436f); glVertex3f(0.173f, 0.264f, -0.073 * 10); //25
	glTexCoord2f(0.5943f, 0.7436f); glVertex3f(0.211f, 0.264f, -0.073 * 10); //26
	glTexCoord2f(0.5753f, 0.8309f); glVertex3f(0.210f, 0.295f, -0.072 * 10); //33
																			 //51
	glTexCoord2f(0.5943f, 0.7436f); glVertex3f(0.211f, 0.264f, -0.073 * 10); //26
	glTexCoord2f(0.6602f, 0.7746f); glVertex3f(0.241f, 0.275f, -0.071 * 10); //29
	glTexCoord2f(0.5753f, 0.8309f); glVertex3f(0.210f, 0.295f, -0.072 * 10); //33
																			 //52
	glTexCoord2f(0.2246f, 0.7408f); glVertex3f(0.082f, 0.263f, -0.071 * 10); //27
	glTexCoord2f(0.2904f, 0.7774f); glVertex3f(0.106f, 0.276f, -0.071 * 10); //28
	glTexCoord2f(0.3561f, 0.9915f); glVertex3f(0.130f, 0.352f, -0.070 * 10); //35
																			 //53
	glTexCoord2f(0.2904f, 0.7774f); glVertex3f(0.106f, 0.276f, -0.071 * 10); //28
	glTexCoord2f(0.3698f, 0.8309f); glVertex3f(0.135f, 0.295f, -0.071 * 10); //31
	glTexCoord2f(0.3561f, 0.9915f); glVertex3f(0.130f, 0.352f, -0.070 * 10); //35
																			 //54
	glTexCoord2f(0.3698f, 0.8309f); glVertex3f(0.135f, 0.295f, -0.071 * 10); //31
	glTexCoord2f(0.4739f, 0.9211f); glVertex3f(0.173f, 0.327f, -0.070 * 10); //34
	glTexCoord2f(0.3561f, 0.9915f); glVertex3f(0.130f, 0.352f, -0.070 * 10); //35
																			 //55
	glTexCoord2f(0.3698f, 0.8309f); glVertex3f(0.135f, 0.295f, -0.071 * 10); //31
	glTexCoord2f(0.4767f, 0.8507f); glVertex3f(0.174f, 0.302f, -0.073 * 10); //32
	glTexCoord2f(0.4739f, 0.9211f); glVertex3f(0.173f, 0.327f, -0.070 * 10); //34
																			 //56
	glTexCoord2f(0.4767f, 0.8507f); glVertex3f(0.174f, 0.302f, -0.073 * 10); //32
	glTexCoord2f(0.5753f, 0.8309f); glVertex3f(0.210f, 0.295f, -0.072 * 10); //33
	glTexCoord2f(0.4739f, 0.9211f); glVertex3f(0.173f, 0.327f, -0.070 * 10); //34
																			 //57
	glTexCoord2f(0.5753f, 0.8309f); glVertex3f(0.210f, 0.295f, -0.072 * 10); //33
	glTexCoord2f(0.4739f, 0.9211f); glVertex3f(0.173f, 0.327f, -0.070 * 10); //34
	glTexCoord2f(0.5863f, 0.9943f); glVertex3f(0.214f, 0.353f, -0.070 * 10); //36
																			 //58
	glTexCoord2f(0.6602f, 0.7746f); glVertex3f(0.241f, 0.275f, -0.071 * 10); //29
	glTexCoord2f(0.5753f, 0.8309f); glVertex3f(0.210f, 0.295f, -0.072 * 10); //33
	glTexCoord2f(0.5863f, 0.9943f); glVertex3f(0.214f, 0.353f, -0.070 * 10); //36
																			 //59
	glTexCoord2f(0.6602f, 0.7746f); glVertex3f(0.241f, 0.275f, -0.071 * 10); //29
	glTexCoord2f(0.7205f, 0.7408f); glVertex3f(0.263f, 0.263f, -0.071 * 10); //30
	glTexCoord2f(0.5863f, 0.9943f); glVertex3f(0.214f, 0.353f, -0.070 * 10); //36
																			 //60
	glTexCoord2f(0.4739f, 0.9211f); glVertex3f(0.173f, 0.327f, -0.070 * 10); //34
	glTexCoord2f(0.3561f, 0.9915f); glVertex3f(0.130f, 0.352f, -0.070 * 10); //35
	glTexCoord2f(0.5863f, 0.9943f); glVertex3f(0.214f, 0.353f, -0.070 * 10); //36

	glEnd();
	//glDisable(GL_TEXTURE_2D);
	//::glEnable(GL_LIGHTING);

}

int DrawGLScene(GLvoid)									// Here's Where We Do All The Drawing
{

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
	glLoadIdentity();// Reset The View
					 //glTranslatef(0.5f, 0.5f, -3.0f);                  // Adjust Your View. . . .  

	initlighting();
	recoverRigidDisplay();

	/*Draw_Point();
	AdjacencyMatrix();*/
	depthPixel();

	////xrot += 0.1f;
	//yrot -= 0.5f;
	////yrot += 0.5f;
	////zrot+=0.04f;
	////floor();
	return TRUE;										// Keep Going

}

GLvoid KillGLWindow(GLvoid)								// Properly Kill The Window
{
	if (fullscreen)										// Are We In Fullscreen Mode?
	{
		ChangeDisplaySettings(NULL, 0);					// If So Switch Back To The Desktop
														//	ShowCursor(TRUE);								// Show Mouse Pointer
	}

	if (hRC)											// Do We Have A Rendering Context?
	{
		if (!wglMakeCurrent(NULL, NULL))					// Are We Able To Release The DC And RC Contexts?
		{
			MessageBox(NULL, "Release Of DC And RC Failed.", "SHUTDOWN ERROR", MB_OK | MB_ICONINFORMATION);
		}

		if (!wglDeleteContext(hRC))						// Are We Able To Delete The RC?
		{
			MessageBox(NULL, "Release Rendering Context Failed.", "SHUTDOWN ERROR", MB_OK | MB_ICONINFORMATION);
		}
		hRC = NULL;										// Set RC To NULL
	}

	if (hDC && !ReleaseDC(hWnd, hDC))					// Are We Able To Release The DC
	{
		MessageBox(NULL, "Release Device Context Failed.", "SHUTDOWN ERROR", MB_OK | MB_ICONINFORMATION);
		hDC = NULL;										// Set DC To NULL
	}

	if (hWnd && !DestroyWindow(hWnd))					// Are We Able To Destroy The Window?
	{
		MessageBox(NULL, "Could Not Release hWnd.", "SHUTDOWN ERROR", MB_OK | MB_ICONINFORMATION);
		hWnd = NULL;										// Set hWnd To NULL
	}

	if (!UnregisterClass("OpenGL", hInstance))			// Are We Able To Unregister Class
	{
		MessageBox(NULL, "Could Not Unregister Class.", "SHUTDOWN ERROR", MB_OK | MB_ICONINFORMATION);
		hInstance = NULL;									// Set hInstance To NULL
	}
}

/*	This Code Creates Our OpenGL Window.  Parameters Are:					*
*	title			- Title To Appear At The Top Of The Window				*
*	width			- Width Of The GL Window Or Fullscreen Mode				*
*	height			- Height Of The GL Window Or Fullscreen Mode			*
*	bits			- Number Of Bits To Use For Color (8/16/24/32)			*
*	fullscreenflag	- Use Fullscreen Mode (TRUE) Or Windowed Mode (FALSE)	*/

BOOL CreateGLWindow(char* title, int width, int height, int bits, bool fullscreenflag)
{
	GLuint		PixelFormat;			// Holds The Results After Searching For A Match
	WNDCLASS	wc;						// Windows Class Structure
	DWORD		dwExStyle;				// Window Extended Style
	DWORD		dwStyle;				// Window Style
	RECT		WindowRect;				// Grabs Rectangle Upper Left / Lower Right Values
	WindowRect.left = (long)0;			// Set Left Value To 0
	WindowRect.right = (long)width;		// Set Right Value To Requested Width
	WindowRect.top = (long)0;				// Set Top Value To 0
	WindowRect.bottom = (long)height;		// Set Bottom Value To Requested Height

	fullscreen = fullscreenflag;			// Set The Global Fullscreen Flag

	hInstance = GetModuleHandle(NULL);				// Grab An Instance For Our Window
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_OWNDC;	// Redraw On Size, And Own DC For Window.
	wc.lpfnWndProc = (WNDPROC)WndProc;					// WndProc Handles Messages
	wc.cbClsExtra = 0;									// No Extra Window Data
	wc.cbWndExtra = 0;									// No Extra Window Data
	wc.hInstance = hInstance;							// Set The Instance
	wc.hIcon = LoadIcon(NULL, IDI_WINLOGO);			// Load The Default Icon
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);			// Load The Arrow Pointer
	wc.hbrBackground = NULL;									// No Background Required For GL
	wc.lpszMenuName = NULL;									// We Don't Want A Menu
	wc.lpszClassName = "OpenGL";								// Set The Class Name

	if (!RegisterClass(&wc))									// Attempt To Register The Window Class
	{
		MessageBox(NULL, "Failed To Register The Window Class.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;											// Return FALSE
	}

	if (fullscreen)												// Attempt Fullscreen Mode?
	{
		DEVMODE dmScreenSettings;								// Device Mode
		memset(&dmScreenSettings, 0, sizeof(dmScreenSettings));	// Makes Sure Memory's Cleared
		dmScreenSettings.dmSize = sizeof(dmScreenSettings);		// Size Of The Devmode Structure
		dmScreenSettings.dmPelsWidth = width;				// Selected Screen Width
		dmScreenSettings.dmPelsHeight = height;				// Selected Screen Height
		dmScreenSettings.dmBitsPerPel = bits;					// Selected Bits Per Pixel
		dmScreenSettings.dmFields = DM_BITSPERPEL | DM_PELSWIDTH | DM_PELSHEIGHT;

		// Try To Set Selected Mode And Get Results.  NOTE: CDS_FULLSCREEN Gets Rid Of Start Bar.
		if (ChangeDisplaySettings(&dmScreenSettings, CDS_FULLSCREEN) != DISP_CHANGE_SUCCESSFUL)
		{
			// If The Mode Fails, Offer Two Options.  Quit Or Use Windowed Mode.
			if (MessageBox(NULL, "The Requested Fullscreen Mode Is Not Supported By\nYour Video Card. Use Windowed Mode Instead?", "NeHe GL", MB_YESNO | MB_ICONEXCLAMATION) == IDYES)
			{
				fullscreen = FALSE;		// Windowed Mode Selected.  Fullscreen = FALSE
			}
			else
			{
				// Pop Up A Message Box Letting User Know The Program Is Closing.
				MessageBox(NULL, "Program Will Now Close.", "ERROR", MB_OK | MB_ICONSTOP);
				return FALSE;									// Return FALSE
			}
		}
	}

	if (fullscreen)												// Are We Still In Fullscreen Mode?
	{
		dwExStyle = WS_EX_APPWINDOW;								// Window Extended Style
		dwStyle = WS_POPUP;										// Windows Style
		ShowCursor(FALSE);										// Hide Mouse Pointer
	}
	else
	{
		dwExStyle = WS_EX_APPWINDOW | WS_EX_WINDOWEDGE;			// Window Extended Style
		dwStyle = WS_OVERLAPPEDWINDOW;							// Windows Style
	}

	AdjustWindowRectEx(&WindowRect, dwStyle, FALSE, dwExStyle);		// Adjust Window To True Requested Size

																	// Create The Window
	if (!(hWnd = CreateWindowEx(dwExStyle,							// Extended Style For The Window
		"OpenGL",							// Class Name
		title,								// Window Title
		dwStyle |							// Defined Window Style
		WS_CLIPSIBLINGS |					// Required Window Style
		WS_CLIPCHILDREN,					// Required Window Style
		0, 0,								// Window Position
		WindowRect.right - WindowRect.left,	// Calculate Window Width
		WindowRect.bottom - WindowRect.top,	// Calculate Window Height
		NULL,								// No Parent Window
		NULL,								// No Menu
		hInstance,							// Instance
		NULL)))								// Dont Pass Anything To WM_CREATE
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Window Creation Error.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	static	PIXELFORMATDESCRIPTOR pfd =				// pfd Tells Windows How We Want Things To Be
	{
		sizeof(PIXELFORMATDESCRIPTOR),				// Size Of This Pixel Format Descriptor
		1,											// Version Number
		PFD_DRAW_TO_WINDOW |						// Format Must Support Window
		PFD_SUPPORT_OPENGL |						// Format Must Support OpenGL
		PFD_DOUBLEBUFFER,							// Must Support Double Buffering
		PFD_TYPE_RGBA,								// Request An RGBA Format
		bits,										// Select Our Color Depth
		0, 0, 0, 0, 0, 0,							// Color Bits Ignored
		0,											// No Alpha Buffer
		0,											// Shift Bit Ignored
		0,											// No Accumulation Buffer
		0, 0, 0, 0,									// Accumulation Bits Ignored
		16,											// 16Bit Z-Buffer (Depth Buffer)  
		0,											// No Stencil Buffer
		0,											// No Auxiliary Buffer
		PFD_MAIN_PLANE,								// Main Drawing Layer
		0,											// Reserved
		0, 0, 0										// Layer Masks Ignored
	};

	if (!(hDC = GetDC(hWnd)))							// Did We Get A Device Context?
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Can't Create A GL Device Context.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	if (!(PixelFormat = ChoosePixelFormat(hDC, &pfd)))	// Did Windows Find A Matching Pixel Format?
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Can't Find A Suitable PixelFormat.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	if (!SetPixelFormat(hDC, PixelFormat, &pfd))		// Are We Able To Set The Pixel Format?
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Can't Set The PixelFormat.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	if (!(hRC = wglCreateContext(hDC)))				// Are We Able To Get A Rendering Context?
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Can't Create A GL Rendering Context.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	if (!wglMakeCurrent(hDC, hRC))					// Try To Activate The Rendering Context
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Can't Activate The GL Rendering Context.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	ShowWindow(hWnd, SW_SHOW);						// Show The Window
	SetForegroundWindow(hWnd);						// Slightly Higher Priority
	SetFocus(hWnd);									// Sets Keyboard Focus To The Window
	ReSizeGLScene(width, height);					// Set Up Our Perspective GL Screen

	if (!InitGL())									// Initialize Our Newly Created GL Window
	{
		KillGLWindow();								// Reset The Display
		MessageBox(NULL, "Initialization Failed.", "ERROR", MB_OK | MB_ICONEXCLAMATION);
		return FALSE;								// Return FALSE
	}

	return TRUE;									// Success
}


BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	hInstance = hInstance; // Store instance handle in our global variable
						   /*hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
						   0, 0, 900, 600, NULL, NULL, hInstance, NULL);*/

	if (!hWnd)
	{
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	//initopengl();
	SetTimer(hWnd, 100, 100, NULL);

	return TRUE;
}

LRESULT CALLBACK WndProc(HWND	hWnd,			// Handle For This Window
	UINT	uMsg,			// Message For This Window
	WPARAM	wParam,			// Additional Message Information
	LPARAM	lParam)			// Additional Message Information
{
	int         wmId, wmEvent;
	//int			tm;
	switch (uMsg)									// Check For Windows Messages
	{

	case WM_TIMER:	if (wParam == 100) {
		DrawGLScene();
		m_elapse++;
		m_elapse = m_elapse % 21;
	}
					break;

	case WM_COMMAND:   wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);

		// Parse the menu selections:


	case WM_ACTIVATE:							// Watch For Window Activate Message
	{
		if (!HIWORD(wParam))					// Check Minimization State
		{
			active = TRUE;						// Program Is Active
		}
		else
		{
			active = FALSE;						// Program Is No Longer Active
		}

		return 0;								// Return To The Message Loop
	}

	case WM_SYSCOMMAND:							// Intercept System Commands
	{
		switch (wParam)							// Check System Calls
		{
		case SC_SCREENSAVE:					// Screensaver Trying To Start?
		case SC_MONITORPOWER:				// Monitor Trying To Enter Powersave?
			return 0;							// Prevent From Happening
		}
		break;									// Exit
	}

	case WM_CLOSE:								// Did We Receive A Close Message?
	{
		PostQuitMessage(0);						// Send A Quit Message
		return 0;								// Jump Back
	}

	case WM_KEYDOWN:							// Is A Key Being Held Down?
	{
		keys[wParam] = TRUE;					// If So, Mark It As TRUE
		return 0;								// Jump Back
	}

	case WM_KEYUP:								// Has A Key Been Released?
	{
		keys[wParam] = TRUE;					// If So, Mark It As FALSE
		return 0;								// Jump Back
	}

	case WM_LBUTTONDOWN:
		SetCapture(hWnd);
		m_px = (float)LOWORD(lParam);
		m_py = (float)HIWORD(lParam);
		m_nDrag = 1;
		return 0;

	case WM_LBUTTONUP:
		ReleaseCapture();
		m_px = 0.0f;
		m_py = 0.0f;
		m_nDrag = 0;
		DrawGLScene();
		return 0;

	case WM_RBUTTONDOWN:
		SetCapture(hWnd);
		m_px = (float)LOWORD(lParam);
		m_py = (float)HIWORD(lParam);
		m_nDrag = 2;
		return 0;

	case WM_RBUTTONUP:
		ReleaseCapture();
		m_px = 0.0f;
		m_py = 0.0f;
		m_nDrag = 0;
		DrawGLScene();
		return 0;

	case WM_MOUSEMOVE:   if (m_nDrag)
	{
		int mx, my;

		mx = LOWORD(lParam);
		my = HIWORD(lParam);

		if (mx & (1 << 15)) mx -= (1 << 16);
		if (my & (1 << 15)) my -= (1 << 16);

		mouse_update((float)mx, (float)my);
		DrawGLScene();
	}
						 return 0;

	case WM_SIZE:								// Resize The OpenGL Window
	{
		ReSizeGLScene(LOWORD(lParam), HIWORD(lParam));  // LoWord=Width, HiWord=Height
		return 0;								// Jump Back
	}

	case WM_DESTROY:	purge();//if (image != NULL) free (image);
		PostQuitMessage(0);
		KillTimer(hWnd, 100);
		break;

	default:   return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	// Pass All Unhandled Messages To DefWindowProc
	return DefWindowProc(hWnd, uMsg, wParam, lParam);


}

LRESULT CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_INITDIALOG:   return TRUE;

	case WM_COMMAND:   if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
	{
		EndDialog(hDlg, LOWORD(wParam));
		return TRUE;
	}
					   break;
	}
	return FALSE;
}

LRESULT CALLBACK Event(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_INITDIALOG:   return TRUE;

	case WM_COMMAND:   if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
	{
		EndDialog(hDlg, LOWORD(wParam));
		return TRUE;
	}
					   break;
	}
	return FALSE;
}

int WINAPI WinMain(HINSTANCE	hInstance,			// Instance
	HINSTANCE	hPrevInstance,		// Previous Instance
	LPSTR		lpCmdLine,			// Command Line Parameters
	int			nCmdShow)			// Window Show State
{
	MSG		msg;									// Windows Message Structure
	BOOL	done = FALSE;								// Bool Variable To Exit Loop

														// Ask The User Which Screen Mode They Prefer
	//if (MessageBox(NULL, "You Just Click \"No\"", "Start Full Screen", MB_YESNO | MB_ICONQUESTION) == IDNO)
	//{
	//	fullscreen = FALSE;							// Windowed Mode
	//}

	// Create Our OpenGL Window
	if (!CreateGLWindow("MESH 3D", 710, 730, 16, fullscreen))
	{
		return 0;									// Quit If Window Was Not Created
	}

	while (!done)									// Loop That Runs While done=FALSE
	{
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))	// Is There A Message Waiting?
		{
			if (msg.message == WM_QUIT)				// Have We Received A Quit Message?
			{
				done = TRUE;							// If So done=TRUE
			}
			else									// If Not, Deal With Window Messages
			{
				TranslateMessage(&msg);				// Translate The Message
				DispatchMessage(&msg);				// Dispatch The Message
			}
		}
		else										// If There Are No Messages
		{
			// Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
			if ((active && !DrawGLScene()) || keys[VK_ESCAPE])	// Active?  Was There A Quit Received?
			{
				done = TRUE;							// ESC or DrawGLScene Signalled A Quit
			}
			else									// Not Time To Quit, Update Screen
			{
				SwapBuffers(hDC);					// Swap Buffers (Double Buffering)
			}

			if (keys[VK_F1])						// Is F1 Being Pressed?
			{
				keys[VK_F1] = FALSE;					// If So Make Key FALSE
				KillGLWindow();						// Kill Our Current Window
				fullscreen = !fullscreen;				// Toggle Fullscreen / Windowed Mode
														// Recreate Our OpenGL Window
				if (!CreateGLWindow("Project CG", 640, 480, 16, fullscreen))
				{
					return 0;						// Quit If Window Was Not Created
				}
			}
		}
	}

	// Shutdown
	KillGLWindow();									// Kill The Window
	return (msg.wParam);							// Exit The Program
}
