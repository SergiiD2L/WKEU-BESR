using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKEU_BESR.Models;

namespace WKEU_BESR.Events
{
    public sealed class Message : IMessage
    {
        public enum MessageType
        {
            PutSelectedValuesToCache,
            SuccessfulyAuthorized,
            TokenExpired,
            SelectedFilterValueChanged,
            BidlistScrolledToEnd,
            BidSuccessfullyCreated,
            OnAppearedWithoutLogin,
            UserExit
        }       

        public MessageType msg;

        public Message(MessageType type)
        {
            msg = type;
        }
    }
}
