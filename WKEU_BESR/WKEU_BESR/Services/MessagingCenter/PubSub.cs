using System;
using WKEU_BESR.Events;
using WKEU_BESR.Services.MessagingCenter;

namespace WKEU_BESR.Services.MessagingCenter
{
    internal sealed class PubSub : IPubSub
    {
        public void Publish<T>(T argument) where T : IMessage
        {
            Xamarin.Forms.MessagingCenter.Send(new object(), typeof(T).FullName, argument);
        }

        public void SubScribe<T>(object subscriber, Action<T> callBack)
            where T : IMessage
        {
            Xamarin.Forms.MessagingCenter.Subscribe<object, T>(subscriber, typeof(T).FullName, (sender, args) => callBack(args));
        }

        public void UnSubScribe<T>(object subscriber) where T : IMessage
        {
            Xamarin.Forms.MessagingCenter.Unsubscribe<object, T>(subscriber, typeof(T).FullName);
        }
    }
}