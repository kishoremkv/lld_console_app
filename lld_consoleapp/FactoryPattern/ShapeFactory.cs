namespace lld_console_app.FactoryPattern;

/// <summary>
/// ShapeFactory has the objects of different shapes. So HAS-A relationship.
/// </summary>
public class ShapeFactory
{
    IShape Shape;

    public IShape GetShape(int shapeId)
    {
        switch(shapeId)
        {
            case 1:
                this.Shape = new Circle();
                break;
            case 2: 
                this.Shape = new Rectangle();
                break;
            default: 
                break;
        }

        return this.Shape;
        
    }
}