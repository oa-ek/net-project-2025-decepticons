namespace ShubkivTour.Models.Entity
{
	public class CategoryProduct
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int SubCategoryId { get; set; }
		public SubCategory SubCategory { get; set; }

	}
}
