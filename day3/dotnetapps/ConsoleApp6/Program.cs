using System;
using System.Collections.Generic;

struct Point2D
{
    public int x, y; 
}

class Point3D
{
    public int x, y, z; 
}

class Program
{
    static void Main()
    {
        int[] numbers = new int[] { 10, 20, 30, 40, 50 }; 
        for(int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]); 
        }

        Point2D[] points = new Point2D[5];
        points[0] = new Point2D();
        points[1] = new Point2D();
        points[2] = new Point2D();
        points[3] = new Point2D();
        points[4] = new Point2D();

        for (int i = 0; i < points.Length; i++)
        {
            Console.WriteLine($"x: {points[i].x} , y: {points[i].y}");
        }

        Point3D q1 = new Point3D();

        Point3D[] q3 = new Point3D[5];
        q3[0] = new Point3D();
        q3[1] = new Point3D();
        q3[2] = new Point3D();
        q3[3] = new Point3D();
        q3[4] = new Point3D();

        for (int i = 0; i < q3.Length; i++)
        {
            Console.WriteLine($"x: {q3[i].x} , y: {q3[i].y} , z: {q3[i].z}");
        }

    }
}

