namespace Cook_Book.Models
{

    public class UserData
    {
        string userId;
        string userName;

        public UserData(string userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
        }
        public string GetUserId()
        {
            return this.userId;
        }
        public void SetUserId(string UserId)
        {
            this.userId = UserId;
        }
        public string GetUserName()
        {
            return this.userName;
        }
        public void SetUserName(string UserName)
        {
            this.userName = UserName;
        }

    }
    public class User: UserData
    {
       
        string userTel;
        string userEmail;
        string userPassword;

        public User(string userId, string userName, string userTel, string userEmail, string userPassword) 
            : base(userId, userName)
        {
          
            this.userTel = userTel;
            this.userEmail = userEmail;
            this.userPassword = userPassword;
        }

     
        public string GetUserTel()
        {
            return this.userTel;
        }
        public void SetUserTel(string userTel)
        {
            this.userTel = userTel;
        }
        public string GetUserEmail()
        {
            return this.userEmail;
        }
        public void SetUserEmail(string userEmail)
        {
            this.userEmail = userEmail;
        }
        public string GetUserPassword()
        {
            return this.userPassword;
        }
        public void SetUserPassword(string userPassword)
        {
            this.userPassword = userPassword;
        }


    }
}
