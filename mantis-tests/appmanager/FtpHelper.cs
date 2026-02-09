using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        public FtpHelper(ApplicationManager manager) : base(manager) { }
        public void BackupFile(String path)
        {

        }
        public void RestoreBackupFile(String path) { }
        public void Upload(String path, String localFile) { }

    }
}
