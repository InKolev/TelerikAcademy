#include <iostream>
#include <math.h>
using namespace std;

class Triangle
{
private:
	double a, b, c;
public:
	double surface();
	double surface(double *);
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
	double halfPerimeter, surface;

	halfPerimeter = (a + b + c) / 2;
	surface = sqrt(halfPerimeter*(halfPerimeter - a)*(halfPerimeter - b)*(halfPerimeter - c));

	return surface;
}

double Triangle::surface(double *p)
{
	double perimeter, halfPerimeter, surface;
	
	perimeter = (a + b + c);
	halfPerimeter = (a + b + c) / 2;
	surface = sqrt(halfPerimeter*(halfPerimeter - a)*(halfPerimeter - b)*(halfPerimeter - c));

	// Returning the second result via argument-pointer.
	*p = perimeter;	

	return surface;
}

void Triangle::show(char *name)
{
	cout << "\nThe sides of " << name << " are: \n";
	cout << "a = " << a << ", b = " << b << ", c = " << c;
}

void main()
{
	Triangle myTriangle;
	Triangle mySecondTriangle;
	Triangle *p;
	double surface, perimeter = 0;

	cout << "\nThe perimeter is currently: " << perimeter;

	surface = myTriangle.surface();
	myTriangle.show("myTriangle");

	cout << "\nThe surface of myTriangle is: " << surface;

	p = &mySecondTriangle;
	surface = p->surface(&perimeter);
	p->show("mySecondTriangle");

	cout << "\nThe surface of mySecondTriangle is: " << surface;
	cout << "\nThe perimeter of mySecondTriangle is: " << perimeter;
}