using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataChange
{

    public class DataChange_CommandManager : Singleton<DataChange_CommandManager>
    {
        
        private readonly Stack<DataChange_Command> _commandStack = new Stack<DataChange_Command>();
        public void AddCommands(DataChange_Command command)
        {
            command.Excute(true);
            _commandStack.Push(command);
        }

        [EditorButton]
        public void Undo()
        {
            if (_commandStack.Count>0)
            {
                _commandStack.Pop().Excute(false);
            }
        }
    }

}