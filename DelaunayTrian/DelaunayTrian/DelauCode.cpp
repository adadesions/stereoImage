#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/highgui/highgui.hpp>
#include "json/json.h"
#include <iostream>
#include <fstream>

using namespace cv;
using namespace std;

// Draw a single point
static void draw_point(Mat& img, Point2f fp, Scalar color)
{
	circle(img, fp, 3, color, CV_FILLED, CV_AA, 0);
}

// Draw delaunay triangles
static void draw_delaunay(Mat& img, Subdiv2D& subdiv, Scalar delaunay_color)
{
	vector<Vec6f> triangleList;
	subdiv.getTriangleList(triangleList);
	vector<Point> pt(3);
	Size size = img.size();
	Rect rect(0, 0, size.width, size.height);

	for (size_t i = 0; i < triangleList.size(); i++)
	{
		Vec6f t = triangleList[i];
		pt[0] = Point(cvRound(t[0]), cvRound(t[1]));
		pt[1] = Point(cvRound(t[2]), cvRound(t[3]));
		pt[2] = Point(cvRound(t[4]), cvRound(t[5]));

		// Draw rectangles completely inside the image.
		if (rect.contains(pt[0]) && rect.contains(pt[1]) && rect.contains(pt[2]))
		{
			line(img, pt[0], pt[1], delaunay_color, 1, CV_AA, 0);
			line(img, pt[1], pt[2], delaunay_color, 1, CV_AA, 0);
			line(img, pt[2], pt[0], delaunay_color, 1, CV_AA, 0);
		}
	}
}

int main(int argc, char** argv)
{
	// Define window names
	string win_delaunay = "Delaunay Triangulation";

	// Turn on animation while drawing triangles
	bool animate = true;

	// Define colors for drawing.
	Scalar delaunay_color(255, 255, 255), points_color(0, 0, 255);

	// Read in the image.
	Mat img = imread("DisparityImage/139.png");

	// Keep a copy around
	Mat img_orig = img.clone();

	// Rectangle to be used with Subdiv2D
	Size size = img.size();
	Rect rect(0, 0, size.width, size.height);

	// Create an instance of Subdiv2D
	Subdiv2D subdiv(rect);

	// Create a vector of points.
	vector<Point2f> points;

	// Read in the points from a text file
	ifstream ifs("PointFace/PointFace139.txt"); 
	int x, y;
	
	while (ifs >> x >> y)
	{
		points.push_back(Point2f(x, y));
	}

	// Insert points into subdiv
	for (vector<Point2f>::iterator it = points.begin(); it != points.end(); it++)
	{
		subdiv.insert(*it);
		// Show animation
		if (animate)
		{
			Mat img_copy = img_orig.clone();
			// Draw delaunay triangles
			draw_delaunay(img_copy, subdiv, delaunay_color);
			imshow(win_delaunay, img_copy);
			waitKey(100);
		}
	}

	// Draw delaunay triangles
	draw_delaunay(img, subdiv, delaunay_color);

	// Draw points
	for (vector<Point2f>::iterator it = points.begin(); it != points.end(); it++)
	{
		draw_point(img, *it, points_color);
	}

	// Show results.
	imshow(win_delaunay, img);
	imwrite("DelaunayImg/DE139.png", img);
	waitKey(0);
	return 0;
}