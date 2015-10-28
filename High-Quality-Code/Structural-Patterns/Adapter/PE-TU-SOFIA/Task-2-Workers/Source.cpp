#include <iostream>
#include <math.h>
using namespace std;

class Worker
{
public:
	Worker(string socialNumber);
	Worker();
	~Worker();

	void setupWorker(string name, string jobTitle, string socialNumber, double *salaries, short workYears);
	double getAvgSalary();
	double getMinSalary();

private:
	string name;
	string jobTitle;
	string socialNumber;
	double *salaries;
	short workYears;
};

double Worker::getAvgSalary()
{
	double averageSalary = 0;

	for (int i = 0; i < 5; i++)
	{
		averageSalary += this->salaries[i];
	}

	return (averageSalary / 5);
}

double Worker::getMinSalary()
{
	double minSalary = this->salaries[0];

	for (int i = 0; i < 5; i++)
	{
		if (minSalary > this->salaries[i])
		{
			minSalary = this->salaries[i];
		}
	}

	return minSalary;
}

void Worker::setupWorker(string name, string jobTitle, string socialNumber, double *salaries, short workYears)
{
	this->name = name;
	this->jobTitle = jobTitle;
	this->socialNumber = socialNumber;
	this->salaries = salaries;
	this->workYears = workYears;
}

Worker::Worker()
{

}

Worker::Worker(string socialNumber)
{
	this->socialNumber = socialNumber;
	this->workYears = 0;
}

Worker::~Worker()
{
	cout << "\nDestructing object Worker!";
}

void main()
{
	double salaries[5] = { 1000, 2000, 3000, 4000, 5000 };

	Worker myWorker;
	myWorker.setupWorker("Ivaylo", "Software Engineer", "123-A-52-B", salaries, 10);

	double avgSalary = myWorker.getAvgSalary();
	cout << "\nAverage Salary: " << avgSalary;

	double minSalary = myWorker.getMinSalary();
	cout << "\nMinimal Salary: " << minSalary;

}