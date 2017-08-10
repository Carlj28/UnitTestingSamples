namespace Demo.MoqClasses
{
    public interface IUserData
    {
        string GetUserData();

        string GetUserData(string param);

        string InsertUserData(SomeUserData param);
    }
}
