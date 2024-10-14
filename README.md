# Project Divide 25

This project provides a REST API interface to calculate the smallest multiple that is evenly divisible by all numbers from with the user provided start and end divisble.

## Requirements

.NET SDK 7.0 or later

## Setup

1. Clone repository
Clone reposistory to location of your choice using

``git clone https://github.com/sjolsthoorn/divide25.git``

2. Navigate to project directory

``cd divide25``

3. Restore dependencies

``dotnet restore``

## Running the application

1. Build application
From the root directory
``dotnet build``

2. Run the API

http: ``dotnet run``

https: ``dotnet run --launch-profile "https"``

Access the API by visiting the locally running web server which can be obtained from the terminal console that will appear after starting. This is usually ``http://localhost:5000/swagger`` or ``https://localhost:7291/swagger`` for HTTPS

## Running the tests

Run the following command to execute the tests

``dotnet test``

## Old Code

Before finding the Least Commmon Multiple and Greatest Common Divisor Arithmetic, I had created my own, albiet incredibly slow, looping solution that took a long time to calculate.
Below is the function

```
public long DivideByWithoutRemainder(int divideBy)
{
    long number = 1;

    while (true)
    {
        bool divisibleByAll = true;

        for (int i = 1; i <= divideBy; i++)
        {
            if (number % i != 0)
            {
                divisibleByAll = false;
                break;
            }
        }

        if (divisibleByAll)
        {
            return number;
        }

        number += 1;
    }
}
```

On my AMD Ryzen X7700 it took 1.5 minute to calculate.

# Made for West Consultency