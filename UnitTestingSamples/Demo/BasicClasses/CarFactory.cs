namespace Demo
{
    public class CarFactory
    {
        public Car Create(bool isFiat)
        {
            if(isFiat)
                return new Fiat();
            else
                return new Ford();
        }
    }
}
