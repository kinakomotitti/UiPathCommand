using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KUiPath.Models
{
     interface ICommandModel
    {
         ICommandModel CreateComandModel(Dictionary<string, ICommand> optionList);

    }
}
