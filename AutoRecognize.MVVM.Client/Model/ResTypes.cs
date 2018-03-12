using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecognize.MVVM.Client.Model
{
    public class ResTypes
    {
        public List<TestC> List { get; set; }

        public int SelectIndex { get; set; }
    }
    public class TestC
    {
        public string Key { get; set; }
        public string Text { get; set; }

    }
}
