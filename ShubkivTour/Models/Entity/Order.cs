namespace ShubkivTour.Models.Entity
{
	public class Order
	{
		public int Id { get; set; }

		public string ClientId { get; set; }
		public Client Client { get; set; }

		public int OrderStatusId { get; set; }
		public OrderStatus OrderStatus { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int Number { get; set; } //Кількість товару
		public DateTime Date { get; set; }


	}
}
