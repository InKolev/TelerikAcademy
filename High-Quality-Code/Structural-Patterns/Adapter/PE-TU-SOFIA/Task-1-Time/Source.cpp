#include <iostream>
#include <math.h>
using namespace std;

class Time
{
public:
	Time();
	~Time();
	bool setTime(double hours, double minutes, double seconds);
	void displayTime();

private:
	double hours, minutes, seconds;
};

Time::Time()
{
	cout << "\n" << "Time object created!" << "\n";
}

Time::~Time()
{
	cout << "\n" << "Destroyed object Time!" << "\n";
}

bool Time::setTime(double hours, double minutes, double seconds)
{
	if ((hours > 24 || hours < 0) ||
		(minutes > 59 || minutes < 0) ||
		(seconds > 59 || seconds < 0))
	{
		return false;
	}

	this->hours = hours;
	this->minutes = minutes;
	this->seconds = seconds;

	return true;
}

void Time::displayTime()
{
	if ((this->hours < 10) && (this->minutes < 10) && (this->seconds < 10))
	{
		cout << "The current time is: 0" << hours << ":0" << minutes << ":0" << seconds;
	}
	if (this->hours < 10 && this->minutes < 10 && this->seconds >= 10)
	{
		cout << "The current time is: 0" << hours << ":0" << minutes << ":" << seconds;
	}
	if (this->hours < 10 && (this->minutes >= 10) && (this->seconds >= 10))
	{
		cout << "The current time is: 0" << hours << ":" << minutes << ":" << seconds;
	}
	if (this->hours < 10 && this->minutes > 10 && this->seconds < 10)
	{
		cout << "The current time is: 0" << hours << ":" << minutes << ":0" << seconds;
	}
	if (this->hours > 10 && this->minutes < 10 && this->seconds > 10)
	{
		cout << "The current time is: " << hours << ":0" << minutes << ":" << seconds;
	}
	if (this->hours > 10 && this->minutes > 10 && this->seconds < 10)
	{
		cout << "The current time is: " << hours << ":" << minutes << ":0" << seconds;
	}
	if (this->hours > 10 && this->minutes < 10 && this->seconds < 10)
	{
		cout << "The current time is: " << hours << ":0" << minutes << ":0" << seconds;
	}
	if (this->hours > 10 && this->minutes > 10 && this->seconds > 10)
	{
		cout << "The current time is: " << hours << ":" << minutes << ":" << seconds;
	}

	
	if (this->hours < 12)
	{
		cout << " AM \n";
	}
	else
	{
		cout << " PM \n";
	}
}

void main()
{
	Time myTime;

	myTime.setTime(21, 5, 1);
	myTime.displayTime();

	myTime.setTime(21, 23, 1);
	myTime.displayTime();

	myTime.setTime(15, 22, 15);
	myTime.displayTime();

	myTime.setTime(2, 33, 15);
	myTime.displayTime();

	myTime.setTime(2, 4, 25);
	myTime.displayTime();

	myTime.setTime(2, 1, 0);
	myTime.displayTime();
}