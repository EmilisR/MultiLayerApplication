namespace User.Service
{
    public static class StandardUserFactory
    {
        public static User CreateUser()
        {
            return new User()
            {
                IsAdmin = false
            };
        }
    }


    public static class AdminUserFactory
    {
        public static User CreateUser()
        {
            return new User()
            {
                IsAdmin = true
            };
        }
    }
}
