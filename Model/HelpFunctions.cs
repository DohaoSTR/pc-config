namespace PCConfig.Model
{
    public static class HelpFunctions
    {
        public static Tuple<string, string?> ParseInterface(object value)
        {
            if (value != null)
            {
                string stringValue = value.ToString();

                if (value == "PATA 100")
                {
                    return new Tuple<string, string?>(stringValue, null);
                }

                string[] parts = stringValue.Split(new[] { ' ' }, 3);

                return new Tuple<string, string?>(parts[0], parts[1]);
            }

            return null;
        }
    }
}
