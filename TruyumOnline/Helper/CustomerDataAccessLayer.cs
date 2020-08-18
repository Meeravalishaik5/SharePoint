using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Helper
{
	public class CustomerDataAccessLayer : ICustomerDataAccessLayer
	{
		string connectionString = "Data Source = LAPTOP-NCJ1L16F\\SQLEXPRESS; User ID =sa;password=pass@word1;Initial Catalog = TruYum; Integrated Security = True; Trusted_Connection=True;";

		public void AddToCart(Items items)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Cart(ItemName,Price,Active,Category,FreeDelivery,ItemId,DateOfLaunch) Values(@ItemName,@Price,@Active,@Category,@FreeDelivery,@ItemId,@DateOfLaunch)", con);
				cmd.Parameters.AddWithValue("@ItemName",items.ItemName);
				cmd.Parameters.AddWithValue("@Price", items.Price);
				cmd.Parameters.AddWithValue("@Active", items.Active);
				cmd.Parameters.AddWithValue("@Category", items.Category);
				cmd.Parameters.AddWithValue("@FreeDelivery", items.FreeDelivery);
				cmd.Parameters.AddWithValue("@ItemId", items.ItemId);
				cmd.Parameters.AddWithValue("@DateOfLaunch", items.DateOfLaunch);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void DeleteCartItem(int cartItemId)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE CartItemId=@CartItemId", con);
				cmd.Parameters.AddWithValue("@CartItemid",cartItemId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public List<Items> GetAllActiveItems()
		{
			List<Items> itemsList = new List<Items>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Items Where Active=@Active", con);
				cmd.Parameters.AddWithValue("@Active", "Yes");
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

		public List<Cart> GetAllCartItems()
		{
			List<Cart> cartList = new List<Cart>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Cart", con);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Cart cart = new Cart();
					cart.CartItemId = Convert.ToInt32(rdr["CartItemId"]);
					cart.ItemId = Convert.ToInt32(rdr["ItemId"]);
					cart.ItemName = rdr["ItemName"].ToString();
					cart.Price = rdr["Price"].ToString();
					cart.Active = rdr["Active"].ToString();
					cart.Category = rdr["Category"].ToString();
					cart.FreeDelivery = rdr["FreeDelivery"].ToString();
					cart.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
					cartList.Add(cart);
				}
				con.Close();
			}
			return cartList;
		}

		public Cart GetCartItem(int? cartItemId)
		{
			Cart cart = new Cart();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Cart WHERE CartItemId= " + cartItemId;
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					cart.CartItemId = Convert.ToInt32(rdr["CartItemId"]);
					cart.ItemName = rdr["ItemName"].ToString();
					cart.Price = rdr["Price"].ToString();
					cart.Active = rdr["Active"].ToString();
					cart.Category = rdr["Category"].ToString();
					cart.FreeDelivery = rdr["FreeDelivery"].ToString();
					cart.ItemId = Convert.ToInt32(rdr["ItemId"]);
					cart.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
				}
				con.Close();
			}
			return cart;
		}

		public Items GetMenuItemAdminById(int? itemId)
		{
			Items item = new Items();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Items WHERE ItemId= " + itemId;
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
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
	}
}
