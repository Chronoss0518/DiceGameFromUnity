using System.Collections.Generic;
using System.Linq;

namespace ChStd
{
    public class TextGroupObject
    {

        public TextGroupObject() { }

        public TextGroupObject(string _text)
        {
            SetText(_text);
        }

        public TextGroupObject(string _text,char _cutChar)
        {
            SetCutChar(_cutChar);
            SetText(_text);
        }

        //Text全体を読み取る//
        public string GetText()
        {
            string res = "";

            for (int i = 0; i < textList.Count; i++)
            {
                res += textList[i];
                if (i < textList.Count - 1)
                    res += cutChar;
            }

                return res;
        }

        //Textから一行読み取る//
        public string GetTextLine(int _index = 0)
        {
            if (textList.Count <= _index) return "";
            return textList[_index];
        }

        //指定した文字数分から文字列を取得//
        public string GetSubStr(
            int _startPos = 0,
            int _endPos = -1)
        {
            return GetText().Substring(_startPos, _endPos);
        }

        //指定した文字数分から文字列を取得//
        public TextGroupObject GetSubStrToFileObject(
            int _startPos = 0,
            int _endPos = -1)
        {

            TextGroupObject res = new TextGroupObject();
            res.SetCutChar(cutChar);
            string str = GetText().Substring(_startPos, _endPos);

            res.SetText(str);
            return res;
        }

        //Textの中に指定した文字列を先頭より探し//
        //初めに見つけた行の要素数を取得//
        public int GetFindLine(
            string _findStr,
            int _startPos = 0)
        {
            string str = GetText();

            int tmp = _startPos;
            int basePos = str.IndexOf(_findStr);

            if (basePos == -1) return 0;
            int count = 1;
            while (true)
            {
                tmp = str.IndexOf(cutChar, tmp);
                if (tmp >= basePos) break;

                count++;
                tmp++;
            }
            return count;
        }

        //Textの中に指定した文字列を先頭より探し//
        //初めに見つけた位置を取得//
        public int GetFind(
            string _findStr,
            int _startPos = 0)
        {
            return GetText().IndexOf(_findStr, _startPos);
        }

        //分割する文字を指定する//
        public void SetCutChar(char _cutChar)
        {
            string text = GetText();
            cutChar=_cutChar;
            SetText(text);
        }

        //Text全体を書き込む//
        public void SetText(string _str)
        {
            textList.Clear();

            int endPos = _str.IndexOf(cutChar, 0);
            if (endPos == -1)
            {
                textList.Add(_str);
                return;
            }
            string tmp = "";
            int nowPos = 0;
            while (endPos >= 0)
            {
                tmp =_str.Substring(nowPos, endPos - 1);
                textList.Add(tmp);

                nowPos = endPos + 1;
                endPos = _str.IndexOf(cutChar,nowPos);
            }

            tmp = _str.Substring(nowPos);
            textList.Add(tmp);
        }

        //Textに一行書き込む//
        public void SetTextLine(
            string _str,
            int _setIndex = 0)
        {
            textList.Insert(_setIndex, _str);
        }


        public int Length { get { return GetText().Length; } }

        public int Count { get { return GetText().Length; } }

        public int LineCount { get { return textList.Count; } }


        char cutChar = '\n';

        List<string> textList = new List<string>();
    }


}
