using System;


namespace MyControlLibrary
{
    public partial class WindowsForm 
        : System.Windows.Forms.Form
    {
        //PROPERTIES
        public virtual Boolean ScrollingProgressBarEnabled
        {
            get { return scrollingToolStripProgressBar.ScrollBarEnabled; }

            set { scrollingToolStripProgressBar.ScrollBarEnabled = value; }
        }

        public virtual String StatusLabel
        {
            get { return toolStripStatusLabel.Text; }

            set { toolStripStatusLabel.Text = value; }
        }


        //INITIALIZE
        public WindowsForm()
        {
            InitializeComponent();
        }
    }
}