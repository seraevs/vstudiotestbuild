using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgramer
{
    public class C : B
    {
        new public void Print2()
        {
            MessageBox.Show("C");
        }
    }
}
