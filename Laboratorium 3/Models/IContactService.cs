namespace Laboratorium_3.Models
{
    public interface IContactService
    {
        int Add(Contact contact);
        Contact? FindById(int id);
        List<Contact> FindAll();
        void Delete(int id);
        void Update(Contact contact);
    }
}
