class User
{
    public string Identifier { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public DateTime FirstCreationTime { get; set; }
    public string AccountType { get; set; }
    public List<Document> Documents { get; set; }
}
