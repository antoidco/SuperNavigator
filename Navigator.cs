using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperNavigator.ProcessAsyncHelper;

namespace SuperNavigator
{
    public class Navigator
    {
        private string _appDirrectory;
        private string _workingDirrectory;
        private string _ktVizDirrectory;
        private string _usvDirrectory;

        public string AppDirrectory
        {
            get => _appDirrectory;
        }
        public string WorkingDirrectory
        {
            get => _workingDirrectory;
            set => _workingDirrectory = value;
        }
        public string KtVizDirrectory
        {
            get => _ktVizDirrectory;
            set => _ktVizDirrectory = value;
        }
        public string UsvDirrectory
        {
            get => _usvDirrectory;
            set => _usvDirrectory = value;
        }

        public Navigator(string appDirr)
        {
            _appDirrectory = appDirr;
        }

        public async Task<ProcessResult> Analyze()
        {
            string command = UsvDirrectory + "\\USV.exe";
            string args = "";
            return await ProcessAsyncHelper.ExecuteShellCommand(command, args, true);
        }
    }
}
