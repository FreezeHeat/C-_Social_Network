using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    interface IBackup
    {
        void createBackup(); // יצירת גיבוי
        void restoreBackup(); // שחזור גיבוי
    }
}
