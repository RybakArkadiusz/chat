using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using server.messages;

namespace server
{

    public class Message
    {
        public MessageType Type { get; set; }
        public Dictionary<string,string> Data { get; set; }

        public Message(MessageType type, Dictionary<string,string> data)
        {
            Type = type;
            Data = data;
        }

        public datas convertToData()
        {
            switch (Type)
            {
               
                case MessageType.Login:
                    LoginData loginData = new LoginData(Data["username"],Data["password"]);
                    return loginData;
                    break;
                    
                default:
                    return new LoginData(null,null);
                    break;
                
            }
        }
    }
}