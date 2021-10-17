public class Rootobject
{
    public Pagination Pagination { get; set; }
    public Result[] Results { get; set; }
}

public class Pagination
{
    public int Page { get; set; }
    public int PageNext { get; set; }
    public object PagePrev { get; set; }
    public int PageTotal { get; set; }
    public int Results { get; set; }
    public int ResultsPerPage { get; set; }
    public int ResultsTotal { get; set; }
}

public class Result
{
    public int ID { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}
