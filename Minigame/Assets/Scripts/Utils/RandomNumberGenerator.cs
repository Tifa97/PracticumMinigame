using System;

public class RandomNumberGenerator
{
    public static Random rnd = new Random();

    public static int RandomNumber()
    {
        return rnd.Next(-2, 2);
    }
}
