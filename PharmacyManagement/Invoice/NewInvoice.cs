using DevExpress.XtraEditors;
using PharmacyManagement.DB_query;

namespace PharmacyManagement
{
    public partial class NewInvoice : XtraForm
    {
        private string employeeID;
        PharmacyMgtDatabase dataTable = new PharmacyMgtDatabase();
        public NewInvoice()
        {
            InitializeComponent();
        }

        public string EmployeeID { get => employeeID; set => employeeID = value; }
    }
}