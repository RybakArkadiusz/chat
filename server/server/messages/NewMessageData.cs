namespace server.messages;

public class NewMessageData : datas
{
    private string receiver { get; set; }
    private string sender { get; set; }
    private string content { get; set; }

    public NewMessageData(string receiver, string sender, string content)
    {
        this.receiver = receiver;
        this.sender = sender;
        this.content = content;
    }

    public string execute()
    {
        var result = DbManager.Instance.Select($"SELECT * FROM login_details WHERE nickname = '{receiver}'");
        if (result.Tables[0].Rows.Count == 0)
        {
            throw new Exception("User with nickname of " + receiver + " does not exist!");
        }
        else
        {
            var row = result.Tables[0].Rows[0];
            string receiver_id = row["user_id"].ToString();
            var result1 = DbManager.Instance.Select($"SELECT * FROM login_details WHERE nickname = '{sender}'");
            var row1 = result1.Tables[0].Rows[0];
            string sender_id = row1["user_id"].ToString();
            DbManager.Instance.Insert("insert into message_history (sender_id, receiver_id, content) values ('" + sender_id + "','" + receiver_id +
                                      "','" + content+"');");
            throw new Exception("Message got send!");
        }
        

    }
    
}