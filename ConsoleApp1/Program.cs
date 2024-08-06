using NorthwindDataAccessLayer;
using System.Data;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("1.Show All categories 2. Insert 3. Update");
int ch = Convert.ToInt32(Console.ReadLine());
CategoryDAL d = new CategoryDAL();
switch (ch)
{
    case 1:

        List<CategoryBAL> categories = d.ShowAllCategories();

        Console.WriteLine("{0,10}|{1,30}|{2,60}|", "CategoryID", "CategoryName", "Description");
        foreach (CategoryBAL category in categories)
        {

            Console.WriteLine("{0,10}|{1,30}|{2,60}|", category.CategoryID, category.CategoryName, category.Description);
        }
        break;

    case 2:
        CategoryBAL b = new CategoryBAL();

        b.CategoryName = "Dinner";
        b.Description = "Dinner Food";
        d.AddNewCategory(b);



        break;
    case 3:
        CategoryBAL b1 = new CategoryBAL();
        b1.CategoryID = 12;
        b1.CategoryName = "North Lunch";
        b1.Description = "Roti,Dal Makhani";
        d.UpdateCategory(b1);
       

        break;

    case 4:
        DataRow drow = d.FindCategory(11);
        CategoryBAL showFoundData=new CategoryBAL();

        showFoundData.CategoryID=Convert.ToInt32(drow["CategoryID"]);
        showFoundData.CategoryName = drow["CategoryName"].ToString();
        showFoundData.Description =drow["CategoryID"].ToString();

        Console.WriteLine(showFoundData.CategoryID);
        Console.WriteLine(showFoundData.CategoryName);
        Console.WriteLine(showFoundData.Description);


        break;
    default:
        break;
}
Console.ReadLine();
