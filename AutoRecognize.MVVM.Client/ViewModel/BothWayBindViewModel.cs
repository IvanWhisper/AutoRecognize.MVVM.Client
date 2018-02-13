using AutoRecognize.MVVM.Client.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecognize.MVVM.Client.ViewModel
{
    public class BothWayBindViewModel : ViewModelBase
    {
        public BothWayBindViewModel()
        {
            UserInfo = new UserInfoModel();
            CombboxList = new List<ComplexInfoModel>() {
                new ComplexInfoModel() {Key="0",Text="西瓜"},
                new ComplexInfoModel() {Key="1",Text="草莓"},
                new ComplexInfoModel() {Key="2",Text="香梨"},
            };
            RadioButtons = new List<RadioChoose>() {
                new RadioChoose() {Content="天空",IsCheck=false },
                new RadioChoose() {Content="海洋",IsCheck=false },
                new RadioChoose() {Content="大地",IsCheck=false },
                new RadioChoose() {Content="宇宙",IsCheck=true },
            };
        }

        #region 属性

        private UserInfoModel userInfo;
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfoModel UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; RaisePropertyChanged(() => UserInfo); }
        }
        #region 下拉框相关
        private ComplexInfoModel combboxItem;
        /// <summary>
        /// 下拉框选中信息
        /// </summary>
        public ComplexInfoModel CombboxItem
        {
            get { return combboxItem; }
            set { combboxItem = value; RaisePropertyChanged(() => CombboxItem); }
        }
        private List<ComplexInfoModel> combboxList;
        /// <summary>
        /// 下拉框列表
        /// </summary>
        public List<ComplexInfoModel> CombboxList
        {
            get { return combboxList; }
            set { combboxList = value; RaisePropertyChanged(() => CombboxList); }
        }

        #endregion
        private string singleRadio;
        public string SingleRadio
        {
            get
            {
                return singleRadio;
            }

            set
            {
                singleRadio = value;
                RaisePropertyChanged(()=>SingleRadio);
            }
        }

        private bool isSingleRadioCheck;
        public bool IsSingleRadioCheck
        {
            get
            {
                return isSingleRadioCheck;
            }

            set
            {
                isSingleRadioCheck = value;
                RaisePropertyChanged(() => IsSingleRadioCheck);
            }
        }

        private List<RadioChoose> radioButtons;
        public List<RadioChoose> RadioButtons
        {
            get
            {
                return radioButtons;
            }

            set
            {
                radioButtons = value;
                RaisePropertyChanged(()=>RadioButtons);
            }
        }


        #endregion

        #region 命令
        #endregion
    }
}
