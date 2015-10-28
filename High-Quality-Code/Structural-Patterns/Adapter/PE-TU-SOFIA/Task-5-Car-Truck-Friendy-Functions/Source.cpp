#include <iostream>
#include <math.h>
using namespace std;

class Truck;

class Car
{
private:
	int passengers;
	int speed;
public:
	Car(int p, int s) { passengers = p; speed = s; }

	friend int sp_greater(Car car, Truck truck);
};

class Truck
{
private:
	int weight;
	int speed;
public:
	Truck(int w, int s) { weight = w; speed = s; }

	friend int sp_greater(Car car, Truck truck);
};

int sp_greater(Car car, Truck truck)
{
	return car.speed - truck.speed;
}

int main()
{
	Car car(1000, 170);
	Truck truck(2000, 200);

	double speedDifference = sp_greater(car, truck);

	if (speedDifference < 0)
	{
		cout << "The Truck is faster than the Car.\n";
	}
	else if (speedDifference > 0)
	{
		cout << "The Car is faster than the Truck.\n";
	}
	else
	{
		cout << "Both vehicles have the same speed.\n";
	}
}