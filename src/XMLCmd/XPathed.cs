namespace XMLNet
{
    public record XPathed(
        string Key,
        string Val
    )
    {
        public string ToString(bool reverse)
        {
            return reverse
                ? $"'{Val}' = {Key}"
                : $"{Key} = '{Val}'";
        }
    }
}