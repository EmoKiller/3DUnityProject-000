
public class BaseAttribute
{
    public AttributeType type;
    public float value;
    public BaseAttribute()
    {

    }

    public BaseAttribute(AttributeType type, float value)
    {
        this.type = type;
        this.value = value;
    }

    public BaseAttribute(BaseAttribute obj)
    {
        this.type = obj.type;
        this.value = obj.value;
    }
}
