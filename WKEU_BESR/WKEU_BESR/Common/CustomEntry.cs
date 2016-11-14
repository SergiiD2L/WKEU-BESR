using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WKEU_BESR.Common
{
    public class CustomEntry : Entry
    {
        public CustomEntry() : base()
        {
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
        }
    }
}
