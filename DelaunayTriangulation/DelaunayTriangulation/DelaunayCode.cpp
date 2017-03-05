#include <time.h>
#include <GL/glut.h>
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

void init(void)
{
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glMatrixMode(GL_PROJECTION);
	gluOrtho2D(0.0, 710.0, 730.0, 0.0);
}

// Variable that specifies the number of triangles to be drawn on the screen(for animation)
int nTriangles = 0;

int matrix[37][37];
int point[37][2];
void AdjacencyMatrix() {

	int c = 1, k;
	ifstream matrixflie;
	matrixflie.open("AdjacencyMatrix.txt");

	while (matrixflie >> k) {
		if (c % 37 == 1) {
			matrix[c / 37][0] = k;
		}
		else if (c % 37 == 2)
		{
			matrix[c / 37][1] = k;
		}
		else if (c % 37 == 3) 
		{
			matrix[c / 37][2] = k;
		}
		else if (c % 37 == 4) //if i is the first integer in a row
		{
			matrix[c / 37][3] = k; //set as x-cord.
		}
		else if (c % 37 == 5) //if i is the first integer in a row
		{
			matrix[c / 37][4] = k; //set as x-cord.
		}
		else if (c % 37 == 6) //if i is the first integer in a row
		{
			matrix[c / 37][5] = k; //set as x-cord.
		}
		else if (c % 37 == 7) //if i is the first integer in a row
		{
			matrix[c / 37][6] = k; //set as x-cord.
		}
		else if (c % 37 == 8) //if i is the first integer in a row
		{
			matrix[c / 37][7] = k; //set as x-cord.
		}
		else if (c % 37 == 9) //if i is the first integer in a row
		{
			matrix[c / 37][8] = k; //set as x-cord.
		}
		else if (c % 37 == 10) //if i is the first integer in a row
		{
			matrix[c / 37][9] = k; //set as x-cord.
		}
		else if (c % 37 == 11) //if i is the first integer in a row
		{
			matrix[c / 37][10] = k; //set as x-cord.
		}
		else if (c % 37 == 12) //if i is the first integer in a row
		{
			matrix[c / 37][11] = k; //set as x-cord.
		}
		else if (c % 37 == 13) //if i is the first integer in a row
		{
			matrix[c / 37][12] = k; //set as x-cord.
		}
		else if (c % 37 == 14) //if i is the first integer in a row
		{
			matrix[c / 37][13] = k; //set as x-cord.
		}
		else if (c % 37 == 15) //if i is the first integer in a row
		{
			matrix[c / 37][14] = k; //set as x-cord.
		}
		else if (c % 37 == 16) //if i is the first integer in a row
		{
			matrix[c / 37][15] = k; //set as x-cord.
		}
		else if (c % 37 == 17) //if i is the first integer in a row
		{
			matrix[c / 37][16] = k; //set as x-cord.
		}
		else if (c % 37 == 18) //if i is the first integer in a row
		{
			matrix[c / 37][17] = k; //set as x-cord.
		}
		else if (c % 37 == 19) //if i is the first integer in a row
		{
			matrix[c / 37][18] = k; //set as x-cord.
		}
		else if (c % 37 == 20) //if i is the first integer in a row
		{
			matrix[c / 37][19] = k; //set as x-cord.
		}
		else if (c % 37 == 21) //if i is the first integer in a row
		{
			matrix[c / 37][20] = k; //set as x-cord.
		}
		else if (c % 37 == 22) //if i is the first integer in a row
		{
			matrix[c / 37][21] = k; //set as x-cord.
		}
		else if (c % 37 == 23) //if i is the first integer in a row
		{
			matrix[c / 37][22] = k; //set as x-cord.
		}
		else if (c % 37 == 24) //if i is the first integer in a row
		{
			matrix[c / 37][23] = k; //set as x-cord.
		}
		else if (c % 37 == 25) //if i is the first integer in a row
		{
			matrix[c / 37][24] = k; //set as x-cord.
		}
		else if (c % 37 == 26) //if i is the first integer in a row
		{
			matrix[c / 37][25] = k; //set as x-cord.
		}
		else if (c % 37 == 27) //if i is the first integer in a row
		{
			matrix[c / 37][26] = k; //set as x-cord.
		}
		else if (c % 37 == 28) //if i is the first integer in a row
		{
			matrix[c / 37][27] = k; //set as x-cord.
		}
		else if (c % 37 == 29) //if i is the first integer in a row
		{
			matrix[c / 37][28] = k; //set as x-cord.
		}
		else if (c % 37 == 30) //if i is the first integer in a row
		{
			matrix[c / 37][29] = k; //set as x-cord.
		}
		else if (c % 37 == 31) //if i is the first integer in a row
		{
			matrix[c / 37][30] = k; //set as x-cord.
		}
		else if (c % 37 == 32) //if i is the first integer in a row
		{
			matrix[c / 37][31] = k; //set as x-cord.
		}
		else if (c % 37 == 33) //if i is the first integer in a row
		{
			matrix[c / 37][32] = k; //set as x-cord.
		}
		else if (c % 37 == 34) //if i is the first integer in a row
		{
			matrix[c / 37][33] = k; //set as x-cord.
		}
		else if (c % 37 == 35) //if i is the first integer in a row
		{
			matrix[c / 37][34] = k; //set as x-cord.
		}
		else if (c % 37 == 36)
		{
			//if i is the first integer in a row
			matrix[c / 37][35] = k; //set as x-cord.
		}
		else if (c % 37 == 0)
		{
			matrix[(c - 1) / 37][36] = k; //set as 36-cord.
		}//else if i is the second integer in a row
		 //cout << k;		
		c++;
	}

	glLineWidth(1.5);
	glBegin(GL_LINES);
	glColor3f(1.0, 1.0, 1.0);
	for (int i = 0; i < 37; i++) { //row	
		for (int j = 0; j < 37; j++) { //column
			if ((matrix[i][j] == 1)) {
				glVertex2i(point[i][0], point[i][1]);
				glVertex2i(point[j][0], point[j][1]);
			}
		}
	}
	glEnd();
}

void display(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	
	int i, c = 0;
	ifstream pointflie;
	pointflie.open("PointFace/PointFaceAverage.txt");

	AdjacencyMatrix();

	glPointSize(7.0);
	while (pointflie >> i) {
		if (c % 2 != 0) //if i is the first integer in a row
			point[c / 2][1] = i; //set as y-cord.

		else //else if i is the second integer in a row
			point[c / 2][0] = i; //set as x-cord.

		if (point[c / 2][0] && point[c / 2][1])
		{
			glBegin(GL_POINTS);
			glColor3f(1.0, 0.0, 0.0);
			glVertex2f(point[c / 2][0], point[c / 2][1]);
			glEnd();
			//cout << point[0][0] << endl;
		}
		c++;
		//cout <<c;
	}

	glFlush();
}

//Called when an timer event occurs(This function is called every 1 sec)
void timer(int extra) {
	if (nTriangles >= 3) {
		return;
	}
	nTriangles++;

	glutPostRedisplay();			//Redraw the frame
	glutTimerFunc(100, timer, 0);	//Reset the timer to be triggered after 1000 msecs
}

int main(int argc, char *argv[])
{
	glutInit(&argc, argv);
	glutInitWindowSize(710, 730);
	glutInitDisplayMode(GLUT_RGB | GLUT_SINGLE);
	glutCreateWindow("Delaunay Triangulation");

	init();
	//triangulate();
	glutDisplayFunc(display);
	glutTimerFunc(0, timer, 0);	// REgister Timer function
	glutMainLoop();
}