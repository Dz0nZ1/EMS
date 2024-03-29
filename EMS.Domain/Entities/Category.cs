namespace EMS.Domain.Entities;

public class Category
{
   #region Properties

   public Guid Id { get; private set; }
   public string Name { get; private set; } = string.Empty;
   public string Description { get; private set; } = string.Empty;

   public IList<Event>? Events = new List<Event>();

   #endregion

   #region Constructors

   public Category(string name, string description)
   {
      Id = Guid.NewGuid();
      Name = name;
      Description = description;
   }
   
   private Category(){}

   #endregion


   #region Extensions

   public Category UpdateCategory(string name, string description)
   {
      Name = name;
      Description = description;
      return this;
   }

   #endregion
}