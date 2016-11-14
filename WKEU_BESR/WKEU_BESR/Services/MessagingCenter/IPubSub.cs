using System;
using WKEU_BESR.Events;

namespace WKEU_BESR.Services.MessagingCenter
{
    public interface IPubSub
    {
        void Publish<T>(T argument) where T : IMessage;

        void SubScribe<T>(object subscriber, Action<T> callBack) where T : IMessage;

        void UnSubScribe<T>(object subscriber) where T : IMessage;
    }
}