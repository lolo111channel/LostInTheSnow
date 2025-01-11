namespace CBStuff.StringManipulation
{
    public class StringManipulation
    {
        public static string ChangeFirstLetterOnLarge(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            return char.ToUpper(value[0]) + value.Substring(1);
        }

    }
}
