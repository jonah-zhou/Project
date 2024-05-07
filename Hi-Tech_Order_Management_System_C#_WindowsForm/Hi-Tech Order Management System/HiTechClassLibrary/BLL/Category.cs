using HiTechClassLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechClassLibrary.BLL
{
    public class Category
    {
        private int categoryId;
        private string categoryName;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public void SaveCategory(Category category)
        {
            CategoryDB.SaveRecord(category);
        }
        public List<Category> GetAllCategories()
        {
            return CategoryDB.GetAllRecords();
        }
        public void UpdateCategory(Category category)
        {
            CategoryDB.UpdateRecord(category);
        }
        public void DeleteCategory(Category category)
        {
            CategoryDB.DeleteRecord(category);
        }
        public List<Category> GetCategoriesBySearch(string search,string type)
        {
            return CategoryDB.GetRecordsBySearch(search,type);
        }
        public SqlCommand GetAllCategoriesCommand()
        {
            return CategoryDB.GetAllRecordsCommand();
        }
    }
}
