
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace LibraryManager

    {
        internal class Program
        {
            static SqlConnection con;
            static SqlCommand cmd;
            static SqlDataAdapter adapter;
            static DataSet ds;
            static string constr = "server=RESHULOTUS;database=Assign7; trusted_connection = true;";

        public static void LoadData()
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("Select * From Books", con);
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "Books");
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                con.Close();
            }
            public static void Display()
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("BookID : " + ds.Tables[0].Rows[i]["BookId"]);
                    Console.WriteLine("Title : " + ds.Tables[0].Rows[i]["Title"]);
                    Console.WriteLine("Author : " + ds.Tables[0].Rows[i]["Author"]);
                    Console.WriteLine("Genre : " + ds.Tables[0].Rows[i]["Genre"]);
                    Console.WriteLine("Quantity : " + ds.Tables[0].Rows[i]["Quantity"]);
                    Console.WriteLine("--------------------------------------------------------");
                }


            }
            public static void AddBook()
            {


                ds = new DataSet();   
                adapter.Fill(ds, "Books");

                DataTable dt = ds.Tables["Books"];
                DataRow dr = dt.NewRow();

                Console.WriteLine("Enter BookId");
                dr["BookId"] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book Title");
                dr["Title"] = Console.ReadLine();
                Console.WriteLine("Enter Book Author");
                dr["Author"] = Console.ReadLine();
                Console.WriteLine("Enter Book Genre");
                dr["Genre"] = Console.ReadLine();
                Console.WriteLine("Enter Book Quantity");
                dr["Quantity"] = int.Parse(Console.ReadLine());

                dt.Rows.Add(dr);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "Books");
                Console.WriteLine("Inserted!!!");

            }
            public static void UpdateQuantity()
            {


                ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                Console.WriteLine("Enter Books id to update Book quantity");
                int cid = int.Parse(Console.ReadLine());
                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((int)dt.Rows[i]["BookId"] == cid)
                    {
                        dr = dt.Rows[i];
                        break;
                    }
                }
                if (dr != null)
                {

                    Console.WriteLine("Enter new Quantity");
                    dr["Quantity"] = int.Parse(Console.ReadLine());
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                    Console.WriteLine("Record updated");
                }
                else
                {
                    Console.WriteLine("no such record exist");
                }

            }
            static void Main(string[] args)
            {
                char ch;
                do
                {
                    Console.WriteLine("Select \n1.Display book Inventory\n2.Add New Book\n3.Update Book Quantity");
                    int op = int.Parse(Console.ReadLine());
                    LoadData();
                    switch (op)
                    {
                        case 1:
                            Display();
                            break;
                        case 2:
                            AddBook();
                            break;
                        case 3:
                            UpdateQuantity();
                            break;

                        default:
                            Console.WriteLine("Invalid operation");
                            break;
                    }
                    Console.WriteLine("If you want to continue press y");
                    ch = char.Parse(Console.ReadLine());
                } while (ch == 'y');
            }
        }
    }