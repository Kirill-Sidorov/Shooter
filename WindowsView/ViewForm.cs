using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsView
{
    public class ViewForm
    {

        private static Form _formInstance;

        private ViewForm()
        {
        }

        public static Form GetInstance()
        {
            if (_formInstance == null)
            {
                _formInstance = new Form();
                _formInstance.Size = new Size(1000, 800);
                _formInstance.StartPosition = FormStartPosition.CenterScreen;
            }
            return _formInstance;
        }
    }
}
