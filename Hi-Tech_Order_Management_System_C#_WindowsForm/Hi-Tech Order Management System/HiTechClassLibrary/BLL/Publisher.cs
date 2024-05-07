using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechClassLibrary.DAL;
namespace HiTechClassLibrary.BLL
{
    public class Publisher
    {
        private int publisherId;
        private string publisherName;
        private string webAddress;

        public int PublisherId { get => publisherId; set => publisherId = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }
        public string WebAddress { get => webAddress; set => webAddress = value; }
        
        public void SavePublisher(Publisher publisher)
        {
            PublisherDB.SaveRecord(publisher);
        }
        public List<Publisher> GetAllPublishers()
        {
            return PublisherDB.GetAllRecords();
        }
        public void UpdatePublisher(Publisher publisher)
        {
            PublisherDB.UpdateRecord(publisher);
        }
        public void DeletePublisher(Publisher publisher)
        {
            PublisherDB.DeleteRecord(publisher);
        }
        public List<Publisher> GetPublishersBySearch(string search, string type)
        {
            return PublisherDB.GetRecordsBySearch(search,type);
        }
        public SqlCommand GetAllPublishersCommand()
        {
            return PublisherDB.GetAllRecordsCommand();
        }
    }
}
