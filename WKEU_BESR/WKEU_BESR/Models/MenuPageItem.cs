using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKEU_BESR.Models
{
    internal sealed class MenuPageItem
    {
        public MenuPageItem()
        {
            ActionType = ActionTypes.Navigation;
        }

        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }

        public ActionTypes ActionType { get; set; }
    }
}
