using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Helper
{
	public interface ICustomerDataAccessLayer
	{
		public List<Items> GetAllActiveItems();
		public void AddToCart(Items item);
		public Items GetMenuItemAdminById(int? itemId);
		public List<Cart> GetAllCartItems();
		public Cart GetCartItem(int? cartItemId);
		public void DeleteCartItem(int cartItemId);
	}
}
