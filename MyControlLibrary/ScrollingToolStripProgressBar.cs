using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace MyControlLibrary
{
    public partial class ScrollingToolStripProgressBar 
        : ToolStripProgressBar
    {
        //FIELDS
        protected Timer timer;


        //PROPERTIES
        public Boolean ScrollBarEnabled
        {
            get { return timer.Enabled; }

            set
            {
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
        }


        //INITIALIZE
        public ScrollingToolStripProgressBar()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);

            this.RightToLeftLayout = true;
        }


        //EVENTS
        protected virtual void timer_Tick(object sender, EventArgs e)
        {
            switch (this.RightToLeft)
            {
                case RightToLeft.No:

                    if ((Value == 0) || (Value == 100))
                    {
                        this.RightToLeft = RightToLeft.Yes;
                        
                        Value = 99;
                    }
                    else
                    {
                        Value += 1;
                    }

                    break;

                case RightToLeft.Yes:

                    if ((Value == 0) || (Value == 100))
                    {
                        this.RightToLeft = RightToLeft.No;

                        Value = 1;
                    }
                    else
                    {
                        Value -= 1;
                    }

                    break;

                default:

                    Debug.WriteLine("An unexpected 'RightToLeft' value was encountered.  " + Value);

                    Value = 1;

                    break;
                    //throw new Exception("An unexpected 'RightToLeft' value was encountered.");
                    
            }
        }


        //METHODS
        public virtual void Start()
        {
            if (!ScrollBarEnabled)
            {
                this.RightToLeft = RightToLeft.No;

                Value = 1;

                timer.Start();
            }
        }

        public virtual void Stop()
        {
            timer.Stop();

            Value = 0;

            this.RightToLeft = RightToLeft.No;
        }
    }
}