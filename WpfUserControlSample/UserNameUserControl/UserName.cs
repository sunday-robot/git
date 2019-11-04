namespace UserNameControl
{
    /// <summary>
    /// UserNameControlのバインディングプロパティ用の型
    /// </summary>
    public sealed class UserName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public UserName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
