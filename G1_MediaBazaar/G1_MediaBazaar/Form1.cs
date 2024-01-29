using UserLibrary;
using SharedLibrary;

namespace G1_MediaBazaar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string input = tbLoginEmailOrEmployeeId.Text;
                string pwd = tbLoginPassword.Text.Trim();
                if (input == "" || pwd == "")
                {
                    MessageBox.Show("Username and password must both be entered.");
                }
                User confirmation = MediaBazzar.Instance.UserManager.AuthenthicateUser(input, pwd);
                if (confirmation == null)
                {
                    MessageBox.Show("Credentials did not match");
                }
                else if (confirmation is Administrator administrator)
                {
                    MenuAdministrator menu = new MenuAdministrator(); //global admin account
                    this.Hide();
                    menu.ShowDialog();
                }
                else if (confirmation is Manager manager)
                {
                    MenuDepartmentManager menu = new MenuDepartmentManager((Manager)confirmation);
                    this.Hide();
                    menu.ShowDialog();
                }
                else if (confirmation is Employee employee)
                {
                    MenuEmployee menu = new MenuEmployee((Employee)confirmation);
                    this.Hide();
                    menu.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbLoginEmailOrEmployeeId_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Form> formsToClose = new List<Form>();
                foreach (Form form in Application.OpenForms)
                {
                    formsToClose.Add(form);
                }
                foreach (Form form in formsToClose)
                {
                    form.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbLoginEmailOrEmployeeId_Enter(object sender, EventArgs e)
        {

        }

        private void tbLoginPassword_Enter(object sender, EventArgs e)
        {
            tbLoginPassword.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 forgotpwd = new Form2();
            this.Hide();
            forgotpwd.ShowDialog();
            this.Close();
        }
    }
}