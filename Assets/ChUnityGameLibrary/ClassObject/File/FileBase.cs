using UnityEngine;

namespace ChStd
{
    abstract public class FileBase
    {
        public virtual void Open(string _fileName, bool _updateFlg = false)
        {
            fileName = _fileName;
            updateFlg = _updateFlg;
        }

        public virtual void Close()
        {
            fileName = "";
            isOpen = false;
        }

        public string fileName { get; private set; } = "";

        public bool isOpen { get; private set; } = false;

        protected string absolutePath { get { return Application.persistentDataPath + "/" + fileName; } }

        //FileのClose自にFileの内容を更新するかしないかのフラグ//
        protected bool updateFlg { get; private set; } = false;

    }

}