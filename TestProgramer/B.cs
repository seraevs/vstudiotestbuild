using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgramer
{
    public class B : A
    {
        //public void Foo()
        public override void Foo()
        {
            MessageBox.Show("Class B");
        }

        public override void Print1()
        {
            MessageBox.Show("B");
        }
    }
}
