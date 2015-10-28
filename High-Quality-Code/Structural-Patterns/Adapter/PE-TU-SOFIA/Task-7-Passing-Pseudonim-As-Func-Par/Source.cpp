#include <iostream>
#include <math.h>
using namespace std;

class Point
{
public:
	Point(double xCoordinate, double yCoordinate);
	~Point();

	void print();
	double distance(const Point &firstPoint, const Point &secondPoint);

private:
	double x, y;
};

Point::Point(double xCoordinate, double yCoordinate)
{
	this->x = xCoordinate;
	this->y = yCoordinate;
}

Point::~Point()
{
}

void Point::print()
{
	cout << "Point(" << this->x << ", " << this->y << ")";
}

double Point::distance(const Point &firstPoint, const Point &secondPoint)
{
	return sqrt(pow((firstPoint.x - secondPoint.x), 2) + pow((firstPoint.y - secondPoint.y), 2));
}

int main()
{
	Point a(3, 4);
	Point b(10, 4);

	cout << "The distance between "; a.print();
	cout << " and "; b.print();
	cout << " is " << a.distance(a, b) << endl;
}