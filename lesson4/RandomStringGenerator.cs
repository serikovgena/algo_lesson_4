using System;

namespace lesson4
{
    class RandomStringGenerator
    {
        Random random;
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrftuvwxyz0123456789";

        public RandomStringGenerator() {
            random = new Random();
        }

        public string GetString() {
            int strLength = random.Next(chars.Length);
            char[] temp = new char[strLength];

            for (int i = 0; i < strLength; i++)
                temp[i++] = chars[random.Next(chars.Length)];

            return new string(temp).Replace("\0","");
        }
    }
}
