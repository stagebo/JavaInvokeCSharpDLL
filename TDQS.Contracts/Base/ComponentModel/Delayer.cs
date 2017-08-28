using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TDQS.ComponentModel
{
    public sealed class Delayer : IExecutor
    {
        public Delayer(double interval, DelayCallback action)
        {
            m_interval = interval;
            m_timer = new Timer(m_interval);
            m_timer.Elapsed += new ElapsedEventHandler(OnElapsed);
            m_action = action;
            m_running = false;
        }

        public Delayer(DelayCallback action)
            : this(1000, action)
        {
        }

        public void Execute(object state)
        {
            if (m_action == null)
            {
                return;
            }
            m_timer.Enabled = false;
            m_timer.Interval = m_interval;
            m_state = state;
            m_running = true;
            m_timer.Enabled = true;
        }

        public void Stop()
        {
            m_timer.Enabled = false;
            m_running = false;
        }

        void OnElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                m_action(m_state);
            }
            catch (Exception exception)
            {
                if (Error == null)
                {
                    return;
                }
                MethodAccessException ex = new MethodAccessException("方法调用异常。", exception);
                Error(ex);
            }
            finally
            {
                m_timer.Enabled = false;
                m_running = false;
            }
        }

        public bool Running
        {
            get
            {
                return m_running;
            }
        }

        public double Interval
        {
            get
            {
                return m_interval;
            }
            set
            {
                if (m_interval == value)
                {
                    return;
                }
                m_interval = value;
            }
        }

        private double m_interval;
        private Timer m_timer;
        private DelayCallback m_action;
        private bool m_running;
        private object m_state;
        public event ExceptionCallback Error;
    }
}
