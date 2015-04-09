// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/9/2013 10:35:08 PM
// ------------------------------------------------------------------------------------

namespace System.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class MyListView : ListView
    {
        public MyListView()
        {
            InitializeComponent();

            // Set true to prevent blinking when updating ListView
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
