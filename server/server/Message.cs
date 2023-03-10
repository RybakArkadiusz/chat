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
                    LoginData login = new LoginData(Data["username"],Data["password"]);
                    return login;
                    break;
                case MessageType.CreateAccount:
                    SignInData createAcc = new SignInData(Data["username"],Data["password"],Data["nickname"]);
                    return createAcc;
                    break;
                case MessageType.CreateConversation:
                    NewMessageData newMessage = new NewMessageData(Data["receiverNickname"],Data["senderNickname"], Data["content"]);
                    return newMessage;
                    break;
                default:
                    return new LoginData(null,null);
                    break;
                
            }
        }
    }
}