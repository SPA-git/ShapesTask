# Задание:

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным


# Solution
The next features were implemented:
## 1. LibShapesArea - library for area calculation
The library provides the next classes implementing ```IShape``` interface:
- Circle
- Triangle

Every class must implement its own ```CalculateArea()``` method

---
#### To calculate the area
1. Create the shape using parameterized constructor. Ex: ```new Circle(25);```
2. Call the method ```CalculateArea()``` using either the shape type itself or in IShape interface

---
#### To check if the triangle is right:
>Проверку на то, является ли треугольник прямоугольным
1. Call the method ```IsRight()``` using the ```Triangle``` type

---
#### To add new shape to the lib:
> Легкость добавления других фигур
1. Create new class implementing interface ```IShape```
2. Implement ```CalculateArea()``` method

## 3. Unit tests for the lib

## 2. ConsoleShapesArea - CLI client for demo how to use the lib
If I understand the next requirement correctly, we need to implement anything that could illustrate how to calculate the area not knowing the shape type in compile-time
> Вычисление площади фигуры без знания типа фигуры в compile-time

#### This CLI client:
1. Requests for user's input
2. Calculates the area for accepted shape

## 4. LibShapeReader - additional lib for input shape from keyboard