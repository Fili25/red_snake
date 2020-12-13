using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Threading;
using System.Xml.Linq;
using System.Linq;
namespace SnakeServerCons
{
    class Program
    {
        static int port = 8005;
        static void Main(string[] args)
        {

            work();

        } 


        static void work()
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            string subString;
            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[1024]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);
                    string resmessage = builder.ToString();
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + resmessage);
                    subString = "GamerName=";
                    int indexOfSubstring = resmessage.IndexOf(subString);
                    if (indexOfSubstring == 0)
                    {
                        resmessage = resmessage.Substring(subString.Length);
                        name_score(resmessage);
                    }
                    string message = "ваше сообщение доставлено";
                    subString = "Table";
                    indexOfSubstring = resmessage.IndexOf(subString);
                    if (indexOfSubstring == 0)
                    {
                        message = table();
                    }
                    // отправляем ответ

                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(500);
                listenSocket.Close();
                Thread.Sleep(500);
                work();
            }

        }
        static string table()
        {
            string tb = "";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("BD.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                    if (attr != null)
                        tb += "Имя - " + attr.Value;
                       // Console.WriteLine(attr.Value);
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Score")
                        {
                            tb += "   Рекорд - " + childnode.InnerText + "$";
                           // Console.WriteLine($"Компания: {childnode.InnerText}");
                        }
                    }

                }
            }
                


                return (tb);
        }
        static void name_score(string namescore)
        {
            string name;
            string score;
            string subString = "Score=";
            int indexOfSubstring = namescore.IndexOf(subString);
            name = namescore.Substring(0, indexOfSubstring);
            score = namescore.Substring(indexOfSubstring + subString.Length);

            Console.WriteLine("Имя = " + name);
            Console.WriteLine("Очки = " + score);
            BD_Add(name, score);
        }
        static void BD_Add(string name,string score)
        {
            XDocument xdoc = XDocument.Load("BD.xml");
            XElement root = xdoc.Element("users");
            foreach (XElement xe in root.Elements("Gamer").ToList())
            {
                if (xe.Attribute("Name").Value == name)
                {
                    if (Convert.ToInt32(xe.Element("Score").Value) < Convert.ToInt32(score))
                    {
                        xe.Element("Score").Value = score;
                        xdoc.Save("BD.xml");
                        return;
                    }
                    else { return; }
                    
                }
            }
            

           XmlDocument xDoc = new XmlDocument();
            xDoc.Load("BD.xml");

          




            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement userElem = xDoc.CreateElement("Gamer");
            XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
            XmlElement gameScore = xDoc.CreateElement("Score");
            XmlText NameText = xDoc.CreateTextNode(name);
            XmlText ScoreText = xDoc.CreateTextNode(score);


            nameAttr.AppendChild(NameText);

            gameScore.AppendChild(ScoreText);

            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(gameScore);
            xRoot.AppendChild(userElem);
            xDoc.Save("BD.xml");
        }


    }
}
