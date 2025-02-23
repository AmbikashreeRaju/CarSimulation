Microsoft Windows [Version 10.0.19045.5487]
(c) Microsoft Corporation. All rights reserved.

C:\WINDOWS\system32>cd C:\Ambika\CarSimulation\CarSimulationApp

C:\Ambika\CarSimulation\CarSimulationApp>dotnet build
  Determining projects to restore...
  All projects are up-to-date for restore.
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(10,30): warning CS8602: Der
eference of a possibly null reference. [C:\Ambika\CarSimulation\CarSimulationAp
p\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(30,35): warning CS8600: Con
verting null literal or possible null value to non-nullable type. [C:\Ambika\Ca
rSimulation\CarSimulationApp\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(33,36): warning CS8602: Der
eference of a possibly null reference. [C:\Ambika\CarSimulation\CarSimulationAp
p\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(39,39): warning CS8600: Con
verting null literal or possible null value to non-nullable type. [C:\Ambika\Ca
rSimulation\CarSimulationApp\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(41,39): warning CS8604: Pos
sible null reference argument for parameter 'name' in 'Car.Car(string name, int
 x, int y, string direction, string commands)'. [C:\Ambika\CarSimulation\CarSim
ulationApp\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(41,62): warning CS8604: Pos
sible null reference argument for parameter 'commands' in 'Car.Car(string name,
 int x, int y, string direction, string commands)'. [C:\Ambika\CarSimulation\Ca
rSimulationApp\CarSimulationApp.csproj]
  CarSimulationApp -> C:\Ambika\CarSimulation\CarSimulationApp\bin\Debug\net8.0
  \CarSimulationApp.dll

Build succeeded.

C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(10,30): warning CS8602: Der
eference of a possibly null reference. [C:\Ambika\CarSimulation\CarSimulationAp
p\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(30,35): warning CS8600: Con
verting null literal or possible null value to non-nullable type. [C:\Ambika\Ca
rSimulation\CarSimulationApp\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(33,36): warning CS8602: Der
eference of a possibly null reference. [C:\Ambika\CarSimulation\CarSimulationAp
p\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(39,39): warning CS8600: Con
verting null literal or possible null value to non-nullable type. [C:\Ambika\Ca
rSimulation\CarSimulationApp\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(41,39): warning CS8604: Pos
sible null reference argument for parameter 'name' in 'Car.Car(string name, int
 x, int y, string direction, string commands)'. [C:\Ambika\CarSimulation\CarSim
ulationApp\CarSimulationApp.csproj]
C:\Ambika\CarSimulation\CarSimulationApp\Program.cs(41,62): warning CS8604: Pos
sible null reference argument for parameter 'commands' in 'Car.Car(string name,
 int x, int y, string direction, string commands)'. [C:\Ambika\CarSimulation\Ca
rSimulationApp\CarSimulationApp.csproj]
    6 Warning(s)
    0 Error(s)

Time Elapsed 00:00:22.67

C:\Ambika\CarSimulation\CarSimulationApp>dotnet run
Welcome to Auto Driving Car Simulation!
Please enter the width and height of the simulation field in x y format:
10 10
You have created a field of 10 x 10.
Please choose from the following options:
[1] Add a car to field
[2] Run simulation
1
Please enter the name of the car:
A
Please enter initial position of car A in x y Direction format:
1 2 N
Please enter the commands for car A:
FFRFFFFRRL
Your current list of cars are:
- A, (1,2) N, FFRFFFFRRL
You have created a field of 10 x 10.
Please choose from the following options:
[1] Add a car to field
[2] Run simulation
1
Please enter the name of the car:
B
Please enter initial position of car B in x y Direction format:
7 8 W
Please enter the commands for car B:
FFLFFFFFFF
Your current list of cars are:
- A, (1,2) N, FFRFFFFRRL
- B, (7,8) W, FFLFFFFFFF
You have created a field of 10 x 10.
Please choose from the following options:
[1] Add a car to field
[2] Run simulation
2
After simulation, the result is:
A, collides with another car at (5,4) at step 7
B, collides with another car at (5,4) at step 7
Please choose from the following options:
[1] Start over
[2] Exit
2
Thank you for running the simulation. Goodbye!

C:\Ambika\CarSimulation\CarSimulationApp>

TEST CASES EXECUTION:
*********************

C:\Ambika\CarSimulation\CarSimulationTests>dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  CarSimulationApp -> C:\Ambika\CarSimulation\CarSimulationApp\bin\Debug\net8.0
  \CarSimulationApp.dll
  CarSimulationTests -> C:\Ambika\CarSimulation\CarSimulationTests\bin\Debug\ne
  t8.0\CarSimulationTests.dll
Test run for C:\Ambika\CarSimulation\CarSimulationTests\bin\Debug\net8.0\CarSimulationTests.dll (.NETCoreApp,Version=v8.0)
VSTest version 17.11.1 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    14, Skipped:     0, Total:    14, Duration: 257 ms - CarSimulationTests.dll (net8.0)

C:\Ambika\CarSimulation\CarSimulationTests>
