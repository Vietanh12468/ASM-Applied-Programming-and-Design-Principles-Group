using ASM2.Models;

namespace ASM2.Helpers
{
    public class DeleteHelper<T>
    {
        public void DeleteObj(string filepath, int id)
        {
            List<T>? list = FileHelper.ReadFileList<T>(filepath);
            T objRemove = FileHelper.FindObj(list, id);
            if (objRemove != null)
            {
                list.Remove(objRemove);
                FileHelper.AddToList(list, filepath);
            }
        }
    }
}
