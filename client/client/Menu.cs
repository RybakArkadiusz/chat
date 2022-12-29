using System.Runtime.CompilerServices;

namespace client;

public class Menu
{
    private bool isLogged;

    public Menu()
    {
        isLogged = false;
    }

    public void setIsLogged(bool isLogged)
    {
        this.isLogged = isLogged;
    }

    public string run()
    {
        if (!isLogged)
        {
            Console.WriteLine("1. Sign in.");
            Console.WriteLine("2. Create an account.");

            string o = Console.ReadLine();
            if (!(o.Equals("1") || o.Equals("2")))
            {
                Console.WriteLine("Wrong input");
                run();
            }

            switch (o)
            {
                case "1":
                    return login();
                    break;
                case "2":
                    return signIn();
                    break;
                default:
                    return run();
                    break;


            }
            
        }
        else
        {
            Console.WriteLine("1. Open existing conversation");
            Console.WriteLine("2. Create new conversation");
            string o = Console.ReadLine();
            if (!(o.Equals("1") || o.Equals("2")))
            {
                Console.WriteLine("Wrong input");
                run();
            }

            switch (o)
            {
                case "1":
                    return GetConversations();
                    break;
                case "2":
                    
                    break;
                default:
                    return run();
                break;
            }
            
        }

        return null;
    }

    private string login()
    {
        Console.WriteLine("Username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        Message loginMessage = new Message(MessageType.Login, new { username = username, password = password });
        return loginMessage.ToJson();
    }

    private string signIn()
    {
        Console.WriteLine("Username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        Console.WriteLine("Nickname: (this will be your name displayed to other users)");
        string nickname = Console.ReadLine();
        Message signInMessage = new Message(MessageType.CreateAccount,
            new { username = username, password = password, nickname = nickname });
        return signInMessage.ToJson();
    }

    private string GetConversations()
    {
        Message GetConversationMessage = new Message(MessageType.GetConversations,null);
        return GetConversationMessage.ToJson();
    }

    private string CreateConversation()
    {
        Console.WriteLine("Addressee's nickname: ");
        string? addresseesNickname = Console.ReadLine();
        Console.WriteLine("Message:");
        string? content = Console.ReadLine();

        Message CreateConversationMessage = new Message(MessageType.CreateConversation,
            new { nickname = addresseesNickname, content = content });
        return CreateConversationMessage.ToJson();
    }
}