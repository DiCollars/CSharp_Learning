using MVP_BLL;
using System.ComponentModel;

namespace MVP
{
    [Bindable(true)]
    public partial class Form1 : Form, IUserInfo
    {
        private UserInfoPresenter _infoPresenter { get; set; }

        public Form1()
        {
            InitializeComponent();
            this._infoPresenter = new UserInfoPresenter(this);
        }

        public bool ShowFormMessage { get => this.ErrorMessage.Visible; set => this.ErrorMessage.Visible = value; }
        string IUserInfo.FirstName { get => this.FirstNameTextBox.Text; set => this.FirstNameTextBox.Text = value; }
        string IUserInfo.LastName { get => this.LastNameTextBox.Text; set => this.LastNameTextBox.Text = value; }
        string IUserInfo.Email { get => this.EmailTextBox.Text; set => this.EmailTextBox.Text = value; }
        string IUserInfo.Phone { get => this.PhoneTextBox.Text; set => this.PhoneTextBox.Text = value; }
        string IUserInfo.ErrorMessage { get => this.ErrorMessage.Text; set => this.ErrorMessage.Text = value; }

        public event EventHandler? SaveAttempted;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveAttempted?.Invoke(this, EventArgs.Empty);
        }
    }
}