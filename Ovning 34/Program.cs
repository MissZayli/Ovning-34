using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ovning_34
{
    #region Uppgift 4
    class Introducer
    {
        string s;

        public Introducer()
        {
            s = "Hello thread";
        }

        public void Run()
        {
            Console.Write(s);
        }
    }
    #endregion
    #region Uppgift 5
    class Contact
    {
        public string firstName;
        public string lastName;

        public Contact()
        {
            firstName = "Påkan";
            lastName = "Johanzzor";
        }
        public void Hello()
        {
            Console.WriteLine(firstName + " " + lastName);
        }
    }
    #endregion
    #region Uppgift 6
    class Queue
    {

        public List<string> messages = new List<string>();

        public void ReadMessage()
        {
            string message = "";
            while (true)
            {
                lock (messages)
                {
                    while (messages.Count == 0)
                    {
                        Monitor.Wait(messages);
                        Console.WriteLine("WAITING");
                    }

                    message = messages.ElementAt(0);
                    messages.RemoveAt(0);
                }

                Console.WriteLine(message);
            }
        }

        public void WriteMessage(string message)
        {
            lock (messages)
            {
                messages.Add(message);
                Monitor.Pulse(messages);
            }
        }
    }

    class Producer
    {
        Queue que;

        public Producer(Queue q)
        {
            que = q;
        }
        public void WriteMessage()
        {
            while (true)
            {
                que.WriteMessage("HELLoo");
                Thread.Sleep(2000);
            }
        }
    }

    class Consumer
    {
        Queue que;
        public Consumer(Queue q)
        {
            que = q;
        }
        public void ReadMessage()
        {
            que.ReadMessage();
        }
    }


    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region Uppgift 1-3
            //Thread t1 = new Thread(Write);
            //t1.Start("y");
            ////Write("x");

            //t1.Join();

            //Console.Write("Hej!");
            #endregion

            #region Uppgift 4
            //Introducer myIntroducer = new Introducer();

            //Thread t2 = new Thread(myIntroducer.Run);
            //t2.Start();
            #endregion

            #region Uppgift 5

            Thread t5 = new Thread(new Contact().Hello);
            t5.Start();

            #endregion

            #region Uppgift 6
            //Queue aQueue = new Queue();

            //Thread[] readerArray = new Thread[5];
            //for (int i = 0; i < readerArray.Length; i++)
            //{
            //    readerArray[i] = new Thread(new Consumer(aQueue).ReadMessage);
            //    readerArray[i].Name = "AThread " + i;
            //    readerArray[i].Start();
            //}
            //Thread[] writerArray = new Thread[5];

            //for (int i = 0; i < writerArray.Length; i++)
            //{
            //    writerArray[i] = new Thread(new Producer(aQueue).WriteMessage);
            //    writerArray[i].Name = "AnotherThread " + i;
            //    writerArray[i].Start();
            //}

            #endregion

            #region Extra Uppgift

            //List<Contact> contacts = new List<Contact> {
            //    new Contact(),
            //    new Contact(),
            //    new Contact(),
            //    new Contact(),
            //    new Contact(),
            //    new Contact(),
            //    new Contact(),
            //    new Contact()
            //};
            //string myString = JsonConvert.SerializeObject(contacts);
            //Console.WriteLine(myString);
            #endregion
        }
        #region Uppgift 1-3
        private static void Write(object m)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(m);
            }
        }
        #endregion
    }
}
