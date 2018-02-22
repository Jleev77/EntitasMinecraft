public struct Vector3f
{
    public Vector3f(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public float X;
    public float Y;
    public float Z;

    public static Vector3f operator +(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
}