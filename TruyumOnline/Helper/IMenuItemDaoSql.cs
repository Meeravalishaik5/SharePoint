using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Helper
{
	public interface IMenuItemDaoSql
	{
		public List<Items> GetMenuItemListAdmin();
		public void AddMenuItemAdmin(Items items);
		public void ModifyMenuItemAdmin(Items items);
		public void DeleteMenuItemAdmin(int itemId);
		public Items GetMenuItemAdminById(int? itemId);
	}
}
