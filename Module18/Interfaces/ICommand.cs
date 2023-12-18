using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module18.Interfaces
{
    /// <summary>
    /// Интерфейс команды
    /// </summary>
    public interface ICommand
    {
        public Task CommandExecute();
    }
}
