#include <iostream>
#include <math.h>
using namespace std;

class Triangle
{
private:
	double a, b, c;
public:
	double surface();
	void show(char *);
	Triangle();
	~Triangle();
};

Triangle::Triangle()
{
	do
	{
		cout << "\n\nEnter three values for the sides of triangle: \n";
		cin >> a >> b >> c;
	} while (!((a > 0) && (b > 0) && (c > 0) && (a + b > c) && (a + c > b) && (b + c) > a));
}

Triangle::~Triangle()
{
	cout << "\nDestructing object triangle!";
}

double Triangle::surface()
{
	double p, s;

	p = (a + b + c) / 2;
	s = sqrt(p*(p - a)*(p - b)*(p - c));

	return s;
}

void Triangle::show(char *name)
{
	cout << "\nThe sides of " << name << " are: \n";
	cout << "a=" << a << ", b = " << b << ", c = " << c;
}

void main()
{
	Triangle myTriangle;
	Triangle mySecondTriangle;
	Triangle *p;
	double surface;

	surface = myTriangle.surface();
	myTriangle.show("myTriangle");

	cout << "\nThe surface of myTriangle is: " << surface;

	p = &mySecondTriangle;
	surface = p->surface();
	p->show("mySecondTriangle");

	cout << "\nThe surface of mySecondTriangle is: " << surface;
}

