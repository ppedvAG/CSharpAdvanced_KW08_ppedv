using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{
    public class BusinessLogicComponentB
    {
        //Komponente bietet seine Events nach aussen hin an
        public event EventHandler ProcessComplet;
        public event EventHandler PercentValueChanged;

        public void StartProcess()
        {
            for (int i = 0; i <= 100; i++)
                OnPercentValueChangedAlternativ(i);
        }
        
        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessComplet?.Invoke(this, e);
        }

        protected virtual void OnPercentValueChangedAlternativ(int i)
        {
            MyPercentEventArgs myPercentEventArgs = new MyPercentEventArgs();
            myPercentEventArgs.PercentValue = i;
            
            PercentValueChanged?.Invoke(this, myPercentEventArgs);
        }

    }

    public class MyPercentEventArgs : EventArgs
    {
        public int PercentValue { get; set; }   
    }
}
