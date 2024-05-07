using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.DAL;
using HiTechClassLibrary.VALIDATION;

namespace HiTechClassLibrary.BLL
{
    public class UserAccount
    {
        private int userId;
        private string password;
        private int employeeId;

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }

        public UserAccount GetUserAccountById(int userId)
        {
            return UserAccountDB.GetRecordById(userId);
        }
        public override string ToString()
        {
            return $"User ID: {UserId}\nPassword: {Password}\nEmployee ID: {EmployeeId}";
        }
        public void SaveUserAccount(UserAccount userAccount)
        {
            UserAccountDB.SaveRecord(userAccount);
        }
        public List<UserAccount> GetAllUserAccounts()
        {
            return UserAccountDB.GetAllRecords();
        }
        public void UpdateUserAccount(UserAccount userAccount)
        {
            UserAccountDB.UpdateRecord(userAccount);
        }
        public void DeleteUserAccount(int userId)
        {
            UserAccountDB.DeleteRecord(userId);
        }
        public void DisplayUserAccountList(ListView listV, List<UserAccount> listUA)
        {
            listV.Items.Clear();
            foreach (UserAccount userAccount in listUA)
            {
                ListViewItem item = new ListViewItem(userAccount.UserId.ToString());
                item.SubItems.Add(userAccount.Password);
                item.SubItems.Add(userAccount.EmployeeId.ToString());
                
                listV.Items.Add(item);
            }
        }
        public List<UserAccount> SearchUserAccount(int userId)
        {
            return UserAccountDB.SearchRecord(userId);
        }
    }
}
