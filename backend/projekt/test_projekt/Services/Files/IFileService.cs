using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace test_projekt.Services.Files
{
    public interface IFileService
    {
        void ImportXml();
        void ImportJson();
        void ExportXml();
        void ExportJson();

        void ImportCsvToDB();
        void ExportDataToCsv();

        XmlDocument GetDocument();
        JsonDocument GetJson();
        string GetTableDataAsJson();
        string get_mieszkancy();
        bool DeleteFromData(int id);
        void SaveDataAsXml();
    }
}
