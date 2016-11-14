using System;
using WKEU_BESR.Events;
using WKEU_BESR.ViewModels;

namespace WKEU_BESR.Events
{
    internal sealed class NavigationMessage : IMessage
    {
        public NavigationMessage(Type targetType, Action<IViewModel> stateAction = null)
        {
            TargetType = targetType;
            StateAction = stateAction;
        }

        public Type TargetType { get; private set; }

        public Action<IViewModel> StateAction { get; set; }

    }
}