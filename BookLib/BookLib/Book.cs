namespace BookLib
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        private void ValidateTitle()
        {
            if(Title == null)
            {
                throw new ArgumentNullException("title is null");
            }
            if(Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("title must be 3 characters or longer");
            }
        }
        private void ValidatePrice() 
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be greater than 0");
            }
            if(Price > 1201) 
            {
                throw new ArgumentOutOfRangeException("Price must be less than or equal 1200");
            }
        }
        public void Validate() 
        {
            ValidateTitle();
            ValidatePrice();
        }
        public override string ToString()
        {
            return "Id: " + Id + " Title: " + Title + " Price: " + Price; 
        }
    }
}