using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    sealed class Caretaker
    {
        private Memento memento;

        public Memento Momento
        {
            get { return this.memento; }
            set { this.memento = value; }
        }
    }
}
