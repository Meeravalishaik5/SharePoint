using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Helper
{
	public class MenuItemDaoSql : IMenuItemDaoSql
	{
		string connectionString= "Data Source = LAPTOP-NCJ1L16F\\SQLEXPRESS; User ID =sa;password=pass@word1;Initial Catalog = TruYum; Integrated Security = True; Trusted_Connection=True;";
		public void AddMenuItemAdmin(Items items)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Items(ItemName,Price,Active,Category,FreeDelivery,DateOfLaunch) Values(@ItemName,@Price,@Active,@Category,@FreeDelivery,@DateOfLaunch)", con);
				cmd.Parameters.AddWithValue("@ItemName",items.ItemName);
				cmd.Parameters.AddWithValue("@Price",items.Price);
				cmd.Parameters.AddWithValue("@Active", items.Active);
				cmd.Parameters.AddWithValue("@Category", items.Category);
				cmd.Parameters.AddWithValue("@FreeDelivery", items.FreeDelivery);
				cmd.Parameters.AddWithValue("@DateOfLaunch", items.DateOfLaunch);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		public void DeleteMenuItemAdmin(int itemId)
		{
			using(SqlConnection con=new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE ItemId=@ItemId", con);
				cmd.Parameters.AddWithValue("@Itemid",itemId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		public Items GetMenuItemAdminById(int? itemId)
		{
			Items item = new Items();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Items WHERE ItemId= " + itemId;
				SqlCommand cmd = new SqlCommand(sqlQuery,con);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					item.ItemId = Convert.ToInt32(rdr["ItemId"]);
					item.ItemName = rdr["ItemName"].ToString();
					item.Price = rdr["Price"].ToString();
					item.Active = rdr["Active"].ToString();
					item.Category = rdr["Category"].ToString();
					item.FreeDelivery = rdr["FreeDelivery"].ToString();
					item.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
				}
				con.Close();
			}
			return item;
		}
		public List<Items> GetMenuItemListAdmin()
		{
			List<Items> itemsList = new List<Items>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Items", con);
				//cmd.ExecuteNonQuery();
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Items item = new Items();
					item.ItemId = Convert.ToInt32(rdr["ItemId"]);
					item.ItemName = rdr["ItemName"].ToString();
					item.Price = rdr["Price"].ToString();
					item.Active = rdr["Active"].ToString();
					item.Category = rdr["Category"].ToString();
					item.FreeDelivery = rdr["FreeDelivery"].ToString();
					item.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
					itemsList.Add(item);
				}
				con.Close();
			}
			return itemsList;
		}

		public void ModifyMenuItemAdmin(Items items)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("UPDATE Items SET ItemName=@ItemName,Price=@Price,Active=@Active,Category=@Category,FreeDelivery=@FreeDelivery,DateOfLaunch=@DateOfLaunch WHERE ItemId=@ItemId", con);
				cmd.Parameters.AddWithValue("@ItemId", items.ItemId);
				cmd.Parameters.AddWithValue("@ItemName", items.ItemName);
				cmd.Parameters.AddWithValue("@Price", items.Price);
				cmd.Parameters.AddWithValue("@Active", items.Active);
				cmd.Parameters.AddWithValue("@Category", items.Category);
				cmd.Parameters.AddWithValue("@FreeDelivery", items.FreeDelivery);
				cmd.Parameters.AddWithValue("@DateOfLaunch", items.DateOfLaunch);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}

		}
	}
}
