namespace DotaParser52;

public class Filter
{
   private readonly List<string[]> _data;

   public Filter(List<string[]> data)
   {
      _data = data;
   }
   public void Filtering( (int characteristic, int value, int equalOrSuperior) filter)
   {
      if (filter.equalOrSuperior == 0)
      {
         FilterEqualsValue(filter.value, filter.characteristic);
      }
      else
      {
         FilterSuperiorValue(filter.value, filter.characteristic);
      }
   }

   public void FilterEqualsValue(int value, int Characteristic)
   {
      bool found = false;
      foreach (string[] line in _data)
      {
         if (int.Parse(line[Characteristic]) == value)
         {
            Console.WriteLine("{0}, {1}",  line[0], line[Characteristic] );
            found = true;
         }
         
      }
      if(!found)
         Console.WriteLine(" ничео нее найдено");
   }
   public void FilterSuperiorValue(int value, int Characteristic)
   {
      bool found = false;
      foreach (string[] line in _data)
      {
         if (int.Parse(line[Characteristic]) > value)
         {
            Console.WriteLine("{0}, {1}",  line[0], line[Characteristic] );
            found = true;
         }
      }
      if (!found)
         Console.WriteLine(" ничео нее найдено");
   }
}