using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecognize.MVVM.Client.ViewModel
{
    public class LoginControlVModel : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        public LoginControlVModel()
        {
            this.Title = "登录Login";
        }
    }
}
