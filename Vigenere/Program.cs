using Vigenere;

VigenereCifer vn=new VigenereCifer();
string Text = "attackatdawn";
string Key = "lemon";
Console.WriteLine(vn.Encrypt(Text, Key));
Text = vn.Encrypt(Text, Key);
Console.WriteLine(vn.Decrypt(Text, Key));
Console.ReadKey();