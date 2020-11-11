using AppService.Interfaces;
using System;
using System.Collections;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace AppService.Class
{
    public class AppServices : IAppServices
    {
        public AppServices()
        {
        }

        public Queue ConfigToQueue(string str)
        {
            String value = str;
            Char delimiter = ';';
            String[] substrings = value.Split(delimiter);
            Queue myQ = new Queue();
            substrings.ToList().ForEach(n =>
            {
                Char newDelimiter = '=';
                String[] substrings2 = n.Split(newDelimiter);
                substrings2.ToList().ForEach(x =>
                {
                    myQ.Enqueue(x);
                });
            });
            return myQ;
        }

        //public Queue GetRoles(Queue myQ) // Entrega solamente roles 
        //{
        //    Queue otherQueue = new Queue();
        //    myQ.ToArray().ToList().ForEach(v =>
        //    {
        //        if (myQ.Count != 1)
        //        {
        //            var aRole = myQ.Dequeue();
        //            otherQueue.Enqueue(aRole);
        //            var aLog = myQ.Dequeue();
        //        }
        //    });
        //    return otherQueue;
        //}
    }
}
