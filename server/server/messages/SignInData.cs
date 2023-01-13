namespace server.messages;

public class SignInData : datas
{
    private string username { get; set; }
    private string password { get; set; }
    private string nickname { get; set; }


    public SignInData(string username, string password,string nickname)
    {
        this.username = username;
        this.password = password;
        this.nickname = nickname;
    }
    public string execute()
    {
        var result = DbManager.Instance.Select($"SELECT * FROM login_details WHERE login = '{username}'");
        if (result.Tables[0].Rows.Count == 0)
        {
            DbManager.Instance.Insert("insert into login_details (login, password, nickname) values ('" + username + "','" + password +
                                      "','" + nickname+"');");
            throw new Exception("account creation successful");
        }
        else
        {
            throw new Exception("User with this username already exists!");
        }
        

    }
    
}