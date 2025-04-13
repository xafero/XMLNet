namespace XMLNet
{
    public record XPathed(
        string Key,
        string Val
    )
    {
        public override string ToString()
        {
            return $"{Key} = '{Val}'";
        }
    }
}