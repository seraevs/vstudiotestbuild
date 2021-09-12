using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgramer
{
    public class A
    {
       public virtual void Foo()
       {
            MessageBox.Show("Class A");
       }


        public virtual void Print1()
        {
            MessageBox.Show("A");
        }
        public void Print2()
        {
            MessageBox.Show("A");
        }
    }
}

