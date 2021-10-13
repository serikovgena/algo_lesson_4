namespace lesson4
{
   public class RandomStringCollection
    {
        RandomStringGenerator gen = new();

        public RandomStringCollection() { }

        public string[] GetStringsArray(int length) {
            string[] result = new string[length];

            for (int i = 0; i < length; i++) {
                result[i] = gen.GetString();
            }

            return result;
        }
    }
}
