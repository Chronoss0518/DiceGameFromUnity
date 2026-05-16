
namespace ChStd
{
    [System.Serializable]
    public class BitBool
    {
        public BitBool() { flags = new byte[1]; }

        public BitBool(uint _size)
        {
            uint size = _size > 0 ? _size : 1;
            flags = new byte[size];
        }

        public void Resize(uint _size)
        {
            uint size = _size > 0 ? _size : 1;
            if (flags.Length == size) return;
            flags = null;
            flags = new byte[size];
        }

        public void SetBitFlg(int _pos, bool _flg)
        {
            if (flags.Length * 8 <= _pos) return;
            if (_pos < 0) return;

            flags[_pos / 8] = (byte)(_flg ?
                flags[_pos / 8] | GetPosition(_pos) :
                flags[_pos / 8] & (byte.MaxValue - GetPosition(_pos)));
        }

        public void SetBitTrue(int _pos)
        {
            SetBitFlg(_pos, true);
        }

        public void SetBitFalse(int _pos)
        {
            SetBitFlg(_pos, false);
        }

        public void SetValue(byte _val,int _byteCount)
        {
            if (_byteCount < 0) return;
            if (_byteCount >= flags.Length) return;
            flags[_byteCount] = _val;
        }

        public void AllDownFlg()
        {
            for (int i = 0; i< flags.Length; i++)
            {
                flags[i] = 0;
            }
        }

        public bool GetBitFlg(int _pos)
        {
            if (_pos >= flags.Length * 8) return false;
            if (_pos < 0) return false;

            return (flags[_pos / 8] & GetPosition(_pos)) >= 1;
        }

        public byte GetValue(int _byteCount)
        {
            if (_byteCount < 0) return 0;
            if(_byteCount >= flags.Length) return 0;
            return flags[_byteCount];
        }

        public int GetSize() { return flags.Length * 8; }

        private byte GetPosition(int _pos)
        {
            return (byte)(1 << (_pos % 8));
        } 

        byte[] flags = null;
    }

}
