namespace test_projekt.Services.Impl
{
    public class Mieszkaniec
    {
        public int id { get; set; }
        public List<ContentTypeField> contentTypeFields { get; set; }

        public string GetRok()
        {
            return contentTypeFields.Find(f => f.nodeName == "Data/Date")?.nodeValue;
        }

        public int GetIloscKobiet()
        {
            return int.Parse(contentTypeFields.Find(f => f.nodeName == "Kobieta/Woman")?.nodeValue ?? "0");
        }

        public int GetIloscMezczyzn()
        {
            return int.Parse(contentTypeFields.Find(f => f.nodeName == "Mezczyzna/Man")?.nodeValue ?? "0");
        }

        public int GetWszyscy()
        {
            return int.Parse(contentTypeFields.Find(f => f.nodeName == "Wszystkich/All")?.nodeValue ?? "0");
        }
    }
}
