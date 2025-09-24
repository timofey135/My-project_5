using System;
using System.Text;

public class Cryptor
{
    private string _text;

    public string Text => _text;

    public Cryptor(string initialText)
    {
        _text = initialText;
    }

    public void Decrypt()
    {
        _text = _text.Replace('*', 'u');
    }

    public void Correct()
    {
        _text = _text.Replace('>', '\n');
    }

    public void Peel()
    {
        _text = _text.Replace("$", "");

        if (_text.EndsWith("zzz"))
        {
            _text = _text.Substring(0, _text.Length - 3);
        }
    }

    public void Encrypt()
    {
        string step1 = _text
            .Replace('a', '1')
            .Replace('e', '2')
            .Replace('i', '3')
            .Replace('o', '4')
            .Replace('u', '5')
            .Replace('A', '1')
            .Replace('E', '2')
            .Replace('I', '3')
            .Replace('O', '4')
            .Replace('U', '5');

        char[] charArray = step1.ToCharArray();
        Array.Reverse(charArray);
        string step2 = new string(charArray);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < step2.Length; i++)
        {
            if (i > 0 && i % 5 == 0)
                sb.Append('#');
            sb.Append(step2[i]);
        }

        _text = sb.ToString();
    }
}