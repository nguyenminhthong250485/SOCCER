using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENT_NEW
{
    public interface IFunction
    {
        void login();
        string getMessage();
        void WinLoseWeek();
        double getWinLose();
        void Transfer();
        void SetUsd(string str_usd);
        void SetHeSoCom(string str_hesocom);
    }
}
