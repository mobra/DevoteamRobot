# Robot programming

This repository contains code for a C# programming assignment.

You can download the compiled files for Windows machines [here](https://github.com/mobra/DevoteamRobot/releases/tag/1.0.0).

To run the app, simply double-click on the
#### `DevoteamRobot.exe` file
## Task Description
 Your task is to program the controller to a robot. It�s a simple robot that can
 walk around in a room where the floor is represented as a number of fields in a
 wire mesh. Input is first two numbers, which tells the robot how big the room is:
 ```
 5 7
 ```
 Which means that the room is 5 fields wide and is 7 fields deep.

 The size of the room follows two digits and one letter indicating the starting
 position of the robot and its orientation in space. For example:
 ```
3 3 N
```
 Which means that the robot is in field (3, 3) and faces north. Subsequently, the
 robot receives a number of navigation commands in the form of characters. The
 following commands shall be implemented:

- L Turn left
- R Turn right
- F Walk forward

 Example:
 ```
 LFFRFRFRFF
 ```
 If the robot walks outside of the room bounds an appropriate the program should
 exit with an error code.

 After the last command is received, the robot must report which field it is in
 and what direction it is facing.

 Example:
 ```
 5 5
 1 2 N
 RFRFFRFRF
 Report: 1 3 N
 ```
 ```
 5 5
 0 0 E
 RFLFFLRF
 Report: 3 1 E
 ```
