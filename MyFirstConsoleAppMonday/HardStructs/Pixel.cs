namespace MyFirstConsoleAppMonday.HardStructs
{
    public struct Pixel
    {
        public byte red;
        public byte green;
        public byte blue;

        public void paint()
        {
            Console.WriteLine("RGB({0}, {1}, {2})", red, green, blue);
        }
    }

}
