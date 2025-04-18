namespace ShubkivTour.Models.Entity
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int BrandId { get; set; }
		public Brand Brand { get; set; }

		public string Size { get; set; }
		public string Color { get; set; }
		public int Price { get; set; }

		public int CategoryProductId { get; set; }
		public CategoryProduct CategoryProduct { get; set; }

		public string Material { get; set; }
		public string Description { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    }
}
