using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MenuItem
    {
        public event DModel Selected = null;

        private Status _status;
        public string Name { get; private set; }

        public Status CurrentStatus
        {
            get { return _status; }
            set
            {
                _status = value;
                if (_status == Status.SELECTED)
                {
                    _status = Status.FOCUSED;
                    Selected?.Invoke();
                }
            }
        }

        public MenuItem(string parName)
        {
            Name = parName;
            _status = Status.NORMAL;
        }
    }
}
