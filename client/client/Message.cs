using Newtonsoft.Json;

namespace client
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
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}