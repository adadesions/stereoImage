/*
 * =====================================================================================
 *
 *       Filename:  Source.cpp
 *
 *    Description:  This program to build depth map
 *
 *        Version:  1.0
 *        Created:  11/18/16 15:13:35
 *       Revision:  none
 *       Compiler:  gcc
 *
 *         Author:  Ada Kaminkure (AdaCode), ada@adacode.io
 *        Company:  ADACODE.IO
 *
 * =====================================================================================
 */


#include	<iostream>
#include	<opencv2/imgproc.hpp>
#include	<opencv2/highgui.hpp>
#include	<opencv2/core/utility.hpp>
#include	<opencv2/calib3d.hpp>

using namespace std;
using namespace cv;

int main()
{
	char window_left[] = "Left View";
	char window_right[] = "Right View";
	char window_disparity[] = "Disparity";
	Mat left_view = imread("../image/10L.jpg", 0);	
	Mat right_view = imread("../image/10R.jpg",0);	
	Mat disparity_16S = Mat( left_view.rows, left_view.cols, CV_16S);
	Mat disparity_8U = Mat(left_view.rows, left_view.cols, CV_8UC1);

// Stereo BM
	int minDisparity = -39;
	int ndisparities = 16*7;
	int SADWindowSize = 23;
	int p1 = 100;
	int p2 = 1000;
	int disp12MaxDiff = 50;
	int preFilter = 20;
	Ptr<StereoSGBM> sbm = StereoSGBM::create(minDisparity, ndisparities, SADWindowSize, p1, p2, disp12MaxDiff,preFilter);

	sbm ->compute( left_view, right_view, disparity_16S );

	double minVal, maxVal;
	minMaxLoc( disparity_16S, &minVal, &maxVal );

	disparity_16S.convertTo( disparity_8U, CV_8UC1, 255/(maxVal-minVal));

	imshow(window_left , left_view);
	imshow(window_right, right_view);
	imshow(window_disparity, disparity_8U);
	waitKey(0);
	return 0;
}

















