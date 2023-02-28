using System.Linq;

namespace GeekForLess.Models
{
    public class HomeModel
    {
 
        public string ownerFolder { get; set; }
        public string nameOfFolder { get; set; }
        // private object folders;
        private List<Folder> folders;
        private GeekForLessContext db;

        public HomeModel(GeekForLessContext context)
        {
            db = context;
            folders = db.Folders.ToList();
        }

        public List<string> CreateLink(string nameOfClickedLink)
        {
            int idOwnerFolder = 0;
            List<string> listOfFolders = new List<string>();
            foreach(var item in folders)
            {
                if (item.Name == nameOfClickedLink)
                {
                    idOwnerFolder = item.IdFolder;
                    listOfFolders.Add(item.Name);
                }
            }
            
            foreach (var item in folders)
            {
                if (item.OwnerFolder == idOwnerFolder)
                    listOfFolders.Add(item.Name);
            }
            return listOfFolders;
        }
        public List<string> CreateLink()
        {
            int idOwnerFolder = 0;
            List<string> listOfFolders = new List<string>();
            
            foreach (var item in folders)
            {
                if (item.OwnerFolder == null)
                    listOfFolders.Add(item.Name);
            }

            return listOfFolders;
        }
    }
}
