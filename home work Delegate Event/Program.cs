using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Deligate
            //int[] arr =new int[] { 5,6,7,8,9,10,12,14};
            //Console.WriteLine(Add(Older,arr).ToString());
            //SendMessage sending = new SendMessage(send);
            //sending += Give;
            //sending += Show;
            //sending("slam a a amma");
            #endregion

            ATM mainAtm = new ATM();
            mainAtm.onBalancelow += DD;
            mainAtm.onBalancelow += AA;
            mainAtm.BZ += Zr;
            
            mainAtm.TopUp(3000);
            mainAtm.WithDraw(3000);








        }
        static void DD(object sender,ATMARG e)
        {
            Console.WriteLine("ATM de balans 1000 AZN den azdir");
        }
        static void AA(object sender ,ATMARG e)
        {
            

            Console.WriteLine("Current balance "+e.CurrentBalance.ToString()+" Date Time "+e.Atime.ToString());
        }
        static void Zr(object sender,ATMARG2 e)
        {
            Console.WriteLine("ZZZZ zaman" + e.Atime.ToString() + e.CurrenttBalance.ToString()+ " Pul vardi ");
        }

        #region Deligate
        //public delegate void SendMessage(string sentences);
        //public delegate bool Ceck(int n);
        //static int Add(Ceck clb,int[] Arra)
        //{
        //    int s = 0;
        //    foreach(var x in Arra)
        //    {
        //        if (clb(x))
        //        {
        //            s += x;
        //        }

        //    }
        //    return s;
        //}
        //static bool Older(int x)
        //{
        //    return x % 2 == 0;
        //}
        //static void send(string x)
        //{
        //    Console.WriteLine(x + " Send Message");
        //}
        //static void Give(string x)
        //{
        //    Console.WriteLine(x + " Given Messages");
        //}
        //static void Show(string x)
        //{
        //    Console.WriteLine(x + " Show Messages ");
        //}

        #endregion Deligate Deligate

        class ATM
        {
            public delegate void BalanceLow(object sender ,ATMARG e);
            public delegate void BalZero(object sender, ATMARG2 e);
            public event BalZero BZ;
            public event BalanceLow onBalancelow;
            public decimal Balance { get;private set; }
            public void WithDraw(decimal Amount)
            {
                decimal crb = Balance;
                if (Balance >= Amount)
                {
                    Balance -= Amount;
                    Console.WriteLine($"{Amount} AZN Cixildi");
                }
                if (Balance < 1000)
                {

                    onBalancelow?.Invoke(this, new ATMARG { CurrentBalance = Balance, Atime = DateTime.Now });
                    
                }
                if (Balance == 0)
                {
                    BZ?.Invoke(this, new ATMARG2 { Atime = DateTime.Now, CurrenttBalance = crb });
                }

            }
            public void TopUp(decimal Amount)
            {
                if (Amount > 0)
                {
                    Balance += Amount;
                    Console.WriteLine($"{Amount} AZN Yuklendi");
                }
                
            }
        }
        class ATMARG : EventArgs
        {
            public decimal CurrentBalance { get; set; }
            public DateTime Atime { get; set; }
        }
        class ATMARG2 : EventArgs
        {
            public decimal CurrenttBalance { get; set; }
            public DateTime Atime { get; set; }
            
        }

    }
}
