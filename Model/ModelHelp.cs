using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelHelp
    {
        public string Text { get; private set; }

        public ModelHelp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Инструкция игры ");
            stringBuilder.Append("\n");
            Text = stringBuilder.ToString(); ;
        }
    }
}
