namespace ShubkivTour.Models.Entity
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string ImagePath { get; set; }


    }

}
