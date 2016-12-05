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
	Mat left_view = imread("../image/139L.jpg", 0);
	Mat right_view = imread("../image/139R.jpg", 0);
	Mat disparity_16S = Mat(left_view.rows, left_view.cols, CV_16S);
	Mat disparity_8U = Mat(left_view.rows, left_view.cols, CV_8UC1);

	// Stereo SGBM
	int minDisparity = -39;
	int ndisparities = 16 * 9;
	int SADWindowSize = 3; //odd number
	int P1 = 100;
	int P2 = 2600; // more than P1
	int disp12MaxDiff = 50;
	int preFilterCap = 20;
	Ptr<StereoSGBM> sbm = StereoSGBM::create(minDisparity, ndisparities, SADWindowSize, P1, P2, disp12MaxDiff, preFilterCap);

	sbm->compute(left_view, right_view, disparity_16S);

	double minVal, maxVal;
	minMaxLoc(disparity_16S, &minVal, &maxVal);
	disparity_16S.convertTo(disparity_8U, CV_8UC1, 255 / (maxVal - minVal));

	imshow(window_left, left_view);
	imshow(window_right, right_view);
	imshow(window_disparity, disparity_8U);
	imwrite("DisparityImg/139.png", disparity_8U);
	waitKey(0);
	return 0;

}