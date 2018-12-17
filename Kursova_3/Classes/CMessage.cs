using System;
using System.Windows.Threading;

namespace SweetsFactory.Classes.CMessage
{
    enum TypesMessageEnumerstion{
        Ok = 0,
        Normal,
        Wrong
    }
    
    class Message
    {
        // Delegates
        public delegate void OnShowMessage(string str, TypesMessageEnumerstion type);
        public delegate void OnHideMessage();

        // Timer

        DispatcherTimer timer = new DispatcherTimer();

        // Events

        public event OnShowMessage onShowMessage;
        public event OnHideMessage onHideMessage;

        // State

        public bool IsActive { get => timer.IsEnabled; }

        // Functions

        public Message() {
            timer.Tick += OnTimerTick;
        }

        public void ShowMessage(string str, int miliseconds, TypesMessageEnumerstion type) {
            timer.Interval = new TimeSpan(0, 0, 0, 0, miliseconds);
            onShowMessage?.Invoke(str, type);
            timer.Start();
        }

        public void HideMessage()
        {
            OnTimerTick(null, null);
        }

        void OnTimerTick(object obj, EventArgs e) {
            timer.Stop();
            onHideMessage?.Invoke();
        }
    }
}
