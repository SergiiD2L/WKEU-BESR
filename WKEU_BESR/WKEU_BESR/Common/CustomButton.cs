using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WKEU_BESR.Common
{
    public class CustomButton : Button
    {
        public CustomButton() : base()
        {
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
        }
    }
}
