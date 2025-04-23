

namespace lld_console_app.FactoryPattern
{
    public class Circle : IShape
    {
        /// <summary>
        /// Circle is a shape. So it has a IS A relationship with IShape. Similarly Rec.
        /// </summary>
        public void draw()
        {
            Console.WriteLine("This is Circle!");
        }
    }
}

