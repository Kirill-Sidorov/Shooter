using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public abstract class ControllerCommon
    {
        protected ControllerMain _controller;

        public ControllerCommon(ControllerMain parControllerMain)
        {
            _controller = parControllerMain;
        }

        public abstract void Start();

        public abstract void Stop();
    }
}
