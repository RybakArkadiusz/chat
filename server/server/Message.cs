using Newtonsoft.Json;
using server.messages;

namespace server
{

    public class Message
    {
        public MessageType Type { get; set; }
        public object Data { get; set; }

        public Message(MessageType type, object data)
        {
            Type = type;
            Data = data;
        }

        public datas convertToData()
        {
            switch (Type)
            {
                case MessageType.Login:
                    return JsonConvert.DeserializeObject<LoginData>(Data.ToString());
                    break;
                    
                default:
                    return new LoginData();
                    break;
                
            }
        }
    }
}