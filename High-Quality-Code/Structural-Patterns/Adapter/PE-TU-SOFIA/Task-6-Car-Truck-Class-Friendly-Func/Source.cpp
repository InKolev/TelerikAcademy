#include <iostream>
#include <math.h>
using namespace std;

class Truck;

class Car
{
private:
	int passengers;
	double speed;
public:
	Car(int p, double s) { passengers = p; speed = s; }
	
	double getSpeed(Truck t);
};

double Car::getSpeed(Truck t)
{
	return t.speed;
}

class Truck
{
private:
	int weight;
	double speed;
public:
	Truck(int w, double s) { weight = w; speed = s; }

	friend double Car::getSpeed(Truck t);
};

int main()
{
	Car car(1000, 170.00);
	Truck truck(2000, 200.00);

	double carSpeed = car.getSpeed(truck);
}