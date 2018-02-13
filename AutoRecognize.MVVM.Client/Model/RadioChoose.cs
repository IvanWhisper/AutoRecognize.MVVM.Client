using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecognize.MVVM.Client.Model
{
    public class RadioChoose : ObservableObject
    {
        private string content;
        private bool isCheck;

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
                RaisePropertyChanged(() => Content);
            }
        }

        public bool IsCheck
        {
            get
            {
                return isCheck;
            }

            set
            {
                isCheck = value;
                RaisePropertyChanged(() => IsCheck);
            }
        }
    }
}
