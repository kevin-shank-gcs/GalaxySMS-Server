﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;

namespace GCS.Framework.MessageQueue.Messaging
{
    public class Message
    {
        public enum MessagePriority { Lowest, VeryLow, Low, Normal, AboveNormal, High, VeryHigh, Highest }
        public Type BodyType
        {
            get { return Body.GetType(); }
        }

        private object _body;

        public object Body
        {
            get { return _body; }
            set
            {
                _body = value;
                MessageType = _body.GetMessageType();
            }
        }

        public string ResponseAddress { get; set; }

        public string MessageType { get; set; }


        // Some queues do not support Priority and Recoverable. MSQM does
        public MessagePriority Priority { get; set; } = MessagePriority.Normal;
        public bool Recoverable { get; set; }

        public TBody BodyAs<TBody>()
        {
            return (TBody)Body;
        }

        public static Message FromJson(Stream jsonStream)
        {
            var message = jsonStream.ReadFromJson<Message>();
            //the body is a JObject at this point - deserialize to the real message type:
            message.Body = message.Body.ToString().ReadFromJson(message.MessageType);
            return message;
        }

        public static Message FromJson(string json)
        {
            var message = json.ReadFromJson<Message>();
            //the body is a JObject at this point - deserialize to the real message type:
            message.Body = message.Body.ToString().ReadFromJson(message.MessageType);
            return message;
        }
    }
}
