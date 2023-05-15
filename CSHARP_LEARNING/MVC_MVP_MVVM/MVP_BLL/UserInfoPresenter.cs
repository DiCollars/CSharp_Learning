namespace MVP_BLL
{
    public class UserInfoPresenter
    {
        private readonly IUserInfo _form;

        public UserInfoPresenter(IUserInfo form)
        {
            _form = form;
            _form.SaveAttempted += _form_attemted;
            _form.ErrorMessage = "";
        }

        private void _form_attemted(object? sender, EventArgs e)
        {
            _form.ShowFormMessage = false;
            if (string.IsNullOrEmpty(_form.FirstName))
            {
                _form.ShowFormMessage = true;
                if (_form.ErrorMessage.Contains(Consts.FirstNameErr) != true)
                {
                    _form.ErrorMessage = _form.ErrorMessage + Consts.FirstNameErr;
                }
            }
            else
            {
                _form.ErrorMessage = _form.ErrorMessage.Replace(Consts.FirstNameErr, string.Empty);
            }

            if (string.IsNullOrEmpty(_form.LastName))
            {
                _form.ShowFormMessage = true;
                if (_form.ErrorMessage.Contains(Consts.LastNameErr) != true)
                {
                    _form.ErrorMessage = _form.ErrorMessage + Consts.LastNameErr;
                }
            }
            else
            {
                _form.ErrorMessage = _form.ErrorMessage.Replace(Consts.LastNameErr, string.Empty);
            }

            if (string.IsNullOrEmpty(_form.Email))
            {
                _form.ShowFormMessage = true;
                if (_form.ErrorMessage.Contains(Consts.EmailErr) != true)
                {
                    _form.ErrorMessage = _form.ErrorMessage + Consts.EmailErr;
                }
            }
            else
            {
                _form.ErrorMessage = _form.ErrorMessage.Replace(Consts.EmailErr, string.Empty);
            }

            if (string.IsNullOrEmpty(_form.Phone))
            {
                _form.ShowFormMessage = true;
                if (_form.ErrorMessage.Contains(Consts.PhoneErr) != true)
                {
                    _form.ErrorMessage = _form.ErrorMessage + Consts.PhoneErr;
                }
            }
            else
            {
                _form.ErrorMessage = _form.ErrorMessage.Replace(Consts.PhoneErr, string.Empty);
            }
        }
    }
}
