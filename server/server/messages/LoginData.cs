namespace server.messages;

public class LoginData : datas
{
    private string username { get; set; }
    private string password { get; set; }
    

    public string execute()
    {
        var result = DbManager.Instance.Select($"SELECT * FROM login_details WHERE login = '{username}'");
        
        if (result.Tables[0].Rows.Count == 0)
        {
            throw new Exception("The username does not exist in the database");
        }
        else
        {
            var row = result.Tables[0].Rows[0];
            if (row["password"].ToString().Equals(password))
            {

                return (string)row["nickname"];
            }
            else
            {
                throw new Exception("Incorrect password");
            }
        }
        
    }
}