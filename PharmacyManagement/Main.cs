using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmacyManagement.View;

namespace PharmacyManagement
{
    public partial class Main : XtraForm
    {
        #region Global variable
        SignIn signIn = new SignIn();
        #endregion
        public Main()
        {
            //Flash flash = new Flash();
            //flash.ShowDialog();

            SignIn();
            InitializeComponent(); 
        }

        public void SignIn()
        {
            if (!signIn.IsDisposed) 
                signIn.ShowDialog();
        }
    }
}
