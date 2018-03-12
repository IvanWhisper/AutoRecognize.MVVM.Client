using AutoRecognize.MVVM.Client.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoRecognize.MVVM.Client.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel()
        {
            //构造函数
            ValidateUI = new ValidateUserInfo();
            List = new ObservableCollection<ValidateUserInfo>();
            var aResType = new ResTypes();
            aResType.List = new List<TestC>() { new TestC() { Key = "a", Text = "A" }, new TestC() { Key = "b", Text = "B" }, new TestC() { Key = "c", Text = "C" } };
            aResType.SelectIndex = 0;
            ResType = aResType;
        }

        #region 全局属性
        private ObservableCollection<ValidateUserInfo> list;
        /// <summary>
        /// 用户数据列表
        /// </summary>
        public ObservableCollection<ValidateUserInfo> List
        {
            get { return list; }
            set { list = value; }
        }

        private ValidateUserInfo validateUI;
        /// <summary>
        /// 当前操作的用户信息
        /// </summary>
        public ValidateUserInfo ValidateUI
        {
            get { return validateUI; }
            set
            {
                validateUI = value;
                RaisePropertyChanged(() => ValidateUI);
            }
        }
        #endregion

        #region 事件转命令
        private ResTypes _ResType;
        public ResTypes ResType
        {
            get
            {
                return _ResType;
            }

            set
            {
                _ResType = value;
                RaisePropertyChanged(() => ResType);

            }
        }
        private string _selectInfo;
        public string SelectInfo
        {
            get
            {
                return _selectInfo;
            }

            set
            {
                _selectInfo = value;
                RaisePropertyChanged(() => SelectInfo);

            }
        }

        private RelayCommand selectCommand;
        /// <summary>
        /// 事件转命令执行
        /// </summary>
        public RelayCommand SelectCommand
        {
            get
            {
                if (selectCommand == null)
                    selectCommand = new RelayCommand(() => ExecuteSelect());
                return selectCommand;
            }
            set { selectCommand = value; }
        }
        private void ExecuteSelect()
        {
            if (ResType != null && ResType.SelectIndex > 0)
            {
                SelectInfo = ResType.List[ResType.SelectIndex].Text;
            }
        }

        private string _fileAdd;
        public string FileAdd
        {
            get
            {
                return _fileAdd;
            }

            set
            {
                _fileAdd = value;
                RaisePropertyChanged(() => FileAdd);
            }
        }
        private RelayCommand<DragEventArgs> dropCommand;
        /// <summary>
        /// 传递原事件参数
        /// </summary>
        public RelayCommand<DragEventArgs> DropCommand
        {
            get
            {
                if (dropCommand == null)
                    dropCommand = new RelayCommand<DragEventArgs>(e => ExecuteDrop(e));
                return dropCommand;
            }
            set { dropCommand = value; }
        }

        private void ExecuteDrop(DragEventArgs e)
        {
            FileAdd = ((System.Array)e.Data.GetData(System.Windows.DataFormats.FileDrop)).GetValue(0).ToString();
        }
        #endregion

        #region 全局命令
        private RelayCommand submitCmd;
        /// <summary>
        /// 执行提交命令的方法
        /// </summary>
        public RelayCommand SubmitCmd
        {
            get
            {
                if (submitCmd == null) return new RelayCommand(() => ExcuteValidForm(), CanExcute);
                return submitCmd;
            }
            set { submitCmd = value; }
        }
        #endregion

        #region 附属方法
        /// <summary>
        /// 执行提交方法
        /// </summary>
        private void ExcuteValidForm()
        {
            List.Add(new ValidateUserInfo() { UserEmail = ValidateUI.UserEmail, UserName = ValidateUI.UserName, UserPhone = ValidateUI.UserPhone });
        }

        /// <summary>
        /// 是否可执行（这边用表单是否验证通过来判断命令是否执行）
        /// </summary>
        /// <returns></returns>
        private bool CanExcute()
        {
            return ValidateUI.IsValidated;
        }
        #endregion
        #region 动态参数传递

        private UserParam argsTo;
        /// <summary>
        /// 动态参数传递
        /// </summary>
        public UserParam ArgsTo
        {
            get { return argsTo; }
            set { argsTo = value; RaisePropertyChanged(() => ArgsTo); }
        }

        #endregion
        //=================================================================================================================
        private RelayCommand<UserParam> dynamicParamCmd;
        /// <summary>
        /// 动态参数传递
        /// </summary>
        public RelayCommand<UserParam> DynamicParamCmd
        {
            get
            {
                if (dynamicParamCmd == null)
                    dynamicParamCmd = new RelayCommand<UserParam>(p => ExecuteDynPar(p));
                return dynamicParamCmd;
            }
            set
            {

                dynamicParamCmd = value;
            }
        }

        private void ExecuteDynPar(UserParam up)
        {
            ArgsTo = up;
        }
        #region 传递参数对象

        private UserParam objParam;
        public UserParam ObjParam
        {
            get { return objParam; }
            set { objParam = value; RaisePropertyChanged(() => ObjParam); }
        }

        #endregion

        #region 命令
        private RelayCommand<UserParam> passArgObjCmd;
        public RelayCommand<UserParam> PassArgObjCmd
        {
            get
            {
                if (passArgObjCmd == null)
                    passArgObjCmd = new RelayCommand<UserParam>((p) => ExecutePassArgObj(p));
                return passArgObjCmd;
            }
            set { passArgObjCmd = value; }
        }
        private void ExecutePassArgObj(UserParam up)
        {
            ObjParam = up;
        }
        #endregion

        #region 传递单个参数

        private string argStrTo;
        //目标参数
        public string ArgStrTo
        {
            get { return argStrTo; }
            set { argStrTo = value; RaisePropertyChanged(() => ArgStrTo); }
        }

        #endregion

        #region 命令

        private RelayCommand<string> passArgStrCommand;
        /// <summary>
        /// 传递单个参数命令
        /// </summary>
        public RelayCommand<string> PassArgStrCommand
        {
            get
            {
                if (passArgStrCommand == null)
                    passArgStrCommand = new RelayCommand<string>((p) => ExecutePassArgStr(p));
                return passArgStrCommand;

            }
            set { passArgStrCommand = value; }
        }


        private void ExecutePassArgStr(String arg)
        {
            ArgStrTo = arg;
        }

        #endregion
    }
}
