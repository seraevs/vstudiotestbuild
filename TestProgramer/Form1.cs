using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgramer
{
    public partial class frmTestProgramer : Form
    {
        public frmTestProgramer()
        {
            InitializeComponent();
        }

        private void btn_J_LONG_O_Click(object sender, EventArgs e)
        {
            int i = 5;
            object o = i;
            //long j = (long)o;

            //MessageBox.Show(j.ToString());
        }

        private void btndivideed_by_2_Click(object sender, EventArgs e)
        {
            // сложения всех чётных чисел в массиве
            int[] intArray;
            intArray = new int[6] { 1, 2, 3, 4, 5, 6 };
            //return intArray.Where(i => i % 2 == 0).Sum(i => (long)i);
            //return (from i in intArray where i % 2 == 0 select (long)i).Sum();
            //MessageBox.Show("Version - 1 " + (intArray.Where(i => i % 2 == 0).Sum(i => (long)i)).ToString());
            MessageBox.Show("Version - 2; sum = " + (from i in intArray where i % 2 == 0 select (long)i).Sum().ToString());
        }

        static String location;
        static DateTime time;
        private void btnCheckPrintOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show(location == null ? "location is null" : location);
            MessageBox.Show(time == null ? "time is null" : time.ToString());
        }

        private double radius;

        public Func<double, double> op;
        private void btnCalculateRadius_Click(object sender, EventArgs e)
        {

            radius = (double)2;
            MessageBox.Show(op(radius).ToString());
        }

        private static string result;
        private void btnTaskDelay_Click(object sender, EventArgs e)
        {
            // программа просто выведет пустую строку (а не «Hello world!»). Это связано с тем, что result будет неинициализирован при вызове Console.WriteLine.
            SaySomething();
            MessageBox.Show(result);
        }

        static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            //System.Threading.Thread.Sleep(3000);
            result = "Hello world!";
            return "Something";
        }

        delegate void Printer();
        private void btnPrintDelegate_Click(object sender, EventArgs e)
        {
            // Какой результат выдаст программа ниже?
            //  по окончании цикла i равно 10, и при каждом запуске delegate будет выводиться работать с этим значением

            List<Printer> printers = new List<Printer>();
            for (int i = 0; i < 5; i++)
            {
                //printers.Add(delegate { Console.WriteLine(i); });
                printers.Add(delegate { MessageBox.Show(i.ToString()); });
                /*foreach (var printer in printers)
                {
                    printer();
                }*/           
            }

            foreach (var printer in printers)
            {
                printer();
            }
        }

        private void btnClassA_B_Click(object sender, EventArgs e)
        {
            //Severity Code	Description	Project	FileLine Suppression State
            //Cannot implicitly convert type 'TestProgramer.A' to 'TestProgramer.B'.An explicit conversion exists (are you missing a cast?)  

            //B obj1 = new A();
            //obj1.Foo();

            B obj2 = new B();
            obj2.Foo();

            A obj3 = new B();
            obj3.Foo();
        }

        private void btnStructure_Click(object sender, EventArgs e)
        {

            var s = new S();
            using (s)
            {
                MessageBox.Show(s.GetDispose().ToString());
            }
            MessageBox.Show(s.GetDispose().ToString());
        }

        public struct S : IDisposable
        {
            // Есть следующая структура:
            // Что будет выведено в следующем случае?
            private bool dispose;
            public void Dispose()
            {
                dispose = true;
            }
            public bool GetDispose()
            {
                //Dispose();
                return dispose;
            }

        }

        private void btnListAction_Click(object sender, EventArgs e)
        {
            // Что будет выведено на консоль?
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 3; count++)
            {
                //actions.Add(() => Console.WriteLine(count));
                actions.Add(() => MessageBox.Show(count.ToString()));
            }

            foreach (var action in actions)
            {
                action();
            }
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
        {
            // Что будет выведено на консоль в результате следующих операций:
            int i = 1;
            object obj = i;
            ++i;
            MessageBox.Show(i.ToString());
            MessageBox.Show(obj.ToString());
            // Specified cast is not valid
            //Console.WriteLine((short)obj);
        }

        private void btnCheckString_Click(object sender, EventArgs e)
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            MessageBox.Show("The S1 = " + s1 + " || The S2 = " + s2);
            MessageBox.Show("The S1 = " + s1.Length + " || The S2 = " + s2.Length);
            Console.WriteLine(s1 == s2);
            Console.WriteLine((object)s1 == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);
        }

        private void btnLockClass_Click(object sender, EventArgs e)
        {
            lock (syncObject)
            {
                Write();
            }

        }

        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Thread.Sleep(1000);
            }
            lock (syncObject)
            {
                MessageBox.Show("test");
            }
        }

        private void btnPrintClass_Click(object sender, EventArgs e)
        {
            // К какому результату приведет выполнение следующего кода:?
            var c = new C();
            A a = c;//implicyty convert type C to A

            a.Print2();
            a.Print1();
            c.Print2();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            // Что будет выведено на консоль в результате выполнения следующего кода?

            var w = new Wrap();
            var wraps = new Wrap[3];
            for (int i = 0; i < wraps.Length; i++)
            {
                wraps[i] = w;
            }

            var values = wraps.Select(x => x.Value);
            var results = Square(values);
            int sum = 0;
            int count = 0;
            foreach (var r in results)
            {
                count++;
                sum += r;
            }
            /*MessageBox.Show("Count = " + count.ToString() + "\n" +
               "Sum = " + sum.ToString() + "\n" +
               "Count = " + results.Count().ToString() + "\n" +
               "Sum = " + results.Sum().ToString() + "\n");*/

            Console.WriteLine("Count {0}", count);
            Console.WriteLine("Sum {0}", sum);

            Console.WriteLine("Count {0}", results.Count());
            Console.WriteLine("Sum {0}", results.Sum());
        }

        static IEnumerable<int> Square(IEnumerable<int> a)
        {
            foreach (var r in a)
            {
                int temp = r * r;
                //MessageBox.Show(temp.ToString());
                Console.WriteLine(r * r);
                yield return r * r;
            }
        }

        private void btnMonitorWait_Click(object sender, EventArgs e)
        {
            // Какой результат выполнения будет у следующего кода?

            object sync = new object();
            var thread = new System.Threading.Thread(() =>
            {
                try
                {
                    Work();
                }
                finally
                {
                    lock (sync)
                    {
                        System.Threading.Monitor.PulseAll(sync);
                    }
                }
            });
            thread.Start();
            lock (sync)
            {
                System.Threading.Monitor.Wait(sync);
            }
            MessageBox.Show("test");
        }
        private static void Work()
        {
            System.Threading.Thread.Sleep(1000);
        }

        private void btnCatchException_Click(object sender, EventArgs e)
        {
            // Какой результат выполнения будет у следующего кода ?

            try
            {
                Calc();
            }
            catch (MyCustomException)
            {
                MessageBox.Show("Catch MyCustomException");
                throw;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Catch Exception");
            }
            Console.ReadLine();
        }

        private static void Calc()
        {
            int result = 0;
            var x = 5;
            int y = 0;
            try
            {
                result = x / y;
            }
            catch (MyCustomException e)
            {
                MessageBox.Show("Catch DivideByZeroException");
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show("Catch Exception");
            }
            finally
            {
                throw new MyCustomException();
            }
        }

        private void btnenumEn_Click(object sender, EventArgs e)
        {
            // Что будет выведено в результате выполнения программы?

            Console.WriteLine((int)En.Second);
            //Console.Read();
        }

        private enum En
        {
            First = 15,
            Second,
            Third,
            Four = 54
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            // Что будет выведено в результате выполнения программы?
            int c = 3;
            MessageBox.Show(Sum(5, 3,  c) + " ");      
            MessageBox.Show(c.ToString());
            //Console.ReadLine();
        }

        //static int Sum(int a, int b, out int c)
        static int Sum(int a, int b, int c)
        {
            return a + b;
        }

        private void btnPrintVar_Click(object sender, EventArgs e)
        {
            // Что будет выведено в результате выполнения программы ?

            //var a = null;
            //a = 10;
            //Console.WriteLine(a);
            Console.ReadLine();
        }

        private void btnCheckExeption_Click(object sender, EventArgs e)
        {
            // Что будет выведено в результате выполнения программы?

            try
            {
                var array = new int[] { 1, 2 };
                MessageBox.Show(array[5].ToString());
            }
            catch (ApplicationException)
            {
                Console.Write("1");
            }
            catch (SystemException)
            {
                MessageBox.Show("2");
            }
            catch (Exception)
            {
                MessageBox.Show("3");
            }
            //Console.ReadLine();
            //array[5] = 7;
        }

        private void btnPrintExeption_Click(object sender, EventArgs e)
        {
            // Что будет выведено в результате выполнения программы?

            var test = new Test();
            try
            {
                test.Print();
            }
            catch (Exception)
            {
                MessageBox.Show("5");
            }
            finally
            {
                MessageBox.Show("4");
            }
            Console.ReadLine();
        }

        static int x = 0;
        static object locker = new object();
        private void btnCheckLocker_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "Поток " + i.ToString();
                myThread.Start();
            }

            //Console.ReadLine();
        }

        public static void Count()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 1; i < 3; i++)
                {
                    MessageBox.Show(Thread.CurrentThread.Name + " : " + x.ToString());
                    x++;
                    Thread.Sleep(100);
                }
            }
        }

        // Создадим делегат
        delegate int IntOperation(int i, int j);
        private void btnUsingDelegate_Click(object sender, EventArgs e)
        {
            // Сконструируем делегат
            IntOperation op1 = new IntOperation(Sum);

            int result = op1(5, 10);
            MessageBox.Show("Sum numbers " + result);

            // Изменим ссылку на метод
            op1 = new IntOperation(Prz);
            result = op1(5, 10);
            MessageBox.Show("Multiply numbers: " + result);

            //Console.ReadLine();
        }

        // Организуем ряд методов
        static int Sum(int x, int y)
        {
            return x + y;
        }

        static int Prz(int x, int y)
        {
            return x * y;
        }

        static int Del(int x, int y)
        {
            return x / y;
        }

        private void btnPrintHashTable_Click(object sender, EventArgs e)
        {
            Hashtable objHashTable = new Hashtable();
            objHashTable.Add(1, 100); // int 
            objHashTable.Add(2.99, 200); // float 
            objHashTable.Add('A', 300); // char 
            objHashTable.Add("4", 400); // string 

            MessageBox.Show(objHashTable[1].ToString());
            MessageBox.Show(objHashTable[2.99].ToString());
            MessageBox.Show(objHashTable['A'].ToString());
            MessageBox.Show(objHashTable["4"].ToString());

            foreach (var v in objHashTable.Values)
            {
                MessageBox.Show(v.ToString());
            }

            // ----------- Not Possible for HashTable ---------- 
            //foreach (KeyValuePair<string, int> pair in objHashTable) 
            //{ 
            // lblDisplay.Text = pair.Value + " " + lblDisplay.Text; 
            //} 
        }

        private void btnPrintDictionary_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("cat", 2);
            dictionary.Add("dog", 1);
            dictionary.Add("llama", 0);
            dictionary.Add("iguana", -1);

            //dictionary.Add(1, -2); // Compilation Error 

            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                MessageBox.Show(pair.Value.ToString());
            }
        }

        private void btnObsoleteAttribute_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckDateTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show(time.ToString());
            // Является ли сравнение time и null в выражении if валидным? Почему?
            //static DateTime time;
            /* ... */
            if (time == null)
            {
                MessageBox.Show("NULL- 1");
            }
        }

        private void btnEMPTY_Click(object sender, EventArgs e)
        {
            string[] arr = new string[] { "alonnnnn", "sergey", "gabi", "test" };

            var longest = arr.Where(s => s.Length == arr.Max(m => m.Length)).First();
            //var longest = (arr.Max(m => m.Length));

            MessageBox.Show(longest.ToString());
        }

        private void btn_Checked_Linked_LIst_Click(object sender, EventArgs e)
        {

            LinkedList llist = new LinkedList();

            llist.push(20);
            llist.push(4);
            llist.push(15);
            llist.push(10);

            /*Create loop for testing */
            llist.head.next.next.next.next = llist.head;

            llist.detectLoop();

        }


    }
}
