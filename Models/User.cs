namespace Cook_Book.Models
{
    public class User
    {
        string UserId;
        string UserName;
        string UserTel;
        string UserEmail;
        string UserPassword;

        public User(string UserId, string UserName, string UserTel, string UserEmail, string UserPassword)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserTel = UserTel;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
        }
        public string GetUserId()
        {
            return this.UserId;
        }
        public void SetUserId(string UserId)
        {
            this.UserId = UserId;
        }
        public string GetUserName()
        {
            return this.UserName;
        }
        public void SetUserName(string UserName)
        {
            this.UserName = UserName;
        }
        public string GetUserTel()
        {
            return this.UserTel;
        }
        public void SetUserTel(string UserTel)
        {
            this.UserTel = UserTel;
        }
        public string GetUserEmail()
        {
            return this.UserEmail;
        }
        public void SetUserEmail(string UserEmail)
        {
            this.UserEmail = UserEmail;
        }
        public string GetUserPassword()
        {
            return this.UserPassword;
        }
        public void SetUserPassword(string UserPassword)
        {
            this.UserPassword = UserPassword;
        }


    }
}
