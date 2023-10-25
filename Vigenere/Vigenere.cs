using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigenere
{
    public class VigenereCifer
    {
        private Dictionary<char, int> CharToInt = new Dictionary<char, int>();
        private Dictionary<int,char> IntToChar=new Dictionary<int,char>();
        private char[] KeyArray;
        public VigenereCifer() 
        {
             CreateEncrypterDictionary1();
             CreateEncrypterDictionary2();
        }
        public string Encrypt(string text , string key)
        {
            return TranslateText(encrypt:true, text, key);
        }
        public string Decrypt(string text , string key)
        {
            return TranslateText(encrypt:false, text, key);
        }
        private string TranslateText(bool encrypt,string text,string key)
        {
            while(text.Length > key.Length) 
            {
                key = key + key;
            }
            char[] Text= text.ToCharArray();
            KeyArray= key.ToCharArray();
            for (int i = 0; i < Text.Length; i++)
                {
                    bool uppercase = false;
                    if (Char.IsLetter(Text[i]))
                    {
                        if (Char.IsUpper(Text[i]))
                        {
                            uppercase = true;
                            Text[i] = Char.ToLower(Text[i]);
                        }
                        if (encrypt)
                        {
                            Text[i] = EncryptChar(Text[i], KeyArray[i]);
                        }
                        else
                        {
                            Text[i] = DecryptChar(Text[i], KeyArray[i]);
                        }
                        if (uppercase)
                        {
                            Text[i] = Char.ToUpper(Text[i]);
                            uppercase = false;
                        }
                    }
                }
            string toReturn = new string(Text);
            return toReturn;
        }
        private void CreateEncrypterDictionary1()
        {
            CharToInt.Add('a', 0);
            CharToInt.Add('b', 1);
            CharToInt.Add('c', 2);
            CharToInt.Add('d', 3);
            CharToInt.Add('e', 4);
            CharToInt.Add('f', 5);
            CharToInt.Add('g', 6);
            CharToInt.Add('h', 7);
            CharToInt.Add('i', 8);
            CharToInt.Add('j', 9);
            CharToInt.Add('k', 10);
            CharToInt.Add('l', 11);
            CharToInt.Add('m', 12);
            CharToInt.Add('n', 13);
            CharToInt.Add('o', 14);
            CharToInt.Add('p', 15);
            CharToInt.Add('q', 16);
            CharToInt.Add('r', 17);
            CharToInt.Add('s', 18);
            CharToInt.Add('t', 19);
            CharToInt.Add('u', 20);
            CharToInt.Add('v', 21);
            CharToInt.Add('w', 22);
            CharToInt.Add('x', 23);
            CharToInt.Add('y', 24);
            CharToInt.Add('z', 25);
        }
        private void CreateEncrypterDictionary2()
        {
            IntToChar.Add(0, 'a');
            IntToChar.Add(1, 'b');
            IntToChar.Add(2, 'c');
            IntToChar.Add(3, 'd');
            IntToChar.Add(4, 'e');
            IntToChar.Add(5, 'f');
            IntToChar.Add(6, 'g');
            IntToChar.Add(7, 'h');
            IntToChar.Add(8, 'i');
            IntToChar.Add(9, 'j');
            IntToChar.Add(10, 'k');
            IntToChar.Add(11, 'l');
            IntToChar.Add(12, 'm');
            IntToChar.Add(13, 'n');
            IntToChar.Add(14, 'o');
            IntToChar.Add(15, 'p');
            IntToChar.Add(16, 'q');
            IntToChar.Add(17, 'r');
            IntToChar.Add(18, 's');
            IntToChar.Add(19, 't');
            IntToChar.Add(20, 'u');
            IntToChar.Add(21, 'v');
            IntToChar.Add(22, 'w');
            IntToChar.Add(23, 'x');
            IntToChar.Add(24, 'y');
            IntToChar.Add(25, 'z');
        }
        private char EncryptChar(char c, char key)
        {
            int intemrdiary1 = CharToInt[c];
            int intemediary2 = CharToInt[key];
            int result=(intemrdiary1+intemediary2)%26;
            char toReturn = IntToChar[result];
            return toReturn;
        }
        private char DecryptChar(char c, char key)
        {
            int intemrdiary1 = CharToInt[c];
            int intemrdiary2= CharToInt[key];
            int result = intemrdiary1 - intemrdiary2;
            if (result < 0) result += 26;
            char toReturn = IntToChar[result];
            return toReturn;
        }
    }
}
